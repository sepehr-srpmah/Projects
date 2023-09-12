
namespace Accounting.App.Views.Customer
{
    partial class FrmAddOrEditCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddOrEditCustomer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcCustomer = new Accounting.Utility.RoundedPictureBox();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnUnloadImage = new System.Windows.Forms.Button();
            this.regularExpressionValidator1 = new ValidationComponents.RegularExpressionValidator(this.components);
            this.regularExpressionValidator2 = new ValidationComponents.RegularExpressionValidator(this.components);
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator3 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pcCustomer);
            this.groupBox1.Font = new System.Drawing.Font("Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(240, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات کاربری";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("A Salamat", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMobile.Location = new System.Drawing.Point(8, 284);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(172, 26);
            this.txtMobile.TabIndex = 8;
            this.txtMobile.TextChanged += new System.EventHandler(this.txtMobile_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(188, 286);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "موبایل :";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(8, 245);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(172, 23);
            this.txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(188, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "ایمیل :";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("2  Homa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFullName.Location = new System.Drawing.Point(8, 202);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(172, 27);
            this.txtFullName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(188, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام :";
            // 
            // pcCustomer
            // 
            this.pcCustomer.BackColor = System.Drawing.Color.DarkGray;
            this.pcCustomer.ErrorImage = global::Accounting.App.Properties.Resources.user_image;
            this.pcCustomer.Image = global::Accounting.App.Properties.Resources.user_image;
            this.pcCustomer.Location = new System.Drawing.Point(35, 19);
            this.pcCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.pcCustomer.Name = "pcCustomer";
            this.pcCustomer.Size = new System.Drawing.Size(163, 171);
            this.pcCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcCustomer.TabIndex = 0;
            this.pcCustomer.TabStop = false;
            this.pcCustomer.Click += new System.EventHandler(this.pcCustomer_Click);
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.Font = new System.Drawing.Font("Sina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveCustomer.Location = new System.Drawing.Point(9, 349);
            this.btnSaveCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.Size = new System.Drawing.Size(72, 30);
            this.btnSaveCustomer.TabIndex = 1;
            this.btnSaveCustomer.Text = "ثبت";
            this.btnSaveCustomer.UseVisualStyleBackColor = true;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Font = new System.Drawing.Font("Sina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUploadImage.Location = new System.Drawing.Point(89, 349);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(107, 30);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "بارگذاری عکس";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnUnloadImage
            // 
            this.btnUnloadImage.Font = new System.Drawing.Font("Sina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUnloadImage.Location = new System.Drawing.Point(204, 349);
            this.btnUnloadImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnloadImage.Name = "btnUnloadImage";
            this.btnUnloadImage.Size = new System.Drawing.Size(45, 30);
            this.btnUnloadImage.TabIndex = 3;
            this.btnUnloadImage.Text = "حذف عکس";
            this.btnUnloadImage.UseVisualStyleBackColor = true;
            this.btnUnloadImage.Click += new System.EventHandler(this.btnUnloadImage_Click);
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.CancelFocusChangeWhenInvalid = false;
            this.regularExpressionValidator1.ControlToValidate = this.txtMobile;
            this.regularExpressionValidator1.ErrorMessage = "لطفا شماره موبایل معتبر وارد کنید";
            this.regularExpressionValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("regularExpressionValidator1.Icon")));
            this.regularExpressionValidator1.ValidationExpression = "([0-9]{11})|([0-9]{10})";
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.CancelFocusChangeWhenInvalid = false;
            this.regularExpressionValidator2.ControlToValidate = this.txtEmail;
            this.regularExpressionValidator2.ErrorMessage = "لطفا ایمیل معتبر وارد کنید";
            this.regularExpressionValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("regularExpressionValidator2.Icon")));
            this.regularExpressionValidator2.ValidationExpression = "^[a-zA-Z0-9.!#$%&\'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtFullName;
            this.requiredFieldValidator1.ErrorMessage = "لطفا نام خود را وارد کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtEmail;
            this.requiredFieldValidator2.ErrorMessage = "لطفا ایمیل خود را وارد کنید";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator3.ControlToValidate = this.txtMobile;
            this.requiredFieldValidator3.ErrorMessage = "لطفا شماره موبایل خود را وارد کنید";
            this.requiredFieldValidator3.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator3.Icon")));
            // 
            // FrmAddOrEditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 386);
            this.Controls.Add(this.btnUnloadImage);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("A Salamat", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrEditCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmAddOrEditCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveCustomer;
        private Utility.RoundedPictureBox pcCustomer;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnUnloadImage;
        private ValidationComponents.RegularExpressionValidator regularExpressionValidator1;
        private ValidationComponents.RegularExpressionValidator regularExpressionValidator2;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator3;
    }
}