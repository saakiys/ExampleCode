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
    public partial class Form1 : Form
    {
        BD bb = new BD();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void autor_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string login = logon_txt.Text;
                string password = password_txt.Text;
                bool ch = true;
                var login_pass = from t in bb.Client 
                            select new { t.login, t.password, t.id_client };
                foreach (var r in login_pass)
                {
                    if (login == r.login && password == r.password)
                    {
                        ch = false;
                        logon_txt.Clear();
                        password_txt.Clear();
                        Myprevzakaz _For_Client = new Myprevzakaz(bb.Client.Find(r.id_client));
                        Hide(); //скрываю форму
                        _For_Client.ShowDialog();
                        Close(); 
                    }
                }//если это клиент
                var login_pass1 = from t in bb.Sotrudnik
                             select new { t.login, t.password, t.id_sotr };
                foreach (var r in login_pass1)
                {
                    if (login == r.login && password == r.password)
                    {
                        ch = false;
                        logon_txt.Clear();
                        password_txt.Clear();
                        // открыть форму для сотрудника
                        //Form_for_client _For_Client = new Form_for_client();
                        Hide(); //скрываю форму
                        //_For_Client.ShowDialog();
                        Show(); //открываем обратно глав форму
                    }
                }// если это сотрудник

                if(ch) MessageBox.Show("Неверно введён логин или пароль.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при обработке данных: " + ex.Message);
            }
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            FormReg reg = new FormReg();
            Hide();
            reg.ShowDialog();
            Form1_Load(reg_btn, e);
            Show();
        }//форма для регистрации клиента
    }
}
