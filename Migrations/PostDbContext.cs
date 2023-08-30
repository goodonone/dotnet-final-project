using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Migrations;

public class PostDbContext : DbContext 
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
public PostDbContext(DbContextOptions<PostDbContext> options)
    : base(options)
{

}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    // modelBuilder.Entity<User>().ToTable("Users");
    // modelBuilder.Entity<Post>().ToTable("Posts");

    // modelBuilder.Entity<User>()
    //    .HasMany(u => u.Posts).Map(m =>
    //         {
    //             m.ToTable("aspnet_Users-Posts");
    //             m.MapLeftKey("UserId");
    //             m.MapRightKey("PostId");
    //         });

    modelBuilder.Entity<Post>(entity =>
    {
        entity.HasKey(e => e.PostId);
        // entity.Property(e => e.PostId).ValueGeneratedOnAdd();
        entity.Property(e => e.Chirp).IsRequired();
        entity.Property(e => e.ChirpDate).ValueGeneratedOnAdd();
        entity.Property(e => e.UserId).ValueGeneratedOnAdd();
    });

modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
        entity.Property(e => e.FirstName).IsRequired();
        entity.Property(e => e.LastName).IsRequired();
        entity.HasIndex(e => e.UserName).IsUnique();
        entity.Property(e => e.Email).IsRequired();
        entity.Property(e => e.City).IsRequired();
        entity.Property(e => e.State).IsRequired();
        entity.Property(e => e.ZipCode).IsRequired();
        entity.Property(e => e.MemberSince).ValueGeneratedOnAdd();
        entity.Property(e => e.Password).IsRequired();
        });

}
}
