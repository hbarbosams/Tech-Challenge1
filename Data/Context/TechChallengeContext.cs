using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.Context;

public class TechChallengeContext : DbContext
{
    public TechChallengeContext(DbContextOptions<TechChallengeContext> options) : base(options) { }

    public DbSet<Regiao> Regiao { get; set; }
    public DbSet<Estado> Estado { get; set; }
    public DbSet<FoneDdd> FoneDdd { get; set; }
    public DbSet<Contato> Contato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}