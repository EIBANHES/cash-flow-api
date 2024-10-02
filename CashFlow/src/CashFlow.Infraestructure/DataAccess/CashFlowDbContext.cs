using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        // Obtem opções do dbcontext
        public CashFlowDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}