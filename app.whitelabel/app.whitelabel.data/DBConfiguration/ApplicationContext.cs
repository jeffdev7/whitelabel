using app.whitelabel.Entities;
using app.whitelabel.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.whitelabel.data.DBConfiguration
{
    public interface IAppDbContext { }
    public class ApplicationContext : IdentityDbContext<ApplicationUser>, IAppDbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>()
                .HasKey(_ => _.Id);

            builder.Entity<Customer>()
                .HasKey(_ => _.Id);
            builder.Entity<Customer>()
                .HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.CustomerId);

            builder.Entity<Order>()
                .HasKey(_ => _.Id);
            builder.Entity<Order>()
                .HasMany(_ => _.Items)
                .WithOne(_ => _.Order);
            builder.Entity<Order>()
                .HasOne(_ => _.Customer)
                .WithMany(_ => _.Orders);

            builder.Entity<ItemOrder>()
                .HasKey(_ => _.Id);
            builder.Entity<ItemOrder>()
                .HasOne(_ => _.Order);
            builder.Entity<ItemOrder>()
                .HasOne(_ => _.Pizza);

            base.OnModelCreating(builder);
        }
        public ApplicationContext() { }
    }
}