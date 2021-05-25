namespace proga
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sdacha")]
    public partial class Sdacha
    {
        [Key]
        public int id_sdal { get; set; }

        public double colvo_mat { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_s { get; set; }

        public int id_izgot { get; set; }

        public int id_material { get; set; }

        public virtual Izgotovlenie Izgotovlenie { get; set; }

        public virtual Material Material { get; set; }
    }
}
