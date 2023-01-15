using FinanceApplicationAPI.Data.Models;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApplicationAPI.DataAccess.Context
{
    public class APIDBContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) 
        {
        }

        // Updated this to 3NF to avoid ickiness
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(e => e.AccountID);

                entity.Property(e => e.AccountID)
                      .HasColumnName("ID")
                      .HasColumnType("varchar")
                      .HasMaxLength(36);

                entity.Property(e => e.AccountName)
                        .HasColumnName("UserName")
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                entity.HasMany(t => t.Transactions)
                    .WithOne(a => a.Account)
                    .HasForeignKey(x => x.AccountID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Account_Transactions");

            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.Property(e => e.TransactionID)
                    .HasColumnName("ID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime")
                    .HasMaxLength(50);

                entity.Property(e => e.FlowType)
                   .HasColumnName("FlowType")
                   .HasColumnType("integer")
                   .HasMaxLength(1);

                entity.Property(e => e.Amount)
                    .HasColumnName("Amount")
                    .HasColumnType("integer")
                    .HasMaxLength(20);

                entity.Property(e => e.TransactionNameID)
                    .HasColumnName("TransactionNameID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.TransactionTypeID)
                    .HasColumnName("TransactionTypeID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.AccountID)
                    .HasColumnName("AccountID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.HasOne(t => t.TransactionName)
                     .WithMany(t => t.Transactions)
                     .HasForeignKey(x => x.TransactionNameID)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK_Transaction_Name");

                entity.HasOne(t => t.TransactionType)
                    .WithMany(t => t.Transactions)
                    .HasForeignKey(x => x.TransactionTypeID)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Transaction_Type");
            });

            modelBuilder.Entity<TransactionName>(entity =>
            {
                entity.ToTable("TransactionName");

                entity.Property(e => e.TransactionNameID)
                    .HasColumnName("ID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.TransactionTypeID)
                    .HasColumnName("ID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.Type)
                    .HasColumnName("Type")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            });
        }
    }
}
