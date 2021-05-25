using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proga
{
    interface ICheck_Len_Txt
    {
        bool ch_lengt(string len, int l);
    }
    public class Human : ICheck_Len_Txt
    {
        public virtual bool Check_log(string log)
        {
            throw new ArgumentException("Вызван метод из базового класса");

        }
        private string login1;
        private string password1;
        private string pasport_dat1;
        private string fIO;

        public Human()
        {

        }
        public Human(string FIO, string pasport_dat, string login, string password)
        {
            if (ch_lengt(login, 20) && ch_lengt(password, 20) && ch_lengt(pasport_dat, 100) && ch_lengt(FIO, 100))
            {
                this.FIO = FIO;
                this.login = login;
                this.password = password;
                this.pasport_dat = pasport_dat;
            }
        }
        [StringLength(100)]
        public string FIO
        {
            get => fIO;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("ФИО не введено", nameof(value));
                fIO = value;
            }
        }
        [StringLength(100)]
        public string pasport_dat
        {
            get => pasport_dat1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Паспортнын данные не введены", nameof(value));
                pasport_dat1 = value;
            }
        }

        [Required]
        [StringLength(20)]
        public string login
        {
            get => login1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Ничего не введено в логине.", nameof(value));
                login1 = value;
            }
        }

        [Required]
        [StringLength(20)]
        public string password
        {
            get => password1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Ничего не введено в пароле.", nameof(value));
                password1 = value;
            }
        }

        public bool ch_lengt(string len, int l)
        {
            if (len.Length < l) return true;
            else return false;
        }
    }
}
