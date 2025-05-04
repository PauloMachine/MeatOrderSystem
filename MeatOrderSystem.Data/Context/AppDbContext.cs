using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<MeatOrigin> MeatOrigins => Set<MeatOrigin>();
    public DbSet<Meat> Meats => Set<Meat>();
    public DbSet<State> States => Set<State>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Buyer> Buyers => Set<Buyer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Price)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Currency)
            .HasMaxLength(3);
    }
}