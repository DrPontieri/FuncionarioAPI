using FuncionarioAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioAPI.DataContext
{
    public class FuncionarioDbContext : DbContext
    {
        public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options)
        {
            
        }
        public DbSet<FuncionarioModel> Funcionario {  get; set; }
    }
}
