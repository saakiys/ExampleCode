namespace proga
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Client")]
    public partial class Client : Human, ICheck_Len_Txt
    {
        public override bool Check_log(string log)
        {
            BD bD = new BD();
            var login = from t in bD.Client
                        select new { log = t.login };
            foreach (var c in login)
            {
                if (log == c.log)
                {
                    throw new ArgumentException("Такой логин занят, введите другой!");
                }
            }
            login = from t in bD.Sotrudnik
                    select new { log = t.login };
            foreach (var c in login)
            {
                if (log == c.log)
                {
                    throw new ArgumentException("Такой логин занят, введите другой!");
                }
            }
            return true;
        }
        private double saleL1;
        private string recvizits1;
        private string address1;
        private string contact_pers1;

        public Client()
        {
            Prodaga = new HashSet<Prodaga>();
            Zakaz = new HashSet<Zakaz>();
        }
        public Client(string FIO, string pasport_dat, string login, string password)
        {
            if (ch_lengt(login, 20) && ch_lengt(password, 20)
                && ch_lengt(pasport_dat, 100) && ch_lengt(FIO, 100))
            {
                this.FIO = FIO;
                this.login = login;
                this.password = password;
                this.pasport_dat = pasport_dat;
            }
        }
        public Client(string FIO, string login, string password, string recvizits, string address, string pasport_dat, string contact_pers)
        {
            if (ch_lengt(login, 20) && ch_lengt(password, 20) && ch_lengt(recvizits, 100)
                && ch_lengt(pasport_dat, 100) && ch_lengt(FIO, 100) && ch_lengt(address, 50))
            {
                Prodaga = new HashSet<Prodaga>();
                Zakaz = new HashSet<Zakaz>();
                this.FIO = FIO;
                this.login = login;
                this.password = password;
                this.recvizits = recvizits;
                this.address = address;
                this.pasport_dat = pasport_dat;
                this.contact_pers = contact_pers;
                this.saleL = 1;
            }
        }

        [Key]
        public int id_client { get; set; }

        public double saleL
        {
            get => saleL1;
            set
            {
                if (value > 1 || value <= 0)
                    throw new ArgumentException("Неверно введена скидка.");
                saleL1 = value;
            }
        }

        [Required]
        [StringLength(100)]
        public string recvizits
        {
            get => recvizits1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ничего не введено в реквезитах.", nameof(value));
                recvizits1 = value;
            }
        }

        [Required]
        [StringLength(50)]
        public string address
        {
            get => address1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ничего не введено в адрессе.", nameof(value));
                address1 = value;
            }
        }

        public string contact_pers
        {
            get => contact_pers1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ничего не введено в контакной инфорамации.", nameof(value));
                contact_pers1 = value;
            }
        }

        public ICollection<Prodaga> Prodaga { get; set; }

        public ICollection<Zakaz> Zakaz { get; set; }
    }
}
