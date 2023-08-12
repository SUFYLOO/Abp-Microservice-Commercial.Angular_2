namespace AbpLanguageTranslatorTools
{
    partial class FrmMain
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cdLanguageSource = new System.Windows.Forms.ComboBox();
            this.cbLanguageDestination = new System.Windows.Forms.ComboBox();
            this.btnTranslation = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvColumns);
            this.scMain.Size = new System.Drawing.Size(1154, 640);
            this.scMain.SplitterDistance = 51;
            this.scMain.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnUpload);
            this.flowLayoutPanel1.Controls.Add(this.cdLanguageSource);
            this.flowLayoutPanel1.Controls.Add(this.cbLanguageDestination);
            this.flowLayoutPanel1.Controls.Add(this.btnTranslation);
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1154, 51);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(3, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(108, 45);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "選取檔案...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cdLanguageSource
            // 
            this.cdLanguageSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cdLanguageSource.FormattingEnabled = true;
            this.cdLanguageSource.Location = new System.Drawing.Point(118, 4);
            this.cdLanguageSource.Margin = new System.Windows.Forms.Padding(4);
            this.cdLanguageSource.Name = "cdLanguageSource";
            this.cdLanguageSource.Size = new System.Drawing.Size(178, 23);
            this.cdLanguageSource.TabIndex = 9;
            // 
            // cbLanguageDestination
            // 
            this.cbLanguageDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageDestination.FormattingEnabled = true;
            this.cbLanguageDestination.Location = new System.Drawing.Point(304, 4);
            this.cbLanguageDestination.Margin = new System.Windows.Forms.Padding(4);
            this.cbLanguageDestination.Name = "cbLanguageDestination";
            this.cbLanguageDestination.Size = new System.Drawing.Size(178, 23);
            this.cbLanguageDestination.TabIndex = 10;
            // 
            // btnTranslation
            // 
            this.btnTranslation.Enabled = false;
            this.btnTranslation.Location = new System.Drawing.Point(489, 3);
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.Size = new System.Drawing.Size(108, 45);
            this.btnTranslation.TabIndex = 11;
            this.btnTranslation.Text = "翻譯";
            this.btnTranslation.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(603, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 45);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "匯出檔案";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(0, 0);
            this.dgvColumns.Margin = new System.Windows.Forms.Padding(4);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersWidth = 51;
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(1154, 585);
            this.dgvColumns.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 640);
            this.Controls.Add(this.scMain);
            this.Name = "FrmMain";
            this.Text = "Abp語文檔翻譯工具";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ComboBox cdLanguageSource;
        private System.Windows.Forms.ComboBox cbLanguageDestination;
        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvColumns;
    }
}