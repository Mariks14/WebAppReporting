using Microsoft.EntityFrameworkCore;
using System.IO;
using WebAppReporting.Models.EFModels;

namespace WebAppReporting.Models.EFContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Expense> Expense { get; set; } = null!;


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //
        //}
    }
}
