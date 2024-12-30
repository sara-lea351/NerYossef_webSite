using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NerYossefWebsite.Models;

public partial class NerYossefDbContext : DbContext
{
    public NerYossefDbContext()
    {
    }

    public NerYossefDbContext(DbContextOptions<NerYossefDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<Kollel> Kollels { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1M82DEK;Database=NerYossefDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("PK__alert__4B8FB03A52CF477C");

            entity.ToTable("alert");

            entity.Property(e => e.AlertId).HasColumnName("alert_id");
            entity.Property(e => e.AlertBody)
                .HasMaxLength(100)
                .HasColumnName("alert_body");
            entity.Property(e => e.AlertStatus)
                .HasMaxLength(50)
                .HasColumnName("alert_status");
            entity.Property(e => e.AlertType)
                .HasMaxLength(50)
                .HasColumnName("alert_type");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(CONVERT([date],getdate()))")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_person_alert");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.ConfigurationId).HasName("PK__configur__BC79D0A2C28455F6");

            entity.ToTable("configuration");

            entity.Property(e => e.ConfigurationId).HasColumnName("configuration_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.KeyName)
                .HasMaxLength(255)
                .HasColumnName("key_name");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__document__9666E8AC281C0687");

            entity.ToTable("document");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(255)
                .HasColumnName("document_path");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsLast)
                .HasDefaultValue(true)
                .HasColumnName("is_last");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(CONVERT([date],getdate()))")
                .HasColumnName("uploaded_at");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_document_type");

            entity.HasOne(d => d.Person).WithMany(p => p.Documents)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_documents_people");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("PK__document__69F7C2B16F3EAFAF");

            entity.ToTable("document_type");

            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.HasExpiryDate).HasColumnName("has_expiry_date");
            entity.Property(e => e.ExpiryWarningPeriod).HasColumnName("expiry_warning_period");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__group__D57795A0E98F3638");

            entity.ToTable("group");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasColumnName("group_name");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => e.GroupMemberId).HasName("PK__group_me__F3C66B8C858B1EDB");

            entity.ToTable("group_member");

            entity.Property(e => e.GroupMemberId).HasColumnName("group_member_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_group_members");
        });

        modelBuilder.Entity<Kollel>(entity =>
        {
            entity.HasKey(e => e.KollelId).HasName("PK__kollel__6A1BA76AECD7C2F8");

            entity.ToTable("kollel");

            entity.Property(e => e.KollelId).HasColumnName("kollel_id");
            entity.Property(e => e.Donor)
                .HasMaxLength(255)
                .HasColumnName("donor");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Kollels)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_kollel_people");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__person__543848DF81F22D86");

            entity.ToTable("person");

            entity.HasIndex(e => e.NumberId, "UQ__person__4BE613D21BE035CB").IsUnique();

            entity.HasIndex(e => e.PassportNumber, "UQ__person__D2CA62993B89953A").IsUnique();

            entity.HasIndex(p => new { p.NumberId, p.PassportNumber }).IsUnique().HasName("UQ_NumberId_PassportNumber");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.NumberId)
                .HasMaxLength(20)
                .HasColumnName("number_id");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(20)
                .HasColumnName("passport_number");
            entity.Property(e => e.PersonType)
                .HasMaxLength(50)
                .HasColumnName("person_type");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AE684BEE0");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .HasColumnName("class");
            entity.Property(e => e.EntryDate).HasColumnName("entry_date");
            entity.Property(e => e.ExitDate).HasColumnName("exit_date");
            entity.Property(e => e.FatherMail)
                .HasMaxLength(255)
                .HasColumnName("father_mail");
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .HasColumnName("father_name");
            entity.Property(e => e.FatherPhone)
                .HasMaxLength(15)
                .HasColumnName("father_phone");
            entity.Property(e => e.IsPaymentValid)
                .HasDefaultValue(true)
                .HasColumnName("is_payment_valid");
            entity.Property(e => e.MotherMail)
                .HasMaxLength(255)
                .HasColumnName("mother_mail");
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .HasColumnName("mother_name");
            entity.Property(e => e.MotherPhone)
                .HasMaxLength(15)
                .HasColumnName("mother_phone");
            entity.Property(e => e.Payment)
                .HasMaxLength(50)
                .HasColumnName("payment");
            entity.Property(e => e.PaymentExpiryDate).HasColumnName("payment_expiry_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_student_person");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F875D8BC7");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
