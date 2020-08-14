using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pos.Domain.Entities;

namespace Pos.Domain.Infrastructure
{
    public class PosContext : IdentityDbContext<ApplicationUser>
    {
        public PosContext()
        {

        }
        public PosContext(DbContextOptions<PosContext> options)
            : base(options)
        {

        }
        public static PosContext CreateContext(int tenantId)
        {
            var context = new PosContext();
            if (tenantId == 0) return context;
            return context;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductProperty>().HasKey(c => new { c.ProductId, c.PropertyId });
            modelBuilder.Entity<Stock>().HasKey(c => new { c.ProductId, c.PointId });
            modelBuilder.Entity<CategoryUnit>().HasKey(c => new { c.CategoryId, c.UnitId });
            modelBuilder.Entity<CategoryProperty>().HasKey(c => new { c.CategoryId, c.PropertyId });
            modelBuilder.Entity<Transfer>().HasOne(t => t.FromPoint).WithMany(s => s.InTransfares)
                .HasForeignKey(s => s.FromPointId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transfer>().HasOne(t => t.ToPoint).WithMany(s => s.OutTransfares)
                .HasForeignKey(s => s.ToPointId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Installment>().HasOne(i => i.Transaction).WithMany(t => t.Installments)
                .HasForeignKey(t => t.TransactionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TransactionDetailBarcode>().HasOne(i => i.TransactionDetail).WithMany(t => t.Barcodes)
                .HasForeignKey(t => t.TransactionDetailId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<ProductProperty> ProductProperties { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Installment> Installments { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<Transfer> Transfares { get; set; }
        public virtual DbSet<TransferDetail> TransfareDetails { get; set; }
        public virtual DbSet<Damaged> Damaged { get; set; }
        public virtual DbSet<BarCode> BarCodes { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankTransaction>  BankTransactions { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<CategoryUnit> CategoryUnits { get; set; }
        public virtual DbSet<CategoryProperty> CategoryProperties { get; set; }

    }
}
