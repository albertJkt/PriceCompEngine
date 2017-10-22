namespace PriceCompEngn
{
    partial class AfterShop
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.bntUpload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Išsirinkite kvito nuotrauką:\r\n";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(213, 76);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(230, 23);
            this.btnAddImage.TabIndex = 1;
            this.btnAddImage.Text = "Pridėti";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // bntUpload
            // 
            this.bntUpload.Location = new System.Drawing.Point(15, 388);
            this.bntUpload.Name = "bntUpload";
            this.bntUpload.Size = new System.Drawing.Size(428, 23);
            this.bntUpload.TabIndex = 2;
            this.bntUpload.Text = "Įkelti";
            this.bntUpload.UseVisualStyleBackColor = true;
            this.bntUpload.Click += new System.EventHandler(this.bntUpload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(179, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Duomenys sėkmingai patalpinti";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AfterShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntUpload);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label1);
            this.Name = "AfterShop";
            this.Text = "AfterShop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button bntUpload;
        private System.Windows.Forms.Label label2;
    }
}