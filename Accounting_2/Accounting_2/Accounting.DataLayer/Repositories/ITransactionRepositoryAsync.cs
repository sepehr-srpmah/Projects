using Accounting.DataLayer.Contexts;
using Accounting.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public partial interface ITransactionRepository : IAccountingRepository<Transaction>
    {
        Task<IEnumerable<TransactionReportViewModel>> GetTransactionWithFullNameAsync(Expression<Func<TransactionReportViewModel, bool>> where = null, string userName = "");
        Task<IEnumerable<TransactionType>> GetTransactionTypesAsync();
    }
}
