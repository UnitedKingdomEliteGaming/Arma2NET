namespace TheAltisProjectEditorItem
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
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.clhItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhItemData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTable = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDropTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnRefreshTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddTestTable = new System.Windows.Forms.ToolStripButton();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tbtnRefreshItems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAddItem = new System.Windows.Forms.ToolStripButton();
            this.tbtnEditItem = new System.Windows.Forms.ToolStripButton();
            this.pnlTable.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTable
            // 
            this.cmbTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(0, 25);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(1012, 21);
            this.cmbTable.TabIndex = 8;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // lvwItems
            // 
            this.lvwItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhItemId,
            this.clhItemData});
            this.lvwItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.GridLines = true;
            this.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwItems.Location = new System.Drawing.Point(0, 25);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(1012, 560);
            this.lvwItems.TabIndex = 10;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            this.lvwItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwItems_MouseDoubleClick);
            // 
            // clhItemId
            // 
            this.clhItemId.Text = "Id";
            this.clhItemId.Width = 200;
            // 
            // clhItemData
            // 
            this.clhItemData.Text = "Data";
            this.clhItemData.Width = 780;
            // 
            // pnlTable
            // 
            this.pnlTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTable.Controls.Add(this.toolStrip2);
            this.pnlTable.Controls.Add(this.cmbTable);
            this.pnlTable.Location = new System.Drawing.Point(12, 12);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(1012, 46);
            this.pnlTable.TabIndex = 11;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tbtnDropTable,
            this.tbtnRefreshTable,
            this.tbtnAddTestTable});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1012, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Table";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDropTable
            // 
            this.tbtnDropTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDropTable.Enabled = false;
            this.tbtnDropTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDropTable.Image")));
            this.tbtnDropTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDropTable.Name = "tbtnDropTable";
            this.tbtnDropTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnDropTable.Text = "delete table";
            this.tbtnDropTable.Click += new System.EventHandler(this.tbtnDropTable_Click);
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
            // tbtnAddTestTable
            // 
            this.tbtnAddTestTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddTestTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddTestTable.Image")));
            this.tbtnAddTestTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddTestTable.Name = "tbtnAddTestTable";
            this.tbtnAddTestTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddTestTable.Text = "add \"test\" table";
            this.tbtnAddTestTable.Click += new System.EventHandler(this.tbtnAddTestTable_Click);
            // 
            // pnlItems
            // 
            this.pnlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItems.Controls.Add(this.lvwItems);
            this.pnlItems.Controls.Add(this.toolStrip1);
            this.pnlItems.Location = new System.Drawing.Point(12, 64);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(1012, 585);
            this.pnlItems.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.tbtnDeleteItem,
            this.tbtnRefreshItems,
            this.toolStripSeparator3,
            this.tbtnAddItem,
            this.tbtnEditItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1012, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "Items";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnDeleteItem
            // 
            this.tbtnDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDeleteItem.Enabled = false;
            this.tbtnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDeleteItem.Image")));
            this.tbtnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDeleteItem.Name = "tbtnDeleteItem";
            this.tbtnDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.tbtnDeleteItem.Text = "delete item";
            this.tbtnDeleteItem.Click += new System.EventHandler(this.tbtnDeleteItem_Click);
            // 
            // tbtnRefreshItems
            // 
            this.tbtnRefreshItems.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnRefreshItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRefreshItems.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefreshItems.Image")));
            this.tbtnRefreshItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefreshItems.Name = "tbtnRefreshItems";
            this.tbtnRefreshItems.Size = new System.Drawing.Size(23, 22);
            this.tbtnRefreshItems.Text = "reload";
            this.tbtnRefreshItems.Click += new System.EventHandler(this.tbtnRefreshItems_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnAddItem
            // 
            this.tbtnAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddItem.Enabled = false;
            this.tbtnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAddItem.Image")));
            this.tbtnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddItem.Name = "tbtnAddItem";
            this.tbtnAddItem.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddItem.Text = "add";
            this.tbtnAddItem.Click += new System.EventHandler(this.tbtnAddItem_Click);
            // 
            // tbtnEditItem
            // 
            this.tbtnEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnEditItem.Enabled = false;
            this.tbtnEditItem.Image = ((System.Drawing.Image)(resources.GetObject("tbtnEditItem.Image")));
            this.tbtnEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnEditItem.Name = "tbtnEditItem";
            this.tbtnEditItem.Size = new System.Drawing.Size(23, 22);
            this.tbtnEditItem.Text = "edit";
            this.tbtnEditItem.Click += new System.EventHandler(this.tbtnEditItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 661);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlTable);
            this.Name = "FormMain";
            this.Text = "The Altis Project Editor (ITEM)";
            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader clhItemId;
        private System.Windows.Forms.ColumnHeader clhItemData;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnDropTable;
        private System.Windows.Forms.ToolStripButton tbtnRefreshTable;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnDeleteItem;
        private System.Windows.Forms.ToolStripButton tbtnRefreshItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbtnAddItem;
        private System.Windows.Forms.ToolStripButton tbtnEditItem;
        private System.Windows.Forms.ToolStripButton tbtnAddTestTable;
    }
}

