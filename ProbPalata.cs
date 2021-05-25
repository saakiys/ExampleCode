namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProbPalata")]
    public partial class ProbPalata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProbPalata()
        {
            Izdelie = new HashSet<Izdelie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_prob_palate { get; set; }

        public double nalog { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_ucheta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izdelie> Izdelie { get; set; }
    }
}
