namespace GOOS_DEMO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("KULLANICI")]
    public partial class KULLANICI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KULLANICI()
        {
            OGRENCIs = new HashSet<OGRENCI>();
            OGRETMEN = new HashSet<OGRETMan>();
        }

        [Key]
        public int K_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string K_ADI { get; set; }

        [Required]
        [StringLength(50)]
        public string K_PAROLA { get; set; }

        public bool K_DURUMU { get; set; }

        public int? K_TURU_ID { get; set; }

        public virtual KULLANICI_TURU KULLANICI_TURU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OGRENCI> OGRENCIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OGRETMan> OGRETMEN { get; set; }


        public static bool Giris(KULLANICI kmodel)
        {
            bool sonuc = false;
            try
            {
                using (var contex = new AppDBContext())
                {
                    var model = contex.KULLANICIs.FirstOrDefaultAsync(k => k.K_ADI == kmodel.K_ADI && kmodel.K_PAROLA == k.K_PAROLA);
                    if (model != null) sonuc = true;

                }
            }
            catch (Exception)
            {
             
            }
            return sonuc;

        }
    }
}
