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
    public partial class FormReg : Form
    {
        BD bD = new BD();

        public FormReg()
        {
            InitializeComponent();
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
                                            string login = textBoxLogin.Text;
                                            Client client = new Client();
                                            Human human = new Client(textBoxFIO.Text, textBoxFIO.Text,
                                               textBoxLogin.Text, textBoxPassword.Text);

                                            if (human.Check_log(login))
                                            {
                                                string password = textBoxPassword.Text;
                                                string recvizits = textBoxRezv.Text;
                                                string pasport_dat = textBoxPassport.Text;
                                                string FIO = textBoxFIO.Text;
                                                string contact_pers = textBoxContact_inf.Text;
                                                string address = textBoxAddress.Text;
                                                client = new Client(FIO, login, password, recvizits, address, pasport_dat, contact_pers);
                                                bD.Client.Add(client);
                                                bD.SaveChanges();
                                                MessageBox.Show("Регистрация успешно выполнена!");
                                                Close();
                                            }
                                            else
                                            {
                                                textBoxLogin.Clear();
                                                MessageBox.Show("Напишите другой логин, такой уже занят!");
                                            }
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
    }
}
