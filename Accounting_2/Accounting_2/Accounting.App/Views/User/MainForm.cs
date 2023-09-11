using Accounting.App.Views.Customer;
using Accounting.App.Views.Transaction;
using Accounting.DataLayer.Contexts;
using Accounting.Utility.Convertor;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Accounting.App.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var customers = db.CustomerRepository.Get().Where(customer => customer.UserName == GlobalVariables.Current_User).ToList();

                long recieve = 0;
                long pay = 0;

                if (customers.Count > 0)
                {
                    foreach (var customer in customers)
                    {
                        if (customer.Transaction.Count > 0)
                        {
                            foreach (var transaction in customer.Transaction.ToList())
                            {
                                if (transaction.TransactionType == 1)
                                {
                                    recieve += transaction.Amount;
                                }
                                else if (transaction.TransactionType == 2)
                                {
                                    pay += transaction.Amount;
                                }
                            }
                        }
                    }
                }


                lblRecieve.Text = recieve.ToString();

                lblPay.Text = pay.ToString();

                var result = recieve - pay;

                if (result > 0)
                {
                    lblResult.ForeColor = Color.Green;
                }
                else if (result < 0)
                {
                    lblResult.ForeColor = Color.Red;
                }

                lblResult.Text = result.ToString();
            }
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomers frmCustomers = new FrmCustomers();
            frmCustomers.ShowDialog();
        }

        private void btnManageTransactions_Click(object sender, EventArgs e)
        {
            FrmTransaction frmTransactions = new FrmTransaction();
            frmTransactions.ShowDialog();
        }

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            FrmAddOrEditTransaction frmAddOrEditTransaction = new FrmAddOrEditTransaction();
            frmAddOrEditTransaction.TransactionId = 0;

            if (frmAddOrEditTransaction.ShowDialog() == DialogResult.OK)
            {
                RtlMessageBox.Show("عملیات با موفقیت انجام شد !", "پیغام");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToPersianDateTime().ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToPersianDate().ToString("yyyy/MM/dd");
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnInformationOrEdit_Click(object sender, EventArgs e)
        {
            FrmRegisterOrEdit frmRegister = new FrmRegisterOrEdit();
            frmRegister.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            GlobalVariables.Current_User = "";
            this.Hide();
        }
    }
}
