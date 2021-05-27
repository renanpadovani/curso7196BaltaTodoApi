using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        //Boa pratica, declarar construtor
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160);
            modelBuilder.Entity<TodoItem>().Property(x => x.Done);
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}