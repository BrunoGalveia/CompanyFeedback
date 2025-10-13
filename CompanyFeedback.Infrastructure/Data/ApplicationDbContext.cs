using CompanyFeedback.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyFeedback.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=CompanyFeedback;Trusted_Connection=True;TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name)
                .IsUnique();
            
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Feedbacks)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(x => x.Interview)
                .WithOne(x => x.Feedback)
                .HasForeignKey<Feedback>(x => x.InterviewId)
                .HasPrincipalKey<Interview>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(x => x.Salary)
                .WithOne(x => x.Feedback)
                .HasForeignKey<Feedback>(x => x.SalaryId)
                .HasPrincipalKey<Salary>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
