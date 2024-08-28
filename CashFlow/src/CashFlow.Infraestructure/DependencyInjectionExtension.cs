using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infraestructure.DataAccess;
using CashFlow.Infraestructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infraestructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraestructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<CashFlowDbContext>();
        }
    }
}
