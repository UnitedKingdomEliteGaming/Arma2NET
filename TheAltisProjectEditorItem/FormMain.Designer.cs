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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnDropTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.lblTable = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.clhItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhItemData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnDropTable,
            this.tbtnDeleteItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1036, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnDropTable
            // 
            this.tbtnDropTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDropTable.Enabled = false;
            this.tbtnDropTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDropTable.Image")));
            this.tbtnDropTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDropTable.Name = "tbtnDropTable";
            this.tbtnDropTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnDropTable.Text = "delete (table)";
            this.tbtnDropTable.Click += new System.EventHandler(this.tbtnDropTable_Click);
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
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(12, 25);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(30, 13);
            this.lblTable.TabIndex = 3;
            this.lblTable.Text = "table";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(12, 41);
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
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.GridLines = true;
            this.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwItems.HotTracking = true;
            this.lvwItems.HoverSelection = true;
            this.lvwItems.Location = new System.Drawing.Point(12, 68);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(1012, 581);
            this.lvwItems.TabIndex = 10;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            this.lvwItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwItems_MouseDoubleClick);
            // 
            // clhItemId
            // 
            this.clhItemId.Text = "item id";
            this.clhItemId.Width = 200;
            // 
            // clhItemData
            // 
            this.clhItemData.Text = "item data";
            this.clhItemData.Width = 780;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 661);
            this.Controls.Add(this.lvwItems);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "The Altis Project Editor (ITEM)";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnDropTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader clhItemId;
        private System.Windows.Forms.ColumnHeader clhItemData;
        private System.Windows.Forms.ToolStripButton tbtnDeleteItem;
    }
}

