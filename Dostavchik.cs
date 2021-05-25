namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dostavchik")]
    public partial class Dostavchik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dostavchik()
        {
            Dostavka = new HashSet<Dostavka>();
        }

        [Key]
        public int id_dostavchika { get; set; }

        [Required]
        [StringLength(100)]
        public string pasport_dat { get; set; }

        public double zarplata { get; set; }

        public double nalog { get; set; }

        [StringLength(10)]
        public string grafik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostavka> Dostavka { get; set; }
    }
}
