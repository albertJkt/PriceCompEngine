using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;


namespace PriceCompEngn
{
    public partial class OCREngine : Form
    {
        public OCREngine()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btOCR_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                var ocr = new TesseractEngine("./tessdata", "lit", EngineMode.Default);
                var page = ocr.Process(image);
                txtBox.Text = page.GetText();
            }
        }
    }
}
