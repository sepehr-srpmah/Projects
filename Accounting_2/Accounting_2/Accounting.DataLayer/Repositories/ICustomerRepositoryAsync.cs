using Accounting.DataLayer.Contexts;
using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public partial interface ICustomerRepository : IAccountingRepository<Customer>
    {
        Task<IEnumerable<CustomerViewModel>> GetCustomerFullNamesAsync(string userName);
        Task<IEnumerable<CustomerViewModel>> GetCustomerFullNamesByFilterAsync(string filter, string userName);
    }
}
