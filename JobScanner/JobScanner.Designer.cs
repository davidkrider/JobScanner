namespace JobScanner
{
    partial class FormJobScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobScanner));
            this.labelVim = new System.Windows.Forms.Label();
            this.textBoxVim = new System.Windows.Forms.TextBox();
            this.textBoxEmployee = new System.Windows.Forms.TextBox();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.textBoxLot = new System.Windows.Forms.TextBox();
            this.labelLot = new System.Windows.Forms.Label();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelVim
            // 
            this.labelVim.AutoSize = true;
            this.labelVim.Location = new System.Drawing.Point(12, 9);
            this.labelVim.Name = "labelVim";
            this.labelVim.Size = new System.Drawing.Size(26, 13);
            this.labelVim.TabIndex = 2;
            this.labelVim.Text = "VIM";
            // 
            // textBoxVim
            // 
            this.textBoxVim.Location = new System.Drawing.Point(91, 6);
            this.textBoxVim.Name = "textBoxVim";
            this.textBoxVim.Size = new System.Drawing.Size(181, 20);
            this.textBoxVim.TabIndex = 3;
            // 
            // textBoxEmployee
            // 
            this.textBoxEmployee.Location = new System.Drawing.Point(91, 32);
            this.textBoxEmployee.Name = "textBoxEmployee";
            this.textBoxEmployee.Size = new System.Drawing.Size(181, 20);
            this.textBoxEmployee.TabIndex = 5;
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Location = new System.Drawing.Point(12, 35);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(53, 13);
            this.labelEmployee.TabIndex = 4;
            this.labelEmployee.Text = "Employee";
            // 
            // textBoxLot
            // 
            this.textBoxLot.Location = new System.Drawing.Point(91, 58);
            this.textBoxLot.Name = "textBoxLot";
            this.textBoxLot.Size = new System.Drawing.Size(181, 20);
            this.textBoxLot.TabIndex = 7;
            // 
            // labelLot
            // 
            this.labelLot.AutoSize = true;
            this.labelLot.Location = new System.Drawing.Point(12, 61);
            this.labelLot.Name = "labelLot";
            this.labelLot.Size = new System.Drawing.Size(22, 13);
            this.labelLot.TabIndex = 6;
            this.labelLot.Text = "Lot";
            // 
            // textBoxItem
            // 
            this.textBoxItem.Location = new System.Drawing.Point(91, 84);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(181, 20);
            this.textBoxItem.TabIndex = 9;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(12, 87);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(27, 13);
            this.labelItem.TabIndex = 8;
            this.labelItem.Text = "Item";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(91, 110);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(181, 20);
            this.textBoxQuantity.TabIndex = 11;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(12, 113);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelQuantity.TabIndex = 10;
            this.labelQuantity.Text = "Quantity";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(197, 147);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormJobScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.textBoxItem);
            this.Controls.Add(this.labelItem);
            this.Controls.Add(this.textBoxLot);
            this.Controls.Add(this.labelLot);
            this.Controls.Add(this.textBoxEmployee);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.textBoxVim);
            this.Controls.Add(this.labelVim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJobScanner";
            this.Text = "Job Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVim;
        private System.Windows.Forms.TextBox textBoxVim;
        private System.Windows.Forms.TextBox textBoxEmployee;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.TextBox textBoxLot;
        private System.Windows.Forms.Label labelLot;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Button buttonSend;
    }
}

