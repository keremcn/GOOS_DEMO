using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GOOS_DEMO.Models
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<BRAN> BRANS { get; set; }
        public virtual DbSet<IL> ILs { get; set; }
        public virtual DbSet<ILCE> ILCEs { get; set; }
        public virtual DbSet<ILETISIM> ILETISIMs { get; set; }
        public virtual DbSet<KULLANICI> KULLANICIs { get; set; }
        public virtual DbSet<KULLANICI_TURU> KULLANICI_TURU { get; set; }
        public virtual DbSet<MESLEK> MESLEKs { get; set; }
        public virtual DbSet<OGRENCI> OGRENCIs { get; set; }
        public virtual DbSet<OGRETMan> OGRETMEN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BRAN>()
                .Property(e => e.B_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<BRAN>()
                .HasMany(e => e.OGRETMEN)
                .WithOptional(e => e.BRAN)
                .HasForeignKey(e => e.OGRETMEN_BRANS_ID);

            modelBuilder.Entity<IL>()
                .Property(e => e.I_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.ILCEs)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.IC_IL_ID);

            modelBuilder.Entity<IL>()
                .HasMany(e => e.ILETISIMs)
                .WithOptional(e => e.IL)
                .HasForeignKey(e => e.ILET_IL_ID);

            modelBuilder.Entity<ILCE>()
                .Property(e => e.IC_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<ILCE>()
                .HasMany(e => e.ILETISIMs)
                .WithOptional(e => e.ILCE)
                .HasForeignKey(e => e.ILET_ILCE_ID);

            modelBuilder.Entity<ILETISIM>()
                .Property(e => e.ILET_ADRES)
                .IsUnicode(false);

            modelBuilder.Entity<ILETISIM>()
                .Property(e => e.ILET_EV_TEL)
                .IsUnicode(false);

            modelBuilder.Entity<ILETISIM>()
                .Property(e => e.ILET_CEP_TEL)
                .IsUnicode(false);

            modelBuilder.Entity<ILETISIM>()
                .Property(e => e.ILET_EPOSTA)
                .IsUnicode(false);

            modelBuilder.Entity<ILETISIM>()
                .HasMany(e => e.OGRENCIs)
                .WithOptional(e => e.ILETISIM)
                .HasForeignKey(e => e.OGRENCI_ILETISIM_ID);

            modelBuilder.Entity<ILETISIM>()
                .HasMany(e => e.OGRETMEN)
                .WithOptional(e => e.ILETISIM)
                .HasForeignKey(e => e.OGRETMEN_ILETISIM_ID);

            modelBuilder.Entity<KULLANICI>()
                .Property(e => e.K_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<KULLANICI>()
                .Property(e => e.K_PAROLA)
                .IsUnicode(false);

            modelBuilder.Entity<KULLANICI>()
                .HasMany(e => e.OGRENCIs)
                .WithOptional(e => e.KULLANICI)
                .HasForeignKey(e => e.OGRENCI_K_ID);

            modelBuilder.Entity<KULLANICI>()
                .HasMany(e => e.OGRETMEN)
                .WithOptional(e => e.KULLANICI)
                .HasForeignKey(e => e.OGRETMEN_K_ID);

            modelBuilder.Entity<KULLANICI_TURU>()
                .Property(e => e.KT_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<KULLANICI_TURU>()
                .HasMany(e => e.KULLANICIs)
                .WithOptional(e => e.KULLANICI_TURU)
                .HasForeignKey(e => e.K_TURU_ID);

            modelBuilder.Entity<MESLEK>()
                .Property(e => e.M_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<OGRENCI>()
                .Property(e => e.OGRENCI_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<OGRENCI>()
                .Property(e => e.OGRENCI_SOYADI)
                .IsUnicode(false);

            modelBuilder.Entity<OGRETMan>()
                .Property(e => e.OGRETMEN_ADI)
                .IsUnicode(false);

            modelBuilder.Entity<OGRETMan>()
                .Property(e => e.OGRETMEN_SOYADI)
                .IsUnicode(false);
        }
    }
}
