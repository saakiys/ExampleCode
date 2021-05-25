namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sotrudnik")]
    public partial class Sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnik()
        {
            Izgotovlenie = new HashSet<Izgotovlenie>();
        }

        [Key]
        public int id_sotr { get; set; }

        [Required]
        [StringLength(100)]
        public string FIO { get; set; }

        [Required]
        [StringLength(20)]
        public string login { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        public string pasport_dat { get; set; }

        public double zarplata { get; set; }

        [StringLength(10)]
        public string grafik { get; set; }

        public short? skill { get; set; }

        public double nalog { get; set; }

        public int id_oborud { get; set; }

        public int id_masters { get; set; }

        public int? work_hours { get; set; }

        [StringLength(50)]
        public string special { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izgotovlenie> Izgotovlenie { get; set; }
    }
}
