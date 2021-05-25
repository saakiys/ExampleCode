using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proga
{
    public partial class FormUpdate : Form
    {
        BD bD = new BD();
        Client cl;
        bool ch=false;
        public FormUpdate(Client cl)
        {
            InitializeComponent();
            this.cl = cl;
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = cl.login;
            textBoxPassword.Text = cl.password;
            textBoxRezv.Text = cl.recvizits;
            
            textBoxPassport.Text = cl.pasport_dat;
            textBoxFIO.Text = cl.FIO;
            textBoxContact_inf.Text = cl.contact_pers;
            textBoxAddress.Text = cl.address;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLogin.Text != "")
                {
                    if (textBoxPassword.Text != "")
                    {
                        if (textBoxFIO.Text != "")
                        {
                            if (textBoxAddress.Text != "")
                            {
                                if (textBoxContact_inf.Text != "")
                                {
                                    if (textBoxPassport.Text != "")
                                    {
                                        if (textBoxRezv.Text != "")
                                        {
                                            string a = textBoxLogin.Text;
                                            var cli = bD.Client
                                                .Where(i => i.id_client == cl.id_client)
                                                .FirstOrDefault();

                                            Human human = new Client(textBoxFIO.Text, textBoxFIO.Text,
                                                textBoxLogin.Text, textBoxPassword.Text);

                                            if (human.Check_log(a) && ch) { cli.login = textBoxLogin.Text; }
                                            cli.password = textBoxPassword.Text;
                                            cli.recvizits = textBoxRezv.Text;
                                            cli.pasport_dat = textBoxPassport.Text;
                                            cli.FIO = textBoxFIO.Text;
                                            cli.contact_pers = textBoxContact_inf.Text;
                                            cli.address = textBoxAddress.Text;
                                        
                                            bD.SaveChanges();
                                            MessageBox.Show("Изменения успешно сохранены!");
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Введите данные о реквезитах!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Введите паспортные данные(серия и номер)!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Введите контактную информацию!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите адресс!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите ФИО!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обработке данных: " + ex.Message);
            }
        }

        private void textBoxLogin_Click(object sender, EventArgs e)
        {
            if(cl.login != textBoxLogin.Text)
            {
                ch = true;
            }
        }

        private void textBoxLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (cl.login != textBoxLogin.Text)
            {
                ch = true;
            }
        }
    }
}
