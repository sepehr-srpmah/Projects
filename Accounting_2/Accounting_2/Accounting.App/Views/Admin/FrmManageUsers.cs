using Accounting.DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App.Views.Admin
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
        }

        private async void FrmManageUsers_Load(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async Task BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvUsers.AutoGenerateColumns = false;
                dgvUsers.DataSource = await db.UserRepository.GetAsync();
            }
        }

        private async void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                if (RtlMessageBox.Show("آیا از حذف شخص مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {

                        string username = dgvUsers
                                            .CurrentRow
                                            .Cells[0]
                                            .Value
                                            .ToString();

                        var user = await db.UserRepository.GetByIdAsync(username);

                        if (user.Customer.Count > 0)
                        {
                            foreach (var customer in user.Customer.ToList())
                            {
                                if (customer.Transaction.Count > 0)
                                {
                                    foreach (var transaction in customer.Transaction.ToList())
                                    {
                                        await db.TransactionRepository.DeleteAsync(transaction);
                                    }
                                }

                                await db.CustomerRepository.DeleteAsync(customer);
                            }
                        }

                        await db.UserRepository.DeleteAsync(username);

                        await db.SaveAsync();
                    }

                    await BindGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا سطری را انتخاب کنید ...",
                    "توجه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvUsers.DataSource = await db.UserRepository.GetByFilterAsync(txtSearch.Text);
            }
        }
    }
}
