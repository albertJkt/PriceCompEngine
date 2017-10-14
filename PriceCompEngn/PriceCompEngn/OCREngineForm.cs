using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCREngine;
using Logic;

namespace PriceCompEngn
{
    public partial class OCREngineForm : Form
    {
        public string ImagePath { get; set; }
        public OCREngineForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Upload_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                Read_button.Enabled = false;
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(dialog.FileName);
                    if (fileInfo.Length > 4 * 1024 * 1024)
                    {
                        MessageBox.Show("File too large");
                        return;
                    }
                    Uploaded_image.Image = Image.FromFile(dialog.FileName);
                    ImagePath = dialog.FileName;
                    Read_button.Enabled = true;
                }
            }
        }


        private string ResultTextString = "";
        private void Read_button_Click(object sender, EventArgs e)
        {
            ResultTextString = Converted_text.Text = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
        }
    }
}
