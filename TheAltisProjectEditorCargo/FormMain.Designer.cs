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
            this.lblCargoId = new System.Windows.Forms.Label();
            this.lblCargoType = new System.Windows.Forms.Label();
            this.cmbCargoType = new System.Windows.Forms.ComboBox();
            this.lblCargoData = new System.Windows.Forms.Label();
            this.lstCargoData = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDeleteCargoId = new System.Windows.Forms.ToolStripButton();
            this.tlblSpacer1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDeleteCargoSingle = new System.Windows.Forms.ToolStripButton();
            this.tbtnDeleteCargoType = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCargoId
            // 
            this.lstCargoId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCargoId.FormattingEnabled = true;
            this.lstCargoId.IntegralHeight = false;
            this.lstCargoId.Location = new System.Drawing.Point(12, 40);
            this.lstCargoId.Name = "lstCargoId";
            this.lstCargoId.Size = new System.Drawing.Size(218, 520);
            this.lstCargoId.TabIndex = 0;
            this.lstCargoId.SelectedIndexChanged += new System.EventHandler(this.lstCargoId_SelectedIndexChanged);
            // 
            // lblCargoId
            // 
            this.lblCargoId.AutoSize = true;
            this.lblCargoId.Location = new System.Drawing.Point(9, 24);
            this.lblCargoId.Name = "lblCargoId";
            this.lblCargoId.Size = new System.Drawing.Size(45, 13);
            this.lblCargoId.TabIndex = 1;
            this.lblCargoId.Text = "cargo id";
            // 
            // lblCargoType
            // 
            this.lblCargoType.AutoSize = true;
            this.lblCargoType.Location = new System.Drawing.Point(236, 24);
            this.lblCargoType.Name = "lblCargoType";
            this.lblCargoType.Size = new System.Drawing.Size(57, 13);
            this.lblCargoType.TabIndex = 2;
            this.lblCargoType.Text = "cargo type";
            // 
            // cmbCargoType
            // 
            this.cmbCargoType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCargoType.FormattingEnabled = true;
            this.cmbCargoType.Items.AddRange(new object[] {
            "WPN",
            "MAG",
            "ITM",
            "BKP"});
            this.cmbCargoType.Location = new System.Drawing.Point(236, 40);
            this.cmbCargoType.Name = "cmbCargoType";
            this.cmbCargoType.Size = new System.Drawing.Size(715, 21);
            this.cmbCargoType.TabIndex = 3;
            this.cmbCargoType.TextChanged += new System.EventHandler(this.cmbCargoType_TextChanged);
            // 
            // lblCargoData
            // 
            this.lblCargoData.AutoSize = true;
            this.lblCargoData.Location = new System.Drawing.Point(233, 64);
            this.lblCargoData.Name = "lblCargoData";
            this.lblCargoData.Size = new System.Drawing.Size(58, 13);
            this.lblCargoData.TabIndex = 4;
            this.lblCargoData.Text = "cargo data";
            // 
            // lstCargoData
            // 
            this.lstCargoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCargoData.FormattingEnabled = true;
            this.lstCargoData.IntegralHeight = false;
            this.lstCargoData.Location = new System.Drawing.Point(236, 80);
            this.lstCargoData.Name = "lstCargoData";
            this.lstCargoData.Size = new System.Drawing.Size(715, 480);
            this.lstCargoData.TabIndex = 5;
            this.lstCargoData.SelectedIndexChanged += new System.EventHandler(this.lstCargoData_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnReload,
            this.toolStripSeparator3,
            this.tbtnDeleteCargoId,
            this.tlblSpacer1,
            this.toolStripSeparator1,
            this.tbtnEdit,
            this.tbtnAdd,
            this.toolStripSeparator2,
            this.tbtnDeleteCargoSingle,
            this.tbtnDeleteCargoType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(963, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnReload
            // 
            this.tbtnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnReload.Image = ((System.Drawing.Image)(resources.GetObject("tbtnReload.Image")));
            this.tbtnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnReload.Name = "tbtnReload";
            this.tbtnReload.Size = new System.Drawing.Size(23, 22);
            this.tbtnReload.Text = "reload";
            this.tbtnReload.Click += new System.EventHandler(this.tbtnReload_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDeleteCargoId
            // 
            this.tbtnDeleteCargoId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoId.Enabled = false;
            this.tbtnDeleteCargoId.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoId.Image")));
            this.tbtnDeleteCargoId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoId.Name = "tbtnDeleteCargoId";
            this.tbtnDeleteCargoId.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoId.Text = "delete (this cargo id)";
            this.tbtnDeleteCargoId.Click += new System.EventHandler(this.tbtnDeleteCargoId_Click);
            // 
            // tlblSpacer1
            // 
            this.tlblSpacer1.AutoSize = false;
            this.tlblSpacer1.Name = "tlblSpacer1";
            this.tlblSpacer1.Size = new System.Drawing.Size(175, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnEdit
            // 
            this.tbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnEdit.Enabled = false;
            this.tbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tbtnEdit.Image")));
            this.tbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnEdit.Name = "tbtnEdit";
            this.tbtnEdit.Size = new System.Drawing.Size(23, 22);
            this.tbtnEdit.Text = "edit";
            this.tbtnEdit.Click += new System.EventHandler(this.tbtnEdit_Click);
            // 
            // tbtnAdd
            // 
            this.tbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAdd.Image")));
            this.tbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAdd.Name = "tbtnAdd";
            this.tbtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tbtnAdd.Text = "add";
            this.tbtnAdd.Click += new System.EventHandler(this.tbtnAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDeleteCargoSingle
            // 
            this.tbtnDeleteCargoSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoSingle.Enabled = false;
            this.tbtnDeleteCargoSingle.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoSingle.Image")));
            this.tbtnDeleteCargoSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoSingle.Name = "tbtnDeleteCargoSingle";
            this.tbtnDeleteCargoSingle.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoSingle.Text = "delete (this data)";
            this.tbtnDeleteCargoSingle.Click += new System.EventHandler(this.tbtnDeleteCargoSingle_Click);
            // 
            // tbtnDeleteCargoType
            // 
            this.tbtnDeleteCargoType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteCargoType.Enabled = false;
            this.tbtnDeleteCargoType.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteCargoType.Image")));
            this.tbtnDeleteCargoType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteCargoType.Name = "tbtnDeleteCargoType";
            this.tbtnDeleteCargoType.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteCargoType.Text = "delete (this cargo type)";
            this.tbtnDeleteCargoType.Click += new System.EventHandler(this.tbtnDeleteCargoType_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 572);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstCargoData);
            this.Controls.Add(this.lblCargoData);
            this.Controls.Add(this.cmbCargoType);
            this.Controls.Add(this.lblCargoType);
            this.Controls.Add(this.lblCargoId);
            this.Controls.Add(this.lstCargoId);
            this.Name = "FormMain";
            this.Text = "The Altis Project Editor (CARGO)";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCargoId;
        private System.Windows.Forms.Label lblCargoId;
        private System.Windows.Forms.Label lblCargoType;
        private System.Windows.Forms.ComboBox cmbCargoType;
        private System.Windows.Forms.Label lblCargoData;
        private System.Windows.Forms.ListBox lstCargoData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnReload;
        private System.Windows.Forms.ToolStripLabel tlblSpacer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoType;
        private System.Windows.Forms.ToolStripButton tbtnEdit;
        private System.Windows.Forms.ToolStripButton tbtnAdd;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnDeleteCargoSingle;
    }
}

