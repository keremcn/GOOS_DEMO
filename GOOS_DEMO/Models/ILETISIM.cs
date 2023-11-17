namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ILETISIM")]
    public partial class ILETISIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ILETISIM()
        {
            OGRENCIs = new HashSet<OGRENCI>();
            OGRETMEN = new HashSet<OGRETMan>();
        }

        [Key]
        public int ILET_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string ILET_ADRES { get; set; }

        [StringLength(200)]
        public string ILET_EV_TEL { get; set; }

        [Required]
        [StringLength(200)]
        public string ILET_CEP_TEL { get; set; }

        [Required]
        [StringLength(200)]
        public string ILET_EPOSTA { get; set; }

        public int? ILET_IL_ID { get; set; }

        public int? ILET_ILCE_ID { get; set; }

        public virtual IL IL { get; set; }

        public virtual ILCE ILCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OGRENCI> OGRENCIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OGRETMan> OGRETMEN { get; set; }
    }
}
