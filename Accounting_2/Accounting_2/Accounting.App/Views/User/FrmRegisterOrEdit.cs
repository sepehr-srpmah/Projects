using Accounting.DataLayer.Contexts;
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
using ValidationComponents;

namespace Accounting.App.Views
{
    public partial class FrmRegisterOrEdit : Form
    {

        public string LastImage_Location = "";

        public FrmRegisterOrEdit()
        {
            InitializeComponent();
        }

        private void FrmRegisterOrEdit_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GlobalVariables.Current_User))
            {
                Text = "ثبت نام";
                pcUser.Image = Properties.Resources.user_image_2;
            }
            else
            {
                Text = "ویرایش اطلاعات";

                txtUserName.Enabled = false;

                using (UnitOfWork db = new UnitOfWork())
                {
                    var user = db.UserRepository
                        .GetById(GlobalVariables.Current_User);

                    txtUserName.Text = user.UserName;
                    txtPassword.Text = user.Password;

                    if (!string.IsNullOrEmpty(user.Image))
                    {
                        pcUser.ImageLocation = Application.StartupPath + "\\Images\\" + user.Image;
                    }
                    else
                    {
                        pcUser.Image = Properties.Resources.user_image;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                string path = Application.StartupPath + "\\Images\\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                User user = new User();

                var userName = txtUserName.Text;
                user.UserName = (string.IsNullOrEmpty(GlobalVariables.Current_User)) ? userName : GlobalVariables.Current_User;

                user.Password = txtPassword.Text;

                using (UnitOfWork db = new UnitOfWork())
                {
                    if (db.UserRepository.GetById(userName) != null && string.IsNullOrEmpty(GlobalVariables.Current_User))
                    {
                        RtlMessageBox.Show("کابر در حال حاظر ثبت نام شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(LastImage_Location))
                        {
                            File.Delete(LastImage_Location);
                        }

                        if (!string.IsNullOrEmpty(pcUser.ImageLocation))
                        {
                            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcUser.ImageLocation);
                            user.Image = imageName;
                            pcUser.Image.Save(path + imageName);

                            LastImage_Location = path + imageName;
                        }

                        if (string.IsNullOrEmpty(GlobalVariables.Current_User))
                        {
                            db.UserRepository.Add(user);
                        }
                        else
                        {
                            db.UserRepository.Update(user);
                        }

                        db.Save();

                        GlobalVariables.Current_User = userName;

                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void btnUnloadImage_Click(object sender, EventArgs e)
        {
            pcUser.Image = Properties.Resources.user_image_2;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

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
                pcUser.ImageLocation = openFile.FileName;
            }
        }

        private void pcUser_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
    }
}
