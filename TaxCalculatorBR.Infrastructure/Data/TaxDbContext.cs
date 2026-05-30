using Microsoft.EntityFrameworkCore;
using TaxCalculatorBR.Infrastructure.Entities;

namespace TaxCalculatorBR.Infrastructure.Data;

public class TaxDbContext : DbContext
{
    public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options) { }

    public DbSet<Aliquota> Aliquotas { get; set; }
}