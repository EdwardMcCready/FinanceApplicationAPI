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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(e => e.AccountID);

                entity.Property(e => e.AccountID)
                      .HasColumnName("AccountID")
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
                    .HasColumnName("TransactionID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.TransactionType)
                    .HasColumnName("TransactionType")
                    .HasColumnType("integer")
                    .HasMaxLength(1);

                entity.Property(e => e.Type)
                    .HasColumnName("Type")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.Amount)
                    .HasColumnName("Amount")
                    .HasColumnType("integer")
                     .HasMaxLength(20);

                entity.Property(e => e.AccountID)
                    .HasColumnName("AccountID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);
            });
        }
    }
}
