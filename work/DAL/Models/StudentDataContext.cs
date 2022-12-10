using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class StudentDataContext : DbContext
    {
        public StudentDataContext()
        {
        }

        public StudentDataContext(DbContextOptions<StudentDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alogin> Alogin { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentData;Trusted_Connection=True;");
            }
        }


        public static bool ufn_ValidateUserCredentials(string email, string password)
        {
            return false;
        }
        public static long ufn_maxsci()
        {
            long a = 0;
            return a;
        }
        public static long ufn_maxmaths()
        {
            long a = 0;
            return a;
        }
        public static long ufn_maxeng()
        {
            long a = 0;
            return a;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => StudentDataContext.ufn_maxeng());
            modelBuilder.HasDbFunction(() => StudentDataContext.ufn_maxmaths());
            modelBuilder.HasDbFunction(()=> StudentDataContext.ufn_maxsci());
            modelBuilder.HasDbFunction(() => StudentDataContext.ufn_ValidateUserCredentials(default, default(String)));
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Alogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ALogin__1788CCAC77B173A2");

                entity.ToTable("ALogin");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MarksAverage)
                    .HasColumnName("Marks_Average")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SmAverage)
                    .HasColumnName("SM_Average")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.RollNoNavigation)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.RollNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RNo");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RollNo)
                    .HasName("PK__Student__7886D5A050301436");

                entity.Property(e => e.RollNo).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFname)
                    .IsRequired()
                    .HasColumnName("StudentFName")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.StudentLname)
                    .IsRequired()
                    .HasColumnName("StudentLName")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private static object ufn_maxsci(object year)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
