using Accounting.DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public partial interface IUserRepository : IAccountingRepository<User>
    {
        Task<User> GetUserByUserNameAndPasswordAsync(string userName,
            string password);

        Task<IEnumerable<User>> GetByFilterAsync(string filter);

        Task<IEnumerable<string>> GetUserNamesAsync(string filter);
    }
}
