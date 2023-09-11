using Accounting.DataLayer.Contexts;
using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public partial interface ICustomerRepository : IAccountingRepository<Customer>
    {
        IEnumerable<CustomerViewModel> GetCustomerFullNames(string userName);
        IEnumerable<CustomerViewModel> GetCustomerFullNamesByFilter(string filter, string userName);
    }
}
