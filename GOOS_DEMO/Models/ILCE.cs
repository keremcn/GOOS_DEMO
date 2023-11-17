namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILCE")]
    public partial class ILCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILCE()
        {
            ILETISIMs = new HashSet<ILETISIM>();
        }

        [Key]
        public int IC_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string IC_ADI { get; set; }

        public int? IC_IL_ID { get; set; }

        public virtual IL IL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILETISIM> ILETISIMs { get; set; }
    }
}
