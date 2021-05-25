namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodaga")]
    public partial class Prodaga
    {

        public Prodaga()
        {
            Dostavka = new HashSet<Dostavka>();
        }
        public Prodaga(Client Client, Izdelie Izdelie, Zakaz Zakaz)
        {
            Dostavka = new HashSet<Dostavka>();
            this.Izdelie = Izdelie;
            this.Zakaz = Zakaz;
            this.Client = Client;
            this.id_izdelia = Izdelie.id_izdelia;
            this.id_zakaz = Zakaz.id_zakaz;
            this.id_client = Client.id_client;
        }
        public Prodaga(double sale, Client Client, Izdelie Izdelie, Zakaz Zakaz)
        {
            Dostavka = new HashSet<Dostavka>();
            this.id_izdelia = Izdelie.id_izdelia;
            this.id_zakaz = Zakaz.id_zakaz;
            this.id_client = Client.id_client;
            this.sale = sale;
            this.Izdelie = Izdelie;
            this.Zakaz = Zakaz;
            this.Client = Client;
        }
        [Key]
        public int id_prodaga { get; set; }
        [Column(TypeName = "date")]
        public DateTime? data_prod { get; set; }
        public double sale { get; set; }
        public int id_zakaz { get; set; }
        public int id_client { get; set; }
        public int id_izdelia { get; set; }
        public Client Client { get; set; }

        public ICollection<Dostavka> Dostavka { get; set; }
        public Izdelie Izdelie { get; set; }
        public Zakaz Zakaz { get; set; }
    }
}
