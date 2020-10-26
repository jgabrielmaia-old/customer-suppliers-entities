using CompanySupplier.Entity.Model;
using CompanySupplier.Entity.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CompanySupplier.Entity.DAL
{
    public class CompanySupplierContext : DbContext
    {
        public CompanySupplierContext(DbContextOptions<CompanySupplierContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Model.CompanySupplier> CompanySuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.CompanySupplier>()
                .HasKey(cs => new { cs.CompanyId, cs.SupplierId });

            modelBuilder.Entity<Model.CompanySupplier>()
                .HasOne(cs => cs.Company)
                .WithMany(c => c.CompanySuppliers)
                .HasForeignKey(cs => cs.CompanyId);

            modelBuilder.Entity<Model.CompanySupplier>()
                .HasOne(cs => cs.Supplier)
                .WithMany(s => s.CompanySuppliers)
                .HasForeignKey(cs => cs.SupplierId);


            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<Company>().HasOne(c => c.FederativeUnit);
            modelBuilder.Entity<Company>().HasOne(c => c.Document);

            modelBuilder.Entity<Supplier>().HasKey(c => c.SupplierId);
            modelBuilder.Entity<Supplier>().HasOne(c => c.Email);
            modelBuilder.Entity<Supplier>().HasOne(c => c.Document);

            modelBuilder.Entity<Document>().Property<int>("Id").IsRequired();
            modelBuilder.Entity<Document>().HasKey("Id");

            modelBuilder.Entity<FederativeUnit>().Property<int>("Id").IsRequired();
            modelBuilder.Entity<FederativeUnit>().HasKey("Id");

            modelBuilder.Entity<Email>().Property<int>("Id").IsRequired();
            modelBuilder.Entity<Email>().HasKey("Id");
        }
    }
}