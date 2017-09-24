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
            this.upload_button = new System.Windows.Forms.Button();
            this.uploaded_image = new System.Windows.Forms.PictureBox();
            this.converted_text = new System.Windows.Forms.RichTextBox();
            this.read_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uploaded_image)).BeginInit();
            this.SuspendLayout();
            // 
            // upload_button
            // 
            this.upload_button.Location = new System.Drawing.Point(302, 12);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(197, 29);
            this.upload_button.TabIndex = 0;
            this.upload_button.Text = "Select image";
            this.upload_button.UseVisualStyleBackColor = true;
            this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
            // 
            // uploaded_image
            // 
            this.uploaded_image.Location = new System.Drawing.Point(12, 67);
            this.uploaded_image.MaximumSize = new System.Drawing.Size(290, 447);
            this.uploaded_image.MinimumSize = new System.Drawing.Size(290, 447);
            this.uploaded_image.Name = "uploaded_image";
            this.uploaded_image.Size = new System.Drawing.Size(290, 447);
            this.uploaded_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uploaded_image.TabIndex = 1;
            this.uploaded_image.TabStop = false;
            // 
            // converted_text
            // 
            this.converted_text.Location = new System.Drawing.Point(458, 67);
            this.converted_text.Name = "converted_text";
            this.converted_text.Size = new System.Drawing.Size(309, 447);
            this.converted_text.TabIndex = 2;
            this.converted_text.Text = "";
            // 
            // read_button
            // 
            this.read_button.Location = new System.Drawing.Point(308, 129);
            this.read_button.Name = "read_button";
            this.read_button.Size = new System.Drawing.Size(144, 23);
            this.read_button.TabIndex = 3;
            this.read_button.Text = "Read text";
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // OCREngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 584);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.converted_text);
            this.Controls.Add(this.uploaded_image);
            this.Controls.Add(this.upload_button);
            this.Name = "OCREngineForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.uploaded_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button upload_button;
        private System.Windows.Forms.PictureBox uploaded_image;
        private System.Windows.Forms.RichTextBox converted_text;
        private System.Windows.Forms.Button read_button;
    }
}

