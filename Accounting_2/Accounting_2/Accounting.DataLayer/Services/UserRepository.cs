using Accounting.DataLayer.Contexts;
using Accounting.DataLayer.Repositories;
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
    public partial class UserRepository : IUserRepository
    {
        private AccountingDbContext _db;

        public UserRepository(AccountingDbContext db)
        {
            _db = db;
        }

        public bool Add(User entity)
        {
            try
            {
                _db.User.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }



        public bool Delete(User entity)
        {
            try
            {
                if (entity.Customer.Count > 0)
                {
                    foreach (Customer customer in entity.Customer.ToList())
                    {
                        if (customer.Transaction.Count > 0)
                        {
                            foreach (Transaction transaction in customer.Transaction.ToList())
                            {
                                _db.Entry(transaction).State = EntityState.Deleted;
                            }
                        }

                        _db.Entry(customer).State = EntityState.Deleted;
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
            var user = GetById(id);
            return Delete(user);
        }



        public IEnumerable<User> Get(Expression<Func<User, bool>> where = null)
        {
            IQueryable<User> query = _db.User;

            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }



        public IEnumerable<User> GetByFilter(string filter)
        {
            return Get(user => user.UserName.Contains(filter) ||
                user.Password.Contains(filter));
        }



        public User GetById(object id)
        {
            return _db.User.Find((string)id);
        }


        public User GetUserByUserNameAndPassword(string userName,
            string password)
        {
            return Get(user => user.UserName == userName &&
                user.Password == password)
                    .FirstOrDefault();
        }


        public bool Update(User entity)
        {
            try
            {
                var local = _db.Set<User>()
                    .Local
                    .FirstOrDefault(user => user.UserName == entity.UserName);

                if (local != null)
                {
                    _db.Entry(local).State = EntityState.Detached;
                }

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
