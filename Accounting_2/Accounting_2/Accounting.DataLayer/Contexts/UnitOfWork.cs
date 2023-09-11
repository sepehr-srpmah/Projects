using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Contexts
{
    public partial class UnitOfWork : IDisposable
    {
        private AccountingDbContext context = new AccountingDbContext();

        private IUserRepository _userRepository;
        private ICustomerRepository _customerRepository;
        private ITransactionRepository _transactionRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(context);
                }
                return _customerRepository;
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new TransactionRepository(context);
                }
                return _transactionRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }

                return _userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return Task.Run(delegate ()
            {
                context.SaveChangesAsync();
            });
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
