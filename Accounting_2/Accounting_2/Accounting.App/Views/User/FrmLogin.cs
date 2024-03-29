﻿using Accounting.App.Views.Admin;
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
using ValidationComponents;

namespace Accounting.App.Views
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegisterOrEdit frmRegisterOrEdit = new FrmRegisterOrEdit();
            if (frmRegisterOrEdit.ShowDialog() == DialogResult.OK)
            {
                RtlMessageBox.Show("ثبت نام با موفقیت انجام شد !");
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (BaseValidator.IsFormValid(this.components))
            {

                if (userName == "admin" && password == "123")
                {
                    FrmManageUsers frmAdmin = new FrmManageUsers();
                    frmAdmin.ShowDialog();
                }
                else
                {
                    MainForm form = new MainForm();

                    using (UnitOfWork db = new UnitOfWork())
                    {
                        var user = await db.UserRepository.GetUserByUserNameAndPasswordAsync(userName, password);

                        if (user != null)
                        {
                            RtlMessageBox.Show("خوش آمدید !");
                            GlobalVariables.Current_User = user.UserName;
                            this.Hide();
                            form.ShowDialog();
                        }
                        else
                        {
                            RtlMessageBox.Show("کاربری یافت نشد !", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private async void txtUserName_TextChanged(object sender, EventArgs e)
        {
            var coll = new AutoCompleteStringCollection();

            using (UnitOfWork db = new UnitOfWork())
            {
                var users = await db.UserRepository.GetUserNamesAsync(txtUserName.Text.Trim());

                if (users.Any())
                {
                    coll.AddRange(users.ToArray());
                }

                txtUserName.AutoCompleteCustomSource = coll;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
