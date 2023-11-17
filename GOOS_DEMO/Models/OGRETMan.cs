namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OGRETMEN")]
    public partial class OGRETMan
    {
        [Key]
        public int OGRETMEN_ID { get; set; }

        public bool OGRETMEN_CINSIYET { get; set; }

        [Required]
        [StringLength(100)]
        public string OGRETMEN_ADI { get; set; }

        [Required]
        [StringLength(100)]
        public string OGRETMEN_SOYADI { get; set; }

        public int? OGRETMEN_K_ID { get; set; }

        public int? OGRETMEN_ILETISIM_ID { get; set; }

        public int? OGRETMEN_BRANS_ID { get; set; }

        public virtual BRAN BRAN { get; set; }

        public virtual ILETISIM ILETISIM { get; set; }

        public virtual KULLANICI KULLANICI { get; set; }
    }
}
