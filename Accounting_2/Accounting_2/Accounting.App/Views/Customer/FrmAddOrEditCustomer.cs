using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Contexts;
using Accounting.Utility;
using ValidationComponents;

namespace Accounting.App.Views.Customer
{
    public partial class FrmAddOrEditCustomer : Form
    {
        public int CustomerId = 0;
        private string lastImageLocation = "";


        public FrmAddOrEditCustomer()
        {
            InitializeComponent();
        }

        private async void FrmAddOrEditCustomer_Load(object sender, EventArgs e)
        {
            if (CustomerId == 0)
            {
                this.Text = "افزودن طرف حساب جدید";
                btnUnloadImage.Hide();
            }
            else
            {
                this.Text = "ویرایش اطلاعات طرف حساب";
                await Task.Run(() =>
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        var customer = db.CustomerRepository.GetById(CustomerId);
                        txtFullName.Text = customer.FullName;
                        txtMobile.Text = customer.Mobile;
                        txtEmail.Text = customer.Email;
                        if (string.IsNullOrEmpty(customer.Image))
                        {
                            pcCustomer.Image = Properties.Resources.user_image;
                        }
                        else
                        {
                            string path = Application.StartupPath + @"\Images\";
                            pcCustomer.ImageLocation = path + customer.Image;
                        }
                    }
                });
            }
        }

        private async void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (BaseValidator.IsFormValid(this.components))
                {
                    string path = Application.StartupPath + @"\Images\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var customer = new Accounting.DataLayer.Contexts.Customer()
                    {
                        FullName = txtFullName.Text,
                        Email = txtEmail.Text,
                        Mobile = txtMobile.Text,
                        UserName = GlobalVariables.Current_User
                    };

                    if (!string.IsNullOrEmpty(pcCustomer.ImageLocation))
                    {
                        if (lastImageLocation != "")
                        {
                            File.Delete(lastImageLocation);
                            lastImageLocation = "";
                        }

                        string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                        customer.Image = imageName;
                        pcCustomer.Image.Save(path + imageName);
                        lastImageLocation = path + imageName;
                    }

                    using (UnitOfWork db = new UnitOfWork())
                    {
                        if (CustomerId == 0)
                        {
                            db.CustomerRepository.Add(customer);
                        }
                        else
                        {
                            customer.ID = CustomerId;
                            db.CustomerRepository.Update(customer);
                        }

                        db.Save();
                    }

                    DialogResult = DialogResult.OK;
                }
            });
        }

        private async void btnUnloadImage_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                lastImageLocation = pcCustomer.ImageLocation;
                pcCustomer.Image = Properties.Resources.user_image;
            });
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        // Programmers also call this Utility ...
        private void UploadImage()
        {

            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "عکس موردنطر را انتخاب کنید ...";
            openFile.Filter = "Image File (*.bmp, *.gif, *.jpg, *.png)|*.bmp; *.gif*;*.jpg; *.png";
            openFile.InitialDirectory = @"C:\Downloads";

            openFile.AddExtension = true;
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = openFile.FileName;
            }
        }

        private void pcCustomer_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
