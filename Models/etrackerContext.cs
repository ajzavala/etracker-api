using System;
using etracker_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace etracker_api.Models
{
    public partial class etrackerContext : DbContext
    {
        public etrackerContext()
        {
        }

        public etrackerContext(DbContextOptions<etrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<ExpenseHistory> ExpenseHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SpExpenseDetails> ExpenseDetails { get; set; }
        public virtual DbSet<SpGraphData> GraphDatas { get; set; }
        public virtual DbSet<SpValidateData> ValidateDatas { get; set; }
        public virtual DbSet<Login> LoginInfo { get; set; }



        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("server=.\\sqlexpress; database=etracker; user=sa; password=Io3TeamGAAJ2019");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpExpenseDetails>().HasNoKey();
            modelBuilder.Entity<Login>().HasNoKey();

            modelBuilder.Entity<SpGraphData>().HasNoKey();
            modelBuilder.Entity<SpValidateData>().HasNoKey();

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.ToTable("expenseCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlarmThreshold).HasColumnName("alarm_threshold");

                entity.Property(e => e.Budget)
                    .HasColumnName("budget")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ExpenseDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("expenseDetail");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.ExpenseDate)
                    .HasColumnName("expense_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseHistory>(entity =>
            {
                entity.ToTable("expenseHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.ExpenseCategoryId).HasColumnName("expense_category_id");

                entity.Property(e => e.ExpenseDate)
                    .HasColumnName("expense_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
