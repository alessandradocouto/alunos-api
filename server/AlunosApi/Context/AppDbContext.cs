using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context;

public class AppDbContext : DbContext
{
    public DbSet<Aluno> Aluno { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno { 
                Id = 1, 
                Name = "Maria Da Penha", 
                Email = "mariapenha@gmail.com", 
                Age = 23,
                CreatedAt = DateTime.Now
            },
            new Aluno
            {
                Id = 2,
                Name = "Zé Federico",
                Email = "zefederico@hotmail.com",
                Age = 47,
                CreatedAt = DateTime.Now
            }
        );
    }
}
