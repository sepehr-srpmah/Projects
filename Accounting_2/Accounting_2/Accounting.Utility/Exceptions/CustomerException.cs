using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utility.Exceptions
{
    public class CustomerException : Exception
    {
        private CustomerViewModel _customer;

        public CustomerException(CustomerViewModel customer)
        {
            _customer = customer;
        }

        public override string Message => base.Message + string.Format(" , CustomerID: {0}  ,  FullName: {1}", _customer.CustomerID, _customer.FullName);
    }
}
