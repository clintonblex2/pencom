using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    public partial class PFAContext : DbContext
    {
        public PFAContext()
        {
        }

        public PFAContext(DbContextOptions<PFAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeesRecapture> EmployeesRecapture { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.0.2.10\\poc;Initial Catalog=PFA;User ID=mpin;Password=%multiple123%");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesRecapture>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EMPLOYEES_RECAPTURE");

                entity.Property(e => e.Transid)
                    .HasColumnName("TRANSID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Approved).HasColumnName("APPROVED");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("APPROVED_BY")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("APPROVED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("BRANCH_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Bvn)
                    .HasColumnName("BVN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Checked)
                    .HasColumnName("CHECKED")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.CheckedBy)
                    .HasColumnName("CHECKED_BY")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.CheckedDate)
                    .HasColumnName("CHECKED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientStatus)
                    .HasColumnName("CLIENT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.CorrespondenceAdds)
                    .HasColumnName("CORRESPONDENCE_ADDS")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CorrespondenceAdds1)
                    .HasColumnName("CORRESPONDENCE_ADDS1")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateConfirmed)
                    .HasColumnName("DATE_CONFIRMED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEmployed)
                    .HasColumnName("DATE_EMPLOYED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DATE_OF_BIRTH")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfFirstApppoinment)
                    .HasColumnName("DATE_OF_FIRST_APPPOINMENT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email1)
                    .HasColumnName("EMAIL1")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EMPLOYEE_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerAddress)
                    .HasColumnName("EMPLOYER_ADDRESS")
                    .HasMaxLength(197)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerAddress1)
                    .HasColumnName("EMPLOYER_ADDRESS1")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerBox)
                    .HasColumnName("EMPLOYER_BOX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerBusiness)
                    .HasColumnName("EMPLOYER_BUSINESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerCity)
                    .HasColumnName("EMPLOYER_CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerCountry)
                    .HasColumnName("EMPLOYER_COUNTRY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerLga)
                    .HasColumnName("EMPLOYER_LGA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerLocation)
                    .HasColumnName("EMPLOYER_LOCATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmployerName)
                    .HasColumnName("EMPLOYER_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerPhone)
                    .HasColumnName("EMPLOYER_PHONE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerRcno)
                    .HasColumnName("EMPLOYER_RCNO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerStatecode)
                    .HasColumnName("EMPLOYER_STATECODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerType)
                    .HasColumnName("EMPLOYER_TYPE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmployerZip)
                    .HasColumnName("EMPLOYER_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormRefno)
                    .HasColumnName("FORM_REFNO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LgaCode)
                    .HasColumnName("LGA_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaidenName)
                    .HasColumnName("MAIDEN_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusCode)
                    .HasColumnName("MARITAL_STATUS_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("MOBILE_PHONE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone1)
                    .HasColumnName("MOBILE_PHONE1")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityCode)
                    .HasColumnName("NATIONALITY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.No2kBox)
                    .HasColumnName("NO2K_BOX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Address)
                    .HasColumnName("NOK2_ADDRESS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Address1)
                    .HasColumnName("NOK2_ADDRESS1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2City)
                    .HasColumnName("NOK2_CITY")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Countrycode)
                    .HasColumnName("NOK2_COUNTRYCODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Emailaddress)
                    .HasColumnName("NOK2_EMAILADDRESS")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Firstname)
                    .HasColumnName("NOK2_FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Gender)
                    .HasColumnName("NOK2_GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nok2Lga)
                    .HasColumnName("NOK2_LGA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Location)
                    .HasColumnName("NOK2_LOCATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nok2Maidenname)
                    .HasColumnName("NOK2_MAIDENNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Mobilephone)
                    .HasColumnName("NOK2_MOBILEPHONE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Othername)
                    .HasColumnName("NOK2_OTHERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Relationship)
                    .HasColumnName("NOK2_RELATIONSHIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Statecode)
                    .HasColumnName("NOK2_STATECODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Surname)
                    .HasColumnName("NOK2_SURNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Title)
                    .HasColumnName("NOK2_TITLE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nok2Zip)
                    .HasColumnName("NOK2_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NokAddress)
                    .HasColumnName("NOK_ADDRESS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NokAddress1)
                    .HasColumnName("NOK_ADDRESS1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NokBox)
                    .HasColumnName("NOK_BOX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NokCity)
                    .HasColumnName("NOK_CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NokCountry)
                    .HasColumnName("NOK_COUNTRY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NokDob)
                    .HasColumnName("NOK_DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.NokDob2)
                    .HasColumnName("NOK_DOB2")
                    .HasColumnType("datetime");

                entity.Property(e => e.NokEmailaddress)
                    .HasColumnName("NOK_EMAILADDRESS")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NokGender)
                    .HasColumnName("NOK_GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NokLga)
                    .HasColumnName("NOK_LGA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NokLocation)
                    .HasColumnName("NOK_LOCATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NokMaidenname)
                    .HasColumnName("NOK_MAIDENNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NokMobilePhone)
                    .HasColumnName("NOK_MOBILE_PHONE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NokName)
                    .HasColumnName("NOK_NAME")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NokOthername)
                    .HasColumnName("NOK_OTHERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NokRelationship)
                    .HasColumnName("NOK_RELATIONSHIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NokStatecode)
                    .HasColumnName("NOK_STATECODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NokSurname)
                    .HasColumnName("NOK_SURNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NokTitle)
                    .HasColumnName("NOK_TITLE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NokZip)
                    .HasColumnName("NOK_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Othernames)
                    .HasColumnName("OTHERNAMES")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermBox)
                    .HasColumnName("PERM_BOX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermCity)
                    .HasColumnName("PERM_CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermCountry)
                    .HasColumnName("PERM_COUNTRY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PermLga)
                    .HasColumnName("PERM_LGA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PermState)
                    .HasColumnName("PERM_STATE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PermZip)
                    .HasColumnName("PERM_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress)
                    .HasColumnName("PERMANENT_ADDRESS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress1)
                    .HasColumnName("PERMANENT_ADDRESS1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddressLocation)
                    .HasColumnName("PERMANENT_ADDRESS_LOCATION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasColumnName("PIN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceOfBirth)
                    .HasColumnName("PLACE_OF_BIRTH")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RsaStatus)
                    .HasColumnName("RSA_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateOfOrigin)
                    .HasColumnName("STATE_OF_ORIGIN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateOfPosting)
                    .HasColumnName("STATE_OF_POSTING")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("SURNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasColumnType("decimal(10, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
