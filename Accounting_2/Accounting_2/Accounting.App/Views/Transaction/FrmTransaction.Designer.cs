
namespace Accounting.App.Views.Transaction
{
    partial class FrmTransaction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPayOrRecieve = new System.Windows.Forms.RadioButton();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.mtxToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoPay = new System.Windows.Forms.RadioButton();
            this.rdoRecieve = new System.Windows.Forms.RadioButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEditTransaction = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveTransaction = new System.Windows.Forms.ToolStripButton();
            this.btnPrintReport = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.stiReport = new Stimulsoft.Report.StiReport();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPayOrRecieve);
            this.groupBox1.Controls.Add(this.btnRemoveFilter);
            this.groupBox1.Controls.Add(this.btnAddFilter);
            this.groupBox1.Controls.Add(this.mtxToDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtxFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoPay);
            this.groupBox1.Controls.Add(this.rdoRecieve);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فیلتر کردن";
            // 
            // rdoPayOrRecieve
            // 
            this.rdoPayOrRecieve.AutoSize = true;
            this.rdoPayOrRecieve.Location = new System.Drawing.Point(37, 26);
            this.rdoPayOrRecieve.Name = "rdoPayOrRecieve";
            this.rdoPayOrRecieve.Size = new System.Drawing.Size(51, 17);
            this.rdoPayOrRecieve.TabIndex = 10;
            this.rdoPayOrRecieve.TabStop = true;
            this.rdoPayOrRecieve.Text = "هر دو";
            this.rdoPayOrRecieve.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(12, 64);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(108, 23);
            this.btnRemoveFilter.TabIndex = 9;
            this.btnRemoveFilter.Text = "حذف فیلتر";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(126, 64);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(93, 23);
            this.btnAddFilter.TabIndex = 8;
            this.btnAddFilter.Text = "اعمال فیلتر";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // mtxToDate
            // 
            this.mtxToDate.Font = new System.Drawing.Font("A Salamat", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mtxToDate.Location = new System.Drawing.Point(249, 64);
            this.mtxToDate.Mask = "1400/00/00";
            this.mtxToDate.Name = "mtxToDate";
            this.mtxToDate.Size = new System.Drawing.Size(80, 26);
            this.mtxToDate.TabIndex = 7;
            this.mtxToDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxToDate_MaskInputRejected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "تا تاریخ :";
            // 
            // mtxFromDate
            // 
            this.mtxFromDate.Font = new System.Drawing.Font("A Salamat", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mtxFromDate.Location = new System.Drawing.Point(391, 65);
            this.mtxFromDate.Mask = "1400/00/00";
            this.mtxFromDate.Name = "mtxFromDate";
            this.mtxFromDate.Size = new System.Drawing.Size(78, 26);
            this.mtxFromDate.TabIndex = 5;
            this.mtxFromDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxFromDate_MaskInputRejected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "از تاریخ :";
            // 
            // rdoPay
            // 
            this.rdoPay.AutoSize = true;
            this.rdoPay.Location = new System.Drawing.Point(95, 26);
            this.rdoPay.Name = "rdoPay";
            this.rdoPay.Size = new System.Drawing.Size(77, 17);
            this.rdoPay.TabIndex = 3;
            this.rdoPay.TabStop = true;
            this.rdoPay.Text = "پرداختی ها";
            this.rdoPay.UseVisualStyleBackColor = true;
            // 
            // rdoRecieve
            // 
            this.rdoRecieve.AutoSize = true;
            this.rdoRecieve.Location = new System.Drawing.Point(178, 26);
            this.rdoRecieve.Name = "rdoRecieve";
            this.rdoRecieve.Size = new System.Drawing.Size(74, 17);
            this.rdoRecieve.TabIndex = 2;
            this.rdoRecieve.TabStop = true;
            this.rdoRecieve.Text = "دریافتی ها";
            this.rdoRecieve.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(264, 25);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(201, 21);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "جستجو :";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TransactionType,
            this.FullName,
            this.Amount,
            this.DateCreated});
            this.dgvTransactions.Location = new System.Drawing.Point(12, 166);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.Size = new System.Drawing.Size(537, 246);
            this.dgvTransactions.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.HeaderText = "نوع تراکنش";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.ReadOnly = true;
            this.TransactionType.Visible = false;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "نام";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "مبلغ";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "تاریخ";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditTransaction,
            this.btnRemoveTransaction,
            this.btnPrintReport,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(561, 72);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEditTransaction
            // 
            this.btnEditTransaction.Image = global::Accounting.App.Properties.Resources.icons8_add_properties_40__1_;
            this.btnEditTransaction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditTransaction.Name = "btnEditTransaction";
            this.btnEditTransaction.Size = new System.Drawing.Size(85, 69);
            this.btnEditTransaction.Text = "ویرایش تراکنش";
            this.btnEditTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditTransaction.Click += new System.EventHandler(this.btnEditTransaction_Click);
            // 
            // btnRemoveTransaction
            // 
            this.btnRemoveTransaction.Image = global::Accounting.App.Properties.Resources.icons8_delete_document_40;
            this.btnRemoveTransaction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRemoveTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveTransaction.Name = "btnRemoveTransaction";
            this.btnRemoveTransaction.Size = new System.Drawing.Size(74, 69);
            this.btnRemoveTransaction.Text = "حذف تراکنش";
            this.btnRemoveTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveTransaction.Click += new System.EventHandler(this.btnRemoveTransaction_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Image = global::Accounting.App.Properties.Resources.icons8_print_50;
            this.btnPrintReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(66, 69);
            this.btnPrintReport.Text = "چاپ گزارش";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Accounting.App.Properties.Resources.icons8_refresh_40_removebg_preview;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 69);
            this.btnRefresh.Text = "بروزرسانی";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // stiReport
            // 
            this.stiReport.CookieContainer = null;
            this.stiReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport.ReportAlias = "Report";
            this.stiReport.ReportGuid = "12b667f2d3d84a7fb327c4eb31d70554";
            this.stiReport.ReportName = "Report";
            this.stiReport.ReportSource = null;
            this.stiReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport.UseProgressInThread = false;
            // 
            // FrmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 424);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransaction";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تراکنش ها";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoRecieve;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.RadioButton rdoPay;
        private System.Windows.Forms.RadioButton rdoPayOrRecieve;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.MaskedTextBox mtxToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEditTransaction;
        private System.Windows.Forms.ToolStripButton btnRemoveTransaction;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.ToolStripButton btnPrintReport;
        private Stimulsoft.Report.StiReport stiReport;
    }
}