namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Izdelie")]
    public partial class Izdelie : ICheck_Len_Txt
    {
        private double mass1;
        private double price1;
        private string tip_izd1;
        private string razmer_special_mess1;

        public Izdelie()
        {
            Izgotovlenie = new HashSet<Izgotovlenie>();
            Prodaga = new HashSet<Prodaga>();
            Zakaz = new HashSet<Zakaz>();
        }

        public Izdelie(ProbPalata ProbPalata)
        {
            Izgotovlenie = new HashSet<Izgotovlenie>();
            Prodaga = new HashSet<Prodaga>();
            Zakaz = new HashSet<Zakaz>();
            this.ProbPalata = ProbPalata;
        }

        public Izdelie(string tip_izd, double mass, double price, string razmer_special_mess, ProbPalata ProbPalata)
        {
            if (ch_lengt(tip_izd, 25))
            {
                Izgotovlenie = new HashSet<Izgotovlenie>();
                Prodaga = new HashSet<Prodaga>();
                Zakaz = new HashSet<Zakaz>();
                this.ProbPalata = ProbPalata;
                this.id_prob_palate = ProbPalata.id_prob_palate;
                this.data_shtampa = null;
                this.tip_izd = tip_izd;
                this.mass = mass;
                this.price = price;
                this.razmer_special_mess = razmer_special_mess;

            }
        }

        public bool ch_lengt(string len, int l)
        {
            if (len.Length < l) return true;
            else return false;
        }

        [Key]
        public int id_izdelia { get; set; }

        [StringLength(25)]
        public string tip_izd
        {
            get => tip_izd1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип не введён", nameof(value));
                tip_izd1 = value;
            }
        }

        public double mass
        {
            get => mass1;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("масса <= 1", nameof(value));
                mass1 = value;
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

        public int id_prob_palate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_shtampa { get; set; }

        public string razmer_special_mess
        {
            get => razmer_special_mess1;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Размер и особенности не введёны", nameof(value));
                razmer_special_mess1 = value;
            }
        }

        public ProbPalata ProbPalata { get; set; }

        public ICollection<Izgotovlenie> Izgotovlenie { get; set; }

        public ICollection<Prodaga> Prodaga { get; set; }


        public ICollection<Zakaz> Zakaz { get; set; }
    }
}
