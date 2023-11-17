namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KULLANICI_TURU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KULLANICI_TURU()
        {
            KULLANICIs = new HashSet<KULLANICI>();
        }

        [Key]
        public int KT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string KT_ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KULLANICI> KULLANICIs { get; set; }
    }
}
