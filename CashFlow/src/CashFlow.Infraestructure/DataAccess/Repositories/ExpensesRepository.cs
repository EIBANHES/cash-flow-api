using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesWriteOnlyRepository, IExpensesReadOnlyRepository, IExpensesUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
            {
                return false;
            }

            _dbContext.Expenses.Remove(result);
            return true;
        }

        public async Task<List<Expense>> GetAll()
        {
            // AsNoTracking, sempre antes de uma consulta, nao fica monitorando e n salva info em cache
            return await _dbContext.Expenses.AsNoTracking().ToListAsync();
        }

        async Task<Expense?> IExpensesReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }
        public void Update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }
    }
}