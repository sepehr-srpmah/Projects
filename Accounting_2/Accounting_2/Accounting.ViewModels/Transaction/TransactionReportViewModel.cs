using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.ViewModels.Transaction
{
    public partial class TransactionReportViewModel
    {
        public int ID { get; set; }
        public short TransactionType { get; set; }
        public string FullName { get; set; }
        public long Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
