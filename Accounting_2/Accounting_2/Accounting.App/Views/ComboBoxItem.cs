using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.App.Views
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public short Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
