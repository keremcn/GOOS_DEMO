namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OGRENCI")]
    public partial class OGRENCI
    {
        [Key]
        public int OGRENCI_ID { get; set; }

        public int OGRENCI_NO { get; set; }

        [Required]
        [StringLength(100)]
        public string OGRENCI_ADI { get; set; }

        [Required]
        [StringLength(100)]
        public string OGRENCI_SOYADI { get; set; }

        public int? OGRENCI_K_ID { get; set; }

        public int? OGRENCI_ILETISIM_ID { get; set; }

        public bool OGRENCI_CINSIYET { get; set; }

        public virtual ILETISIM ILETISIM { get; set; }

        public virtual KULLANICI KULLANICI { get; set; }
    }
}
