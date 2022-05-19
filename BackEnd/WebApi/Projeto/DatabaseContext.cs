using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Cidade> cidade { get; set;}

        public DbSet<Pessoa> pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=Projeto; Trusted_Connection = true");

        }
    }
}
