namespace TheAltisProjectEditorCargo
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lstCargoId = new System.Windows.Forms.ListBox();
            this.cmbCargoType = new System.Windows.Forms.ComboBox();
            this.lstCargoData = new System.Windows.Forms.ListBox();
            this.pnlCargoId = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnRefreshCargoId = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDeleteCargoId = new System.Windows.Forms.ToolStripButton();
            this.pnlCargoData = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tbtnRefreshCargoData = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnEditCargoData = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddCargoData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDeleteCargoDataSingle = new System.Windows.Forms.ToolStripButton();
            this.tbtnDeleteCargoDataType = new System.Windows.Forms.ToolStripButton();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlblTable = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnRefreshTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDropTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddTestTable = new System.Windows.Forms.ToolStripButton();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.pnlCargoType = new System.Windows.Forms.Panel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlCargoId.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pnlCargoData.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.pnlTable.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlCargoType.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCargoId
            // 
            this.lstCargoId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCargoId.FormattingEnabled = true;
            this.lstCargoId.IntegralHeight = false;
            this.lstCargoId.Location = new System.Drawing.Point(0, 25);
            this.lstCargoId.Name = "lstCargoId";
            this.lstCargoId.Size = new System.Drawing.Size(215, 486);
            this.lstCargoId.TabIndex = 0;
            this.lstCargoId.SelectedIndexChanged += new System.EventHandler(this.lstCargoId_SelectedIndexChanged);
            // 
            // cmbCargoType
            // 
            this.cmbCargoType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbCargoType.FormattingEnabled = true;
            this.cmbCargoType.Items.AddRange(new object[] {
            "WPN",
            "MAG",
            "ITM",
            "BKP"});
            this.cmbCargoType.Location = new System.Drawing.Point(0, 25);
            this.cmbCargoType.Name = "cmbCargoType";
            this.cmbCargoType.Size = new System.Drawing.Size(723, 21);
            this.cmbCargoType.TabIndex = 3;
            this.cmbCargoType.TextChanged += new System.EventHandler(this.cmbCargoType_TextChanged);
            // 
            // lstCargoData
            // 
            this.lstCargoData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCargoData.FormattingEnabled = true;
            this.lstCargoData.IntegralHeight = false;
            this.lstCargoData.Location = new System.Drawing.Point(0, 25);
            this.lstCargoData.Name = "lstCargoData";
            this.lstCargoData.Size = new System.Drawing.Size(723, 486);
            this.lstCargoData.TabIndex = 5;
            this.lstCargoData.SelectedIndexChanged += new System.EventHandler(this.lstCargoData_SelectedIndexChanged);
            this.lstCargoData.DoubleClick += new System.EventHandler(this.lstCargoData_DoubleClick);
            // 
            // pnlCargoId
            // 
            this.pnlCargoId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCargoId.Controls.Add(this.lstCargoId);
            this.pnlCargoId.Controls.Add(this.toolStrip2);
            this.pnlCargoId.Location = new System.Drawing.Point(12, 64);
            this.pnlCargoId.Name = "pnlCargoId";
            this.pnlCargoId.Size = new System.Drawing.Size(215, 511);
            this.pnlCargoId.TabIndex = 10;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.tbtnRefreshCargoId,
            this.toolStripSeparator4,
            this.tbtnDeleteCargoId});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(215, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Cargo Id";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnRefreshCargoId
            // 
            this.tbtnRefreshCargoId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnRefreshCargoId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRefreshCargoId.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefreshCargoId.Image")));
            this.tbtnRefreshCargoId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefreshCargoId.Name = "tbtnRefreshCargoId";
            this.tbtnRefreshCargoId.Size = new System.Drawing.Size(23, 22);
            this.tbtnRefreshCargoId.Text = "reload";
            this.tbtnRefreshCargoId.Click += new System.EventHandler(this.tbtnRefreshCargoId_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDeleteCargoId
            // 
            this.tbtnDeleteCargoId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnDeleteCargoId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoId.Enabled = false;
            this.tbtnDeleteCargoId.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoId.Image")));
            this.tbtnDeleteCargoId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoId.Name = "tbtnDeleteCargoId";
            this.tbtnDeleteCargoId.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoId.Text = "delete";
            this.tbtnDeleteCargoId.Click += new System.EventHandler(this.tbtnDeleteCargoId_Click);
            // 
            // pnlCargoData
            // 
            this.pnlCargoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCargoData.Controls.Add(this.lstCargoData);
            this.pnlCargoData.Controls.Add(this.toolStrip3);
            this.pnlCargoData.Location = new System.Drawing.Point(233, 64);
            this.pnlCargoData.Name = "pnlCargoData";
            this.pnlCargoData.Size = new System.Drawing.Size(723, 511);
            this.pnlCargoData.TabIndex = 11;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnRefreshCargoData,
            this.toolStripLabel2,
            this.toolStripSeparator6,
            this.tbtnEditCargoData,
            this.tbtnAddCargoData,
            this.toolStripSeparator8,
            this.tbtnDeleteCargoDataSingle,
            this.tbtnDeleteCargoDataType});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(723, 25);
            this.toolStrip3.TabIndex = 7;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tbtnRefreshCargoData
            // 
            this.tbtnRefreshCargoData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnRefreshCargoData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRefreshCargoData.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefreshCargoData.Image")));
            this.tbtnRefreshCargoData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefreshCargoData.Name = "tbtnRefreshCargoData";
            this.tbtnRefreshCargoData.Size = new System.Drawing.Size(23, 22);
            this.tbtnRefreshCargoData.Text = "reload";
            this.tbtnRefreshCargoData.Click += new System.EventHandler(this.tbtnRefreshCargoData_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel2.Text = "Cargo Data";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnEditCargoData
            // 
            this.tbtnEditCargoData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnEditCargoData.Enabled = false;
            this.tbtnEditCargoData.Image = ((System.Drawing.Image)(resources.GetObject("tbtnEditCargoData.Image")));
            this.tbtnEditCargoData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnEditCargoData.Name = "tbtnEditCargoData";
            this.tbtnEditCargoData.Size = new System.Drawing.Size(23, 22);
            this.tbtnEditCargoData.Text = "edit";
            this.tbtnEditCargoData.Click += new System.EventHandler(this.tbtnEditCargoData_Click);
            // 
            // tbtnAddCargoData
            // 
            this.tbtnAddCargoData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddCargoData.Enabled = false;
            this.tbtnAddCargoData.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddCargoData.Image")));
            this.tbtnAddCargoData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddCargoData.Name = "tbtnAddCargoData";
            this.tbtnAddCargoData.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddCargoData.Text = "add";
            this.tbtnAddCargoData.Click += new System.EventHandler(this.tbtnAddCargoData_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDeleteCargoDataSingle
            // 
            this.tbtnDeleteCargoDataSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoDataSingle.Enabled = false;
            this.tbtnDeleteCargoDataSingle.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoDataSingle.Image")));
            this.tbtnDeleteCargoDataSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoDataSingle.Name = "tbtnDeleteCargoDataSingle";
            this.tbtnDeleteCargoDataSingle.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoDataSingle.Text = "delete (single)";
            this.tbtnDeleteCargoDataSingle.Click += new System.EventHandler(this.tbtnDeleteCargoDataSingle_Click);
            // 
            // tbtnDeleteCargoDataType
            // 
            this.tbtnDeleteCargoDataType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoDataType.Enabled = false;
            this.tbtnDeleteCargoDataType.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoDataType.Image")));
            this.tbtnDeleteCargoDataType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoDataType.Name = "tbtnDeleteCargoDataType";
            this.tbtnDeleteCargoDataType.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoDataType.Text = "delete (all)";
            this.tbtnDeleteCargoDataType.Click += new System.EventHandler(this.tbtnDeleteCargoDataType_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.Controls.Add(this.toolStrip1);
            this.pnlTable.Controls.Add(this.cmbTable);
            this.pnlTable.Location = new System.Drawing.Point(12, 12);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(215, 46);
            this.pnlTable.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblTable,
            this.toolStripSeparator1,
            this.tbtnRefreshTable,
            this.toolStripSeparator2,
            this.tbtnAddTestTable,
            this.tbtnDropTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(215, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlblTable
            // 
            this.tlblTable.Name = "tlblTable";
            this.tlblTable.Size = new System.Drawing.Size(36, 22);
            this.tlblTable.Text = "Table";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnRefreshTable
            // 
            this.tbtnRefreshTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnRefreshTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRefreshTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefreshTable.Image")));
            this.tbtnRefreshTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefreshTable.Name = "tbtnRefreshTable";
            this.tbtnRefreshTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnRefreshTable.Text = "reload";
            this.tbtnRefreshTable.Click += new System.EventHandler(this.tbtnRefreshTable_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDropTable
            // 
            this.tbtnDropTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnDropTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDropTable.Enabled = false;
            this.tbtnDropTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDropTable.Image")));
            this.tbtnDropTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDropTable.Name = "tbtnDropTable";
            this.tbtnDropTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnDropTable.Text = "delete";
            this.tbtnDropTable.Click += new System.EventHandler(this.tbtnDropTable_Click);
            // 
            // tbtnAddTestTable
            // 
            this.tbtnAddTestTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnAddTestTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddTestTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddTestTable.Image")));
            this.tbtnAddTestTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddTestTable.Name = "tbtnAddTestTable";
            this.tbtnAddTestTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddTestTable.Text = "add \"test\" table";
            this.tbtnAddTestTable.Click += new System.EventHandler(this.tbtnAddTestTable_Click);
            // 
            // cmbTable
            // 
            this.cmbTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(0, 25);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(215, 21);
            this.cmbTable.TabIndex = 12;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // pnlCargoType
            // 
            this.pnlCargoType.Controls.Add(this.toolStrip4);
            this.pnlCargoType.Controls.Add(this.cmbCargoType);
            this.pnlCargoType.Location = new System.Drawing.Point(233, 12);
            this.pnlCargoType.Name = "pnlCargoType";
            this.pnlCargoType.Size = new System.Drawing.Size(723, 46);
            this.pnlCargoType.TabIndex = 13;
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripSeparator3});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(723, 25);
            this.toolStrip4.TabIndex = 14;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel3.Text = "Cargo Type";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 587);
            this.Controls.Add(this.pnlCargoType);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlCargoData);
            this.Controls.Add(this.pnlCargoId);
            this.Name = "FormMain";
            this.Text = "The Altis Project Editor (CARGO)";
            this.pnlCargoId.ResumeLayout(false);
            this.pnlCargoId.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlCargoData.ResumeLayout(false);
            this.pnlCargoData.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlCargoType.ResumeLayout(false);
            this.pnlCargoType.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCargoId;
        private System.Windows.Forms.ComboBox cmbCargoType;
        private System.Windows.Forms.ListBox lstCargoData;
        private System.Windows.Forms.Panel pnlCargoId;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbtnRefreshCargoId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoId;
        private System.Windows.Forms.Panel pnlCargoData;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tbtnRefreshCargoData;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tbtnEditCargoData;
        private System.Windows.Forms.ToolStripButton tbtnAddCargoData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoDataSingle;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoDataType;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tlblTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnRefreshTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnDropTable;
        private System.Windows.Forms.Panel pnlCargoType;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbtnAddTestTable;
    }
}

