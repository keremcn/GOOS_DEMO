namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESLEK")]
    public partial class MESLEK
    {
        [Key]
        public int M_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string M_ADI { get; set; }
    }
}
