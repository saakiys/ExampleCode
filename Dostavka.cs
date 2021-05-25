namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dostavka")]
    public partial class Dostavka : ICheck_Len_Txt
    {
        private string address1;
        private double price1;
        private string status_dostv1;

        public Dostavka()
        {
        }
        public Dostavka(Dostavchik Dostavchik, Prodaga Prodaga)
        {
            this.Dostavchik = Dostavchik;
            this.Prodaga = Prodaga;
        }
        public Dostavka(double price, string address, string status_dostv, Dostavchik Dostavchik, Prodaga Prodaga)
        {
            if (ch_lengt(address, 50) && ch_lengt(status_dostv, 50))
            {
                this.id_dostavchika = Dostavchik.id_dostavchika;
                this.id_prodaga = Prodaga.id_prodaga;
                this.price = price;
                this.address = address;
                this.status_dostv = status_dostv;
                this.Dostavchik = Dostavchik;
                this.Prodaga = Prodaga;
            }
        }
        public bool ch_lengt(string len, int l)
        {
            if (len.Length < l) return true;
            else return false;
        }
        [Key]
        public int id_dostavka { get; set; }

        [Required]
        [StringLength(50)]
        public string address
        {
            get => address1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ничего не введено в адрессе.");
                address1 = value;
            }
        }

        public double price
        {
            get => price1;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("цена <= 1", nameof(value));
                price1 = value;
            }
        }
        [Required]
        [StringLength(50)]
        public string status_dostv
        {
            get => status_dostv1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("цена <= 1", nameof(value));
                status_dostv1 = value;
            }
        }

        public int id_dostavchika { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_dost { get; set; }

        public int id_prodaga { get; set; }

        public Dostavchik Dostavchik { get; set; }

        public Prodaga Prodaga { get; set; }
    }
}
