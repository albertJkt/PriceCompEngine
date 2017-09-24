namespace PriceCompEngn
{
    partial class OCREngine
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btOCR = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btOCR
            // 
            this.btOCR.Location = new System.Drawing.Point(12, 37);
            this.btOCR.Name = "btOCR";
            this.btOCR.Size = new System.Drawing.Size(199, 23);
            this.btOCR.TabIndex = 0;
            this.btOCR.Text = "OCR";
            this.btOCR.UseVisualStyleBackColor = true;
            this.btOCR.Click += new System.EventHandler(this.btOCR_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 123);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(463, 436);
            this.txtBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 567);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btOCR);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btOCR;
        private System.Windows.Forms.TextBox txtBox;
    }
}

