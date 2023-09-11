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
        User GetUserByUserNameAndPassword(string userName,
            string password);

        IEnumerable<User> GetByFilter(string filter);
    }
}
