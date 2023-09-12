namespace Accounting.App.Views
{
    partial class FrmRegisterOrEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegisterOrEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnUnloadImage = new System.Windows.Forms.Button();
            this.pcUser = new Accounting.Utility.RoundedPictureBox();
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("2  Elham", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام کاربری :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("2  Elham", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(13, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "کلمه عبور :";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(78, 203);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(148, 28);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(78, 237);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(148, 25);
            this.txtPassword.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MRT_SS Three", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Location = new System.Drawing.Point(16, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Font = new System.Drawing.Font("MRT_SS Three", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUploadImage.Location = new System.Drawing.Point(78, 281);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(73, 23);
            this.btnUploadImage.TabIndex = 6;
            this.btnUploadImage.Text = "آپلود عکس";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnUnloadImage
            // 
            this.btnUnloadImage.Font = new System.Drawing.Font("MRT_SS Three", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUnloadImage.Location = new System.Drawing.Point(157, 281);
            this.btnUnloadImage.Name = "btnUnloadImage";
            this.btnUnloadImage.Size = new System.Drawing.Size(69, 23);
            this.btnUnloadImage.TabIndex = 7;
            this.btnUnloadImage.Text = "حذف عکس";
            this.btnUnloadImage.UseVisualStyleBackColor = true;
            this.btnUnloadImage.Click += new System.EventHandler(this.btnUnloadImage_Click);
            // 
            // pcUser
            // 
            this.pcUser.BackColor = System.Drawing.Color.DarkGray;
            this.pcUser.Image = global::Accounting.App.Properties.Resources.user_image_2;
            this.pcUser.Location = new System.Drawing.Point(27, 0);
            this.pcUser.Name = "pcUser";
            this.pcUser.Size = new System.Drawing.Size(184, 192);
            this.pcUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcUser.TabIndex = 0;
            this.pcUser.TabStop = false;
            this.pcUser.Click += new System.EventHandler(this.pcUser_Click);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtUserName;
            this.requiredFieldValidator1.ErrorMessage = "لطفا نام کاربری خود را وارد کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtPassword;
            this.requiredFieldValidator2.ErrorMessage = "لطفا کلمه عبور خود را وارد کنید";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // FrmRegisterOrEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 315);
            this.Controls.Add(this.btnUnloadImage);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcUser);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRegisterOrEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmRegisterOrEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.RoundedPictureBox pcUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnUnloadImage;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
    }
}