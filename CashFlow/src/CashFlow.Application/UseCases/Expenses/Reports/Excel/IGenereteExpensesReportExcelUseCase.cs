namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public interface IGenereteExpensesReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
