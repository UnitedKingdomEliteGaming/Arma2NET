namespace Arma2NetSimulator
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
            this.lblCommand = new System.Windows.Forms.Label();
            this.btnCommand = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(12, 9);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 1;
            this.lblCommand.Text = "Command";
            // 
            // btnCommand
            // 
            this.btnCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommand.Location = new System.Drawing.Point(434, 23);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(75, 23);
            this.btnCommand.TabIndex = 2;
            this.btnCommand.Text = "execute";
            this.btnCommand.UseVisualStyleBackColor = true;
            this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.IntegralHeight = false;
            this.lstResult.Location = new System.Drawing.Point(15, 52);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(494, 252);
            this.lstResult.TabIndex = 5;
            // 
            // cmbCommand
            // 
            this.cmbCommand.FormattingEnabled = true;
            this.cmbCommand.Items.AddRange(new object[] {
            "TAP item|init|testtable",
            "TAP item|updateinsert|testtable|uweid|uwedata",
            "TAP item|update|testtable|uweid|uwedata",
            "TAP item|select|testtable|uweid",
            "TAP item|delete|testtable|uweid",
            "TAP wbox|insert|boxid|WPN|weaponData",
            "TAP wbox|insert|boxid|MAG|weaponData",
            "TAP wbox|select|boxid|MAG",
            "TAP wbox|selectnext",
            "TAP wbox|deletetype|boxid|MAG",
            "TAP wbox|deleteall|boxid",
            "datetime now"});
            this.cmbCommand.Location = new System.Drawing.Point(15, 25);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(413, 21);
            this.cmbCommand.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 316);
            this.Controls.Add(this.cmbCommand);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnCommand);
            this.Controls.Add(this.lblCommand);
            this.Name = "FormMain";
            this.Text = "Arma2Net Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.ComboBox cmbCommand;
    }
}

