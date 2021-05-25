namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zakaz")]
    public partial class Zakaz
    {
        public Zakaz()
        {
            Prodaga = new HashSet<Prodaga>();
        }
        public Zakaz(Client Client, Izdelie Izdelie)
        {
            Prodaga = new HashSet<Prodaga>();
            this.Izdelie = Izdelie;
            this.Client = Client;
        }
        public Zakaz(DateTime data_zakaz, Client Client, Izdelie Izdelie)
        {
            Prodaga = new HashSet<Prodaga>();
            this.data_zakaz = data_zakaz;
            this.id_client = Client.id_client;
            this.id_izdelia = Izdelie.id_izdelia;
            this.Izdelie = Izdelie;
            this.Client = Client;
        }

        [Key]
        public int id_zakaz { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_zakaz { get; set; }

        public int id_client { get; set; }

        public int id_izdelia { get; set; }

        public virtual Client Client { get; set; }

        public virtual Izdelie Izdelie { get; set; }

        public virtual ICollection<Prodaga> Prodaga { get; set; }
    }
}
