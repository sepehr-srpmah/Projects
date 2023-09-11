using Accounting.DataLayer.Contexts;
using Accounting.DataLayer.Repositories;
using Accounting.Utility.Exceptions;
using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public partial class CustomerRepository : ICustomerRepository
    {

        public async Task<IEnumerable<CustomerViewModel>> GetCustomerFullNamesAsync(string userName)
        {
            try
            {
                var result = _db.Customer.Where(c => c.UserName == userName).Select(c => new CustomerViewModel()
                {
                    CustomerID = c.ID,
                    FullName = c.FullName
                });

                return await result.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }



        public async Task<IEnumerable<CustomerViewModel>>
            GetCustomerFullNamesByFilterAsync(string filter, string userName)
        {
            return await _db.Customer
                .Where(c => c.FullName
                    .Contains(filter) && c.UserName == userName)
                    .Select(c => new CustomerViewModel()
                    {
                        CustomerID = c.ID,
                        FullName = c.FullName
                    }).ToListAsync();
        }

        public Task AddAsync(Customer entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    _db.Customer.Add(entity);
                });
            }
            catch
            {
                throw new CustomerException(new CustomerViewModel() { CustomerID = entity.ID, FullName = entity.FullName });
            }
        }

        public Task DeleteAsync(Customer entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    _db.Customer.Remove(entity);
                });
            }
            catch
            {
                throw new CustomerException(new CustomerViewModel() { CustomerID = entity.ID, FullName = entity.FullName });
            }
        }

        public Task DeleteAsync(object id)
        {
            return Task.Run(delegate ()
            {
                var customer = GetByIdAsync(id);
                DeleteAsync(customer);
            });
        }

        public async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> where=null)
        {
            try
            {
                IQueryable<Customer> query = _db.Customer;
                if (where != null)
                {
                    query = query.Where(where);
                }
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Customer> GetByIdAsync(object id)
        {
            try
            {
                var customer = await _db.Customer.FindAsync((int)id);
                return customer;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public Task UpdateAsync(Customer entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    var local = _db.Customer.Local.FirstOrDefault(c => c.ID == entity.ID);

                    if (local != null)
                        _db.Entry(local).State = EntityState.Detached;

                    _db.Entry(entity).State = EntityState.Modified;
                });
            }
            catch
            {
                throw new CustomerException(new CustomerViewModel() { CustomerID = entity.ID, FullName = entity.FullName });
            }
        }
    }
}
