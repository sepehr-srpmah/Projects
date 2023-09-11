using Accounting.DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using Accounting.Utility.Convertor;

namespace Accounting.App.Views.Transaction
{
    public partial class FrmAddOrEditTransaction : Form
    {
        public int TransactionId = 0;

        public object PersianCalender { get; private set; }

        public FrmAddOrEditTransaction()
        {
            InitializeComponent();
        }

        private async void FrmAddOrEditTransaction_Load(object sender, EventArgs e)
        {
            await Initialize_ComboBox();

            await BindGrid();

            if (TransactionId == 0)
            {
                Text = "تراکنش جدید";
            }
            else
            {
                Text = "ویرایش اطلاعات تراکنش";
                btnRefresh.Visible = false;

                using (UnitOfWork db = new UnitOfWork())
                {
                    var transaction = await db.TransactionRepository.GetByIdAsync(TransactionId);
                    nudAmount.Value = Convert.ToInt64(transaction.Amount);
                    cmbTransactionTypes.SelectedIndex = transaction.TransactionType;
                    rtxDescription.Text = transaction.Description;

                    dgvCustomers.ClearSelection();
                    dgvCustomers.CurrentCell = null;

                    foreach (DataGridViewRow row in dgvCustomers.Rows)
                    {

                        if (Convert.ToInt32(row.Cells[0].Value.ToString()) == transaction.Customer_ID)
                        {
                            row.Selected = true;
                        }
                    }
                }
            }
        }

        private async Task Initialize_ComboBox()
        {
            var firstItem = new ComboBoxItem()
            {
                Text = "لطفا یکی را انتخاب کنید",
                Value = 0
            };
            cmbTransactionTypes.Items.Add(firstItem);

            cmbTransactionTypes.SelectedItem = firstItem;

            using (UnitOfWork db = new UnitOfWork())
            {
                var transactionTypes = await db.TransactionRepository.GetTransactionTypesAsync();

                for (short i = 0; i < transactionTypes.Count(); i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Value = transactionTypes.ElementAt(i).ID;
                    item.Text = transactionTypes.ElementAt(i).TypeName;

                    cmbTransactionTypes.Items.Add(item);
                }
            }
        }

        private async Task BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvCustomers.AutoGenerateColumns = false;
                dgvCustomers.DataSource = await db.CustomerRepository.GetCustomerFullNamesAsync(GlobalVariables.Current_User);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await BindGrid();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var amount = nudAmount.Value;

            string description = rtxDescription.Text;

            if (amount > 0 && amount < nudAmount.Maximum)
            {
                if (cmbTransactionTypes.SelectedIndex != 0)
                {
                    var transactionType = short.Parse((cmbTransactionTypes.SelectedItem as ComboBoxItem).Value.ToString());

                    if (dgvCustomers.CurrentRow != null)
                    {
                        int customerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value.ToString());

                        var transaction = new DataLayer.Contexts.Transaction()
                        {
                            Customer_ID = customerId,
                            TransactionType = transactionType,
                            Amount = Convert.ToInt64(amount),
                            Description = description,
                            DateCreated = DateTime.Now
                        };

                        using (UnitOfWork db = new UnitOfWork())
                        {

                            if (TransactionId == 0)
                            {

                                await db.TransactionRepository.AddAsync(transaction);
                            }
                            else
                            {
                                transaction.ID = TransactionId;
                                await db.TransactionRepository.UpdateAsync(transaction);
                            }

                            await db.SaveAsync();
                        }

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        ShowWarningMessage("لطفا طرف حساب موردنظر خود را از لیست طرف حساب ها انتخاب کنید ...");
                    }
                }
                else
                {
                    ShowWarningMessage("لطفا نوع تراکنش را انتخاب کنید ...");
                }
            }
            else
            {
                ShowWarningMessage("لطفا مبلغ معتبر وارد کنید ....");
            }
        }

        private static void ShowWarningMessage(string message)
        {
            RtlMessageBox.Show(message,
                                        "توجه",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
        }

        private async void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvCustomers.DataSource = await db.CustomerRepository.GetCustomerFullNamesByFilterAsync(txtFilter.Text, GlobalVariables.Current_User);
            }
        }
    }
}
