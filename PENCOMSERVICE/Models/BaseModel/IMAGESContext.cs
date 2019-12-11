using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    public partial class IMAGESContext : DbContext
    {
        public IMAGESContext()
        {
        }

        public IMAGESContext(DbContextOptions<IMAGESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeImagesRecapture> EmployeeImagesRecapture { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.0.2.10\\poc;Initial Catalog=PFAIMAGES;User ID=mpin;Password=%multiple123%");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeImagesRecapture>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EMPLOYEE_IMAGES_RECAPTURE");

                entity.Property(e => e.Transid)
                    .HasColumnName("TRANSID")
                    .HasColumnType("decimal(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvestorId)
                    .HasColumnName("INVESTOR_ID")
                    .HasColumnType("decimal(20, 0)");

                entity.Property(e => e.PictureImage)
                    .HasColumnName("PICTURE_IMAGE")
                    .HasColumnType("image");

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasColumnName("PIN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationCode)
                    .IsRequired()
                    .HasColumnName("REGISTRATION_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SignatureImage)
                    .HasColumnName("SIGNATURE_IMAGE")
                    .HasColumnType("image");

                entity.Property(e => e.Thumbprint)
                    .HasColumnName("THUMBPRINT")
                    .HasColumnType("image");

                entity.Property(e => e.Thumbprint1)
                    .HasColumnName("THUMBPRINT1")
                    .HasColumnType("image");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
