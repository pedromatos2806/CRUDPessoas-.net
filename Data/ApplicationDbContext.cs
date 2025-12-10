using CRUDPessoasTeste.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUDPessoasTeste.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Pessoa> Pessoas { get; set; } = default!;
    public DbSet<Funcionario> Funcionarios { get; set; } = default!;
}
