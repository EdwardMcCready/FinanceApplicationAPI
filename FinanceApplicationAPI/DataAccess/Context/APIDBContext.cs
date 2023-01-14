using FinanceApplicationAPI.Data.Models;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApplicationAPI.DataAccess.Context
{
    public class APIDBContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Users { get; set; }

        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.AccountID);

                entity.Property(e => e.AccountID)
                      .HasColumnName("UserID")
                      .HasColumnType("varchar")
                      .HasMaxLength(36);

                entity.Property(e => e.AccountName)
                        .HasColumnName("UserName")
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

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

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID")
                    .HasColumnType("varchar")
                    .HasMaxLength(36);

                entity.HasOne(t => t.User)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Transactions");
            });
        }
    }
}
