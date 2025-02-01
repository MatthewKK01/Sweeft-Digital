using Microsoft.EntityFrameworkCore;
using Teacher_api.Models;

namespace Teacher_api;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    
    
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Pupils)
            .WithMany(p => p.Teachers)
            .UsingEntity(j => j.ToTable("TeacherPupil"));
    }
}