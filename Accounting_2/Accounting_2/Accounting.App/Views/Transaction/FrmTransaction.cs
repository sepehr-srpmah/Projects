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
using System.Globalization;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Transaction;

namespace Accounting.App.Views.Transaction
{
    public partial class FrmTransaction : Form
    {
        public FrmTransaction()
        {
            InitializeComponent();
        }

        private async void FrmTransaction_Load(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async Task BindGrid()
        {
            dgvTransactions.AutoGenerateColumns = false;
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvTransactions.DataSource = await db.TransactionRepository.GetTransactionWithFullNameAsync(userName: GlobalVariables.Current_User);
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.Rows.Count > 0)
            {
                List<TransactionReportViewModel> result = new List<TransactionReportViewModel>();

                foreach (DataGridViewRow row in dgvTransactions.Rows)
                {
                    result.Add(new TransactionReportViewModel()
                    {
                        ID = Convert.ToInt32(row.Cells[0].Value),
                        TransactionType = Convert.ToInt16(row.Cells[1].Value.ToString()),
                        FullName = row.Cells[2].Value.ToString(),
                        Amount = Convert.ToInt64(row.Cells[3].Value.ToString()),
                        DateCreated = Convert.ToDateTime(row.Cells[4].Value.ToString())
                    });
                }

                short transactionType = 0;

                if (rdoRecieve.Checked || rdoPay.Checked)
                {
                    if (rdoRecieve.Checked)
                    {
                        transactionType = 1;
                    }
                    else if (rdoPay.Checked)
                    {
                        transactionType = 2;
                    }

                    result = result
                        .Where(t => t.TransactionType == transactionType)
                        .ToList();
                }

                string fromDate = mtxFromDate.Text;

                if (fromDate != "14  /  /")
                {
                    DateTime startDate = Convert.ToDateTime(fromDate);
                    result = result
                        .Where(t => TransactionDateTime.IsGreater(t.DateCreated, startDate))
                        .ToList();
                }

                string toDate = mtxToDate.Text;

                if (toDate != "14  /  /")
                {
                    DateTime endDate = Convert.ToDateTime(toDate);
                    result = result
                        .Where(t => TransactionDateTime.IsLess(t.DateCreated, endDate))
                        .ToList();
                }

                dgvTransactions.DataSource = result;
            }
            else
            {
                RtlMessageBox.Show("لیست تراکنش های شما خالی است !", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            mtxFromDate.Text = "14  /  /";
            mtxToDate.Text = "14  /  /";
            rdoPayOrRecieve.Checked = true;
            txtFilter.Text = "";

            await BindGrid();
        }

        private async void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvTransactions.DataSource = await db.TransactionRepository.GetTransactionWithFullNameAsync(t => t.FullName.Contains(txtFilter.Text) || t.Amount.ToString().Contains(txtFilter.Text));
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async void btnRemoveTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow != null)
            {
                if (RtlMessageBox.Show("آیا از حذف تراکنش انتخاب شده مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvTransactions.CurrentRow.Cells[0].Value.ToString());
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        await db.TransactionRepository.DeleteAsync(id);
                        await db.SaveAsync();
                    }

                    RtlMessageBox.Show("حذف با موفقیت انجام شد !", "پیغام");
                }
                else
                {
                    RtlMessageBox.Show("لطفا سطری را انتخاب کنید ...", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvTransactions.CurrentRow.Cells[0].Value.ToString());

                FrmAddOrEditTransaction frmEdit = new FrmAddOrEditTransaction();
                frmEdit.TransactionId = id;

                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    RtlMessageBox.Show("ویرایش با موفقیت انجام شد !", "پیغام");
                    await BindGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا سطری را انتخاب کنید ...", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mtxFromDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            CheckInputLanguageCultureName();
        }

        private static void CheckInputLanguageCultureName()
        {
            if (InputLanguage.CurrentInputLanguage.Culture.Name != "en-US" || InputLanguage.CurrentInputLanguage.Culture.Name != "en-GB")
            {
                RtlMessageBox.Show("لطفا زبان کیبورد خود را روی انگلیسی تنظیم کنید");
            }
        }

        private void mtxToDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            CheckInputLanguageCultureName();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("FullName");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("DateCreated");

            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                dtPrint.Rows.Add(
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value.ToString()
                    );
            }

            stiReport.Load(Application.StartupPath + "/Report.mrt");
            stiReport.RegData("DT", dtPrint);
            stiReport.Show();
        }
    }
}
