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
using Accounting.Utility;
using System.IO;

namespace Accounting.App.Views.Customer
{
    public partial class FrmCustomers : Form
    {

        public FrmCustomers()
        {
            InitializeComponent();
        }

        private async void FrmCustomers_Load(object sender, EventArgs e)
        {
            await BindGrid();
        }

        // Programmers call this method: utility
        async Task BindGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;
            using (UnitOfWork db = new UnitOfWork())
            {
                var listOfCustomers = await db.CustomerRepository
                    .GetAsync(c => c.UserName == GlobalVariables.Current_User);

                dgvCustomers.DataSource = listOfCustomers;

                if (listOfCustomers.Count() == 0)
                {
                    RtlMessageBox.Show("طرف حسابی ثبت نشده است !");
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FrmAddOrEditCustomer frmAddOrEdit = new FrmAddOrEditCustomer();
            frmAddOrEdit.CustomerId = 0;

            if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
            {
                RtlMessageBox.Show("عملیات با موفقیت انجام شد !");
                await BindGrid();
            }
        }

        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            FrmAddOrEditCustomer frmEdit = new FrmAddOrEditCustomer();

            if (dgvCustomers.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCustomers
                    .CurrentRow
                    .Cells[0]
                    .Value);

                frmEdit.CustomerId = id;

                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    RtlMessageBox.Show("عملیات با موفقیت انجام شد !");
                    await BindGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا سطری را انتخاب کنید ...");
            }
        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int customerId = Convert
                                    .ToInt32(dgvCustomers
                                        .CurrentRow
                                        .Cells[0]
                                        .Value
                                        .ToString());

                string fullName = dgvCustomers
                                    .CurrentRow
                                    .Cells[1]
                                    .Value.ToString();


                if (RtlMessageBox
                    .Show($"آیا از حذف {fullName} مطمئن هستید ؟",
                        "توجه",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        string imageName = dgvCustomers
                                            .CurrentRow
                                            .Cells[4]
                                            .Value?.ToString();

                        if (imageName != null)
                        {
                            string path = Application.StartupPath + @"\Images\";

                            if (File.Exists(path + imageName))
                            {
                                File.Delete(path + imageName);
                            }
                        }


                        var customer = await db.CustomerRepository.GetByIdAsync(customerId);

                        if (customer.Transaction.Count > 0)
                        {
                            foreach (var transaction in customer.Transaction.ToList())
                            {
                                await db.TransactionRepository.DeleteAsync(transaction);
                            }
                        }

                        await db.CustomerRepository.DeleteAsync(customer);
                        await db.SaveAsync();
                    }

                    await BindGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا سطری را انتخاب کنید ...");
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("Email");
            dt.Columns.Add("Mobile");

            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                dt.Rows.Add(
                        row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString()
                    );
            }

            stiReport.Load(Application.StartupPath + "\\ReportOfCustomers.mrt");
            stiReport.RegData("DT", dt);
            stiReport.Show();
        }
    }
}
