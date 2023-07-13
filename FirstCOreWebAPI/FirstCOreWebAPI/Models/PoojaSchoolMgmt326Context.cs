using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstCOreWebAPI.Models;

public partial class PoojaSchoolMgmt326Context : DbContext
{
    public PoojaSchoolMgmt326Context()
    {
    }

    public PoojaSchoolMgmt326Context(DbContextOptions<PoojaSchoolMgmt326Context> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CouponCodeMaster> CouponCodeMasters { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<User1> Users1 { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=192.168.1.88;initial catalog=Pooja_SchoolMgmt_326;user id=sa;password=Sit@321#;Integrated Security=False;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CiId).HasName("PK__City__AEC2FF5197EAE8E2");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Co).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CoId)
                .HasConstraintName("FK__City__StId__36B12243");

            entity.HasOne(d => d.St).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StId)
                .HasConstraintName("FK__City__StId__37A5467C");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CoId).HasName("PK__Country__A25F3E2BD5A6D175");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CouponCodeMaster>(entity =>
        {
            entity.HasKey(e => e.CouponIcoded).HasName("PK__CouponCo__5858D7AC86C68CCF");

            entity.ToTable("CouponCodeMaster");

            entity.Property(e => e.CouponIcoded).HasColumnName("CouponICoded");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__ItemMast__727E838B79818667");

            entity.ToTable("ItemMaster");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Dopo)
                .HasColumnType("date")
                .HasColumnName("DOPO");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Coupon).WithMany(p => p.ItemMasters)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__ItemMaste__Coupo__6D0D32F4");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StId).HasName("PK__States__C33CEFC28B30CE3F");

            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Co).WithMany(p => p.States)
                .HasForeignKey(d => d.CoId)
                .HasConstraintName("FK__States__CoId__33D4B598");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Student__CA195950306C608D");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Email, "UQ__Student__A9D1053485C85717").IsUnique();

            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeacherId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Students)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Student__CityId__3A81B327");

            entity.HasOne(d => d.Country).WithMany(p => p.Students)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Student__Country__38996AB5");

            entity.HasOne(d => d.State).WithMany(p => p.Students)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Student__StateId__398D8EEE");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK__Subjects__4D9BB84AF9C13686");

            entity.HasIndex(e => e.SubjectName, "UQ__Subjects__4C5A7D552B7EA144").IsUnique();

            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TecId).HasName("PK__Teachers__599E7F25A0F64030");

            entity.HasIndex(e => e.Email, "UQ__Teachers__A9D10534E593CDB4").IsUnique();

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Teachers__CityId__403A8C7D");

            entity.HasOne(d => d.Country).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Teachers__Countr__3B75D760");

            entity.HasOne(d => d.State).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Teachers__StateI__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07EE546DA6");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534F9462F83").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07ECA5689F");

            entity.ToTable("Users");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348DD873E3").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
