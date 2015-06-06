namespace TheAltisProjectEditorCargo
{
    partial class EditDialog
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
            this.lblCargoId = new System.Windows.Forms.Label();
            this.lblCargoType = new System.Windows.Forms.Label();
            this.lblCargoData = new System.Windows.Forms.Label();
            this.txtCargoId = new System.Windows.Forms.TextBox();
            this.txtCargoData = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbCargoType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCargoId
            // 
            this.lblCargoId.AutoSize = true;
            this.lblCargoId.Location = new System.Drawing.Point(12, 9);
            this.lblCargoId.Name = "lblCargoId";
            this.lblCargoId.Size = new System.Drawing.Size(45, 13);
            this.lblCargoId.TabIndex = 0;
            this.lblCargoId.Text = "cargo id";
            // 
            // lblCargoType
            // 
            this.lblCargoType.AutoSize = true;
            this.lblCargoType.Location = new System.Drawing.Point(12, 48);
            this.lblCargoType.Name = "lblCargoType";
            this.lblCargoType.Size = new System.Drawing.Size(57, 13);
            this.lblCargoType.TabIndex = 1;
            this.lblCargoType.Text = "cargo type";
            // 
            // lblCargoData
            // 
            this.lblCargoData.AutoSize = true;
            this.lblCargoData.Location = new System.Drawing.Point(12, 88);
            this.lblCargoData.Name = "lblCargoData";
            this.lblCargoData.Size = new System.Drawing.Size(58, 13);
            this.lblCargoData.TabIndex = 2;
            this.lblCargoData.Text = "cargo data";
            // 
            // txtCargoId
            // 
            this.txtCargoId.Location = new System.Drawing.Point(12, 25);
            this.txtCargoId.Name = "txtCargoId";
            this.txtCargoId.Size = new System.Drawing.Size(473, 20);
            this.txtCargoId.TabIndex = 5;
            // 
            // txtCargoData
            // 
            this.txtCargoData.Location = new System.Drawing.Point(12, 104);
            this.txtCargoData.Name = "txtCargoData";
            this.txtCargoData.Size = new System.Drawing.Size(473, 20);
            this.txtCargoData.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(329, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(410, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbCargoType
            // 
            this.cmbCargoType.FormattingEnabled = true;
            this.cmbCargoType.Items.AddRange(new object[] {
            "WPN",
            "MAG",
            "ITM",
            "BKP"});
            this.cmbCargoType.Location = new System.Drawing.Point(12, 64);
            this.cmbCargoType.Name = "cmbCargoType";
            this.cmbCargoType.Size = new System.Drawing.Size(473, 21);
            this.cmbCargoType.TabIndex = 12;
            // 
            // EditDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(497, 170);
            this.Controls.Add(this.cmbCargoType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCargoData);
            this.Controls.Add(this.txtCargoId);
            this.Controls.Add(this.lblCargoData);
            this.Controls.Add(this.lblCargoType);
            this.Controls.Add(this.lblCargoId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCargoId;
        private System.Windows.Forms.Label lblCargoType;
        private System.Windows.Forms.Label lblCargoData;
        private System.Windows.Forms.TextBox txtCargoId;
        private System.Windows.Forms.TextBox txtCargoData;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbCargoType;
    }
}