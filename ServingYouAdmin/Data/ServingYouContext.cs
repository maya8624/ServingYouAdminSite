using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ServingYouAdmin.Data
{
    public class ServingYouContext : IdentityDbContext
    {
        public ServingYouContext(DbContextOptions<ServingYouContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }
        public DbSet<MenuPrice> MenuPrice { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // Seed data
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();

            modelBuilder.Entity<Menu>()
                .Property(p => p.Available)
                .HasDefaultValue(true);

            modelBuilder.Entity<State>()                
            .HasKey(s => s.Code);

            modelBuilder.Entity<State>()
                .Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.StateCode)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Employee>()
                .Property(e => e.StateCode)
                .HasColumnName("StateCode")
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<OrderMenu>()                
                .HasOne(om => om.Order)                
                .WithMany(o => o.OrderMenu)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(s => s.State)
                .WithMany(e => e.Employees)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Member)
                .OnDelete(DeleteBehavior.Restrict);
         
            // modelBuilder.Entity<Order>
            //modelBuilder.Entity<Student>()
            //.HasOne<Grade>(s => s.Grade)
            //.WithMany(g => g.Students)
            //.HasForeignKey(s => s.CurrentGradeId);
        }

    }
}
