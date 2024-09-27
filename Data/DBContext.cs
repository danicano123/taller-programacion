using Microsoft.EntityFrameworkCore;
using taller_programacion.Domain.Clients.Models;
using taller_programacion.Domain.Companies.Models;
using taller_programacion.Domain.Invoices.Models;
using taller_programacion.Domain.NormativeAspects.Models;
using taller_programacion.Domain.Products.Models;
using taller_programacion.Domain.Sellers.Models;
using taller_programacion.Domain.Common.Models;
using taller_programacion.Domain.InvoiceProducts.Models;

namespace taller_programacion.Data;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{
    public DbSet<NormativeAspect> NormativeAspects { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<InvoiceProduct> InvoiceProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Persons");

        modelBuilder.Entity<Client>()
            .ToTable("Clients")
            .HasBaseType<Person>();

        modelBuilder.Entity<Seller>()
            .ToTable("Sellers")
            .HasBaseType<Person>();

        modelBuilder.Entity<InvoiceProduct>()
            .ToTable("InvoiceProducts")
            .HasOne(ip => ip.Invoice)
            .WithMany() 
            .HasForeignKey(ip => ip.InvoiceId);

        modelBuilder.Entity<InvoiceProduct>()
            .HasOne(ip => ip.Product)
            .WithMany()
            .HasForeignKey(ip => ip.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
