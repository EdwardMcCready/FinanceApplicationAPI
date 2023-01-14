using FinanceApplicationAPI.Data.Models;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApplicationAPI.DataAccess.Context
{
    public class APIDBContext : DbContext
    {
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserID)
                      .HasMaxLength(36)
                      .HasColumnName("UserID"); ;

                entity.Property(e => e.UserName)
                        .HasMaxLength(50)
                        .HasColumnName("UserName");

            });

            modelBuilder.Entity<TransactionModel>(entity =>
            {
                entity.ToTable("Transactions");

                entity.Property(e => e.Date)
                    .HasMaxLength(50);


                entity.HasOne(t => t.User)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Transactions");
            });
        }
    }
}
