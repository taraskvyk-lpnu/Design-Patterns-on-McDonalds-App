using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.EmployeeFacade;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class McDonaldsDbContext : DbContext
    {
        public static McDonaldsDbContext Context { get; private set; }
        
        public McDonaldsDbContext(DbContextOptions<McDonaldsDbContext> options) : base(options)
        {
            Context = this;
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Burger> Burger { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<SideDish> SideDishes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Type>();
            
            modelBuilder.Entity<Burger>()
                .HasOne(b => b.Category)
                .WithMany()
                .HasForeignKey(b => b.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Drink>()
                .HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId)
                .IsRequired();
            
            modelBuilder.Entity<SideDish>()
                .HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId)
                .IsRequired();
        }

        public override void Dispose()
        {
            
        }
    }
}
