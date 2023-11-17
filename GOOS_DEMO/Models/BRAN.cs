namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BRANS")]
    public partial class BRAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BRAN()
        {
            OGRETMEN = new HashSet<OGRETMan>();
        }

        [Key]
        public int B_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string B_ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OGRETMan> OGRETMEN { get; set; }
    }
}
