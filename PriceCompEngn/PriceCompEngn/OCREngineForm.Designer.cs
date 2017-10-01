namespace PriceCompEngn
{
    partial class OCREngineForm
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
            this.Upload_button = new System.Windows.Forms.Button();
            this.Uploaded_image = new System.Windows.Forms.PictureBox();
            this.Converted_text = new System.Windows.Forms.RichTextBox();
            this.Read_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Uploaded_image)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload_button
            // 
            this.Upload_button.Location = new System.Drawing.Point(302, 12);
            this.Upload_button.Name = "Upload_button";
            this.Upload_button.Size = new System.Drawing.Size(197, 29);
            this.Upload_button.TabIndex = 0;
            this.Upload_button.Text = "Select image";
            this.Upload_button.UseVisualStyleBackColor = true;
            this.Upload_button.Click += new System.EventHandler(this.Upload_button_Click);
            // 
            // Uploaded_image
            // 
            this.Uploaded_image.Location = new System.Drawing.Point(12, 67);
            this.Uploaded_image.MaximumSize = new System.Drawing.Size(290, 447);
            this.Uploaded_image.MinimumSize = new System.Drawing.Size(290, 447);
            this.Uploaded_image.Name = "Uploaded_image";
            this.Uploaded_image.Size = new System.Drawing.Size(290, 447);
            this.Uploaded_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Uploaded_image.TabIndex = 1;
            this.Uploaded_image.TabStop = false;
            // 
            // Converted_text
            // 
            this.Converted_text.Location = new System.Drawing.Point(458, 67);
            this.Converted_text.Name = "Converted_text";
            this.Converted_text.Size = new System.Drawing.Size(309, 447);
            this.Converted_text.TabIndex = 2;
            this.Converted_text.Text = "";
            // 
            // Read_button
            // 
            this.Read_button.Location = new System.Drawing.Point(308, 129);
            this.Read_button.Name = "Read_button";
            this.Read_button.Size = new System.Drawing.Size(144, 23);
            this.Read_button.TabIndex = 3;
            this.Read_button.Text = "Read text";
            this.Read_button.UseVisualStyleBackColor = true;
            this.Read_button.Click += new System.EventHandler(this.Read_button_Click);
            // 
            // OCREngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 584);
            this.Controls.Add(this.Read_button);
            this.Controls.Add(this.Converted_text);
            this.Controls.Add(this.Uploaded_image);
            this.Controls.Add(this.Upload_button);
            this.Name = "OCREngineForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Uploaded_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Upload_button;
        private System.Windows.Forms.PictureBox Uploaded_image;
        private System.Windows.Forms.RichTextBox Converted_text;
        private System.Windows.Forms.Button Read_button;
    }
}

