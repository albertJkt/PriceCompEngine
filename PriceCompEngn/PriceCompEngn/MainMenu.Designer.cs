namespace PriceCompEngn
{
    partial class MainMenu
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
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.btnAfterShop = new System.Windows.Forms.Button();
            this.btnBeforeShop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(12, 12);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(477, 176);
            this.pb1.TabIndex = 1;
            this.pb1.TabStop = false;
            // 
            // btnAfterShop
            // 
            this.btnAfterShop.Location = new System.Drawing.Point(12, 413);
            this.btnAfterShop.Name = "btnAfterShop";
            this.btnAfterShop.Size = new System.Drawing.Size(213, 56);
            this.btnAfterShop.TabIndex = 2;
            this.btnAfterShop.Text = "Buvau parduotuvėje";
            this.btnAfterShop.UseVisualStyleBackColor = true;
            this.btnAfterShop.Click += new System.EventHandler(this.btnAfterShop_Click);
            // 
            // btnBeforeShop
            // 
            this.btnBeforeShop.Location = new System.Drawing.Point(276, 413);
            this.btnBeforeShop.Name = "btnBeforeShop";
            this.btnBeforeShop.Size = new System.Drawing.Size(213, 56);
            this.btnBeforeShop.TabIndex = 3;
            this.btnBeforeShop.Text = "Einu į parduotuvę";
            this.btnBeforeShop.UseVisualStyleBackColor = true;
            this.btnBeforeShop.Click += new System.EventHandler(this.btnBeforeShop_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 501);
            this.Controls.Add(this.btnBeforeShop);
            this.Controls.Add(this.btnAfterShop);
            this.Controls.Add(this.pb1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Button btnAfterShop;
        private System.Windows.Forms.Button btnBeforeShop;
    }
}