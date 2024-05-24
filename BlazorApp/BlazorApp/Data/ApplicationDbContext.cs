using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public virtual DbSet<AddressEntity> Addresses { get; set; }
    public virtual DbSet<SavedCourseEntity> SavedCourses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SavedCourseEntity>()
            .HasKey(sc => new { sc.UserId, sc.CourseId });

        modelBuilder.Entity<SavedCourseEntity>()
            .HasOne(sc => sc.User)
            .WithMany(u => u.SavedCourses)
            .HasForeignKey(sc => sc.UserId);


    }
}
