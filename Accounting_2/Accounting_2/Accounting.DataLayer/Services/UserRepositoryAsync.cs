using Accounting.DataLayer.Contexts;
using Accounting.DataLayer.Repositories;
using Accounting.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public partial class UserRepository : IUserRepository
    {
        public Task AddAsync(User entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    _db.User.Add(entity);
                });
            }
            catch
            {
                throw new UserException(entity.UserName);
            }
        }

        public Task DeleteAsync(User entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    _db.User.Remove(entity);
                });
            }
            catch
            {
                throw new UserException(entity.UserName);
            }
        }

        public async Task DeleteAsync(object id)
        {
            var user = await GetByIdAsync(id);
            await DeleteAsync(user);
        }

        public async Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>> where = null)
        {
            IQueryable<User> query = _db.User;

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByFilterAsync(string filter)
        {
            return await GetAsync(user => user.UserName.Contains(filter) ||
                user.Password.Contains(filter));
        }

        public async Task<User> GetByIdAsync(object id)
        {
            return await _db.User.FindAsync((string)id);
        }

        public async Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password)
        {
            var user = await GetAsync(u => u.UserName == userName && u.Password == password);
            return user.FirstOrDefault();
        }

        public Task UpdateAsync(User entity)
        {
            try
            {
                return Task.Run(delegate ()
                {
                    var local = _db.Set<User>()
                    .Local
                    .FirstOrDefault(user => user.UserName == entity.UserName);

                    if (local != null)
                    {
                        _db.Entry(local).State = EntityState.Detached;
                    }

                    _db.Entry(entity).State = EntityState.Modified;
                });
            }
            catch (Exception e)
            {
                throw new UserException(entity.UserName);
            }
        }
    }
}
