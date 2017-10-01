﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                dialog.Filter = "jpeg files|*.jpg;*.JPG";
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
            if (string.IsNullOrEmpty(ImagePath))
                return;


            Converted_text.Text = "";
            GoogleAnnotate annotate = new GoogleAnnotate();
            annotate.GetText(ImagePath, "lt");
            if (string.IsNullOrEmpty(annotate.Error) == false)
                MessageBox.Show("Error" + annotate.Error);
            else
            {
                ResultTextString = annotate.TextResult;
                Converted_text.Text = annotate.TextResult;
            }
        }
    }
}