namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Izgotovlenie")]
    public partial class Izgotovlenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Izgotovlenie()
        {
            Sdacha = new HashSet<Sdacha>();
            Vydacha = new HashSet<Vydacha>();
        }

        [Key]
        public int id_izgot { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_start { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_end { get; set; }

        public int id_izdelia { get; set; }

        public int id_sotr { get; set; }

        public string prov_rabota { get; set; }

        public virtual Izdelie Izdelie { get; set; }

        public virtual Sotrudnik Sotrudnik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sdacha> Sdacha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vydacha> Vydacha { get; set; }
    }
}
