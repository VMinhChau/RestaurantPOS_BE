using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data.Configurations;
using RestaurantPOS.Data.Entities;

namespace RestaurantPOS.Data
{
    public class RestaurantDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteFoodConfiguration());
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTableConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillDetailConfiguration());
        }

        public DbSet<Table> Table { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<FavoriteFood> FavoriteFood { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<OrderTable> OderTable { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
    }
}
