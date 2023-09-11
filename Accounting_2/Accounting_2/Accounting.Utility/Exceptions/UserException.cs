using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utility.Exceptions
{
    public class UserException : Exception
    {
        private string _userName;

        public UserException(string userName)
        {
            _userName = userName;
        }

        public override string Message => base.Message + " , UserName: " + _userName;
    }
}
