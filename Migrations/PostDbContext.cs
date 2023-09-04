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
      

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId);
            entity.Property(e => e.Chirp);
            entity.Property(e => e.ChirpDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(e => e.UserId);
                    entity.Property(e => e.FirstName).IsRequired();
                    entity.Property(e => e.LastName).IsRequired();
                    entity.HasIndex(x => x.UserName).IsUnique();
                    entity.Property(e => e.Email).IsRequired();
                    entity.Property(e => e.City).IsRequired();
                    entity.Property(e => e.State).IsRequired();
                    entity.Property(e => e.ZipCode).IsRequired();
                    entity.Property(e => e.MemberSince).ValueGeneratedOnAdd();
                    entity.Property(e => e.Password).IsRequired();
                    entity.Property(e => e.PhotoURL);
                });

    }
}

