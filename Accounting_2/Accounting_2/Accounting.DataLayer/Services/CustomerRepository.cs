using Accounting.DataLayer.Contexts;
using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Accounting.ViewModels.Customer;
using Accounting.Utility.Exceptions;

namespace Accounting.DataLayer.Services
{
    public partial class CustomerRepository : ICustomerRepository
    {
        private AccountingDbContext _db;

        public CustomerRepository(AccountingDbContext db)
        {
            _db = db;
        }

        public bool Add(Customer entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Added;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }



        public bool Delete(Customer entity)
        {
            try
            {
                if (entity.Transaction.Count > 0)
                {
                    foreach (Transaction transaction in entity.Transaction.ToList())
                    {
                        _db.Entry(transaction).State = EntityState.Deleted;
                    }
                }

                _db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(object id)
        {
            var customer = GetById(id);
            return Delete(customer);
        }



        public IEnumerable<Customer>
            Get(Expression<Func<Customer, bool>> where = null)
        {
            try
            {
                IQueryable<Customer> query = _db.Customer;
                if (where != null)
                {
                    query = query.Where(where);
                }
                return query.ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }



        public Customer GetById(object id)
        {
            try
            {
                var customer = _db.Customer.Find((int)id);
                return customer;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }



        public IEnumerable<CustomerViewModel> GetCustomerFullNames(string userName)
        {
            try
            {
                var result = _db.Customer.Where(c => c.UserName == userName).Select(c => new CustomerViewModel()
                {
                    CustomerID = c.ID,
                    FullName = c.FullName
                });

                return result.ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        

        public IEnumerable<CustomerViewModel>
            GetCustomerFullNamesByFilter(string filter, string userName)
        {
            return _db.Customer
                .Where(c => c.FullName
                    .Contains(filter) && c.UserName == userName)
                    .Select(c => new CustomerViewModel()
                    {
                        CustomerID = c.ID,
                        FullName = c.FullName
                    }).ToList();
        }

        

        public bool Update(Customer entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

    }
}
