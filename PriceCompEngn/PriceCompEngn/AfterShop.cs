using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCREngine;
using System.IO;
using Logic;
using DataBase;

namespace PriceCompEngn
{
    public partial class AfterShop : Form
    {
        public string ImagePath { get; set; }
        private string _resultTextString;
        List<ShopItem> items;

        public AfterShop()
        {
            InitializeComponent();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                btnAddImage.Enabled = false;
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(dialog.FileName);
                    if (fileInfo.Length > 4 * 1024 * 1024)
                    {
                        MessageBox.Show("File too large");
                        return;
                    }
                    ImagePath = dialog.FileName;
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnAddImage.Enabled = true;
                }
            }
            _resultTextString = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            TextManager tm = new TextManager();
            textBox1.Text = _resultTextString;
        }

        private void bntUpload_Click(object sender, EventArgs e)
        {
            TextManager tm = new TextManager();
            items = tm.GetListOfProducts(_resultTextString);
            DBController cntrl = new DBController();
            cntrl.PushToDatabase(items);
            MessageBox.Show("Kvito informacija sėkmingai patalpinta duomenų bazėje");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _previous = textBox1.Text;
            string _current = null;

            if (!String.Equals(_previous,_current))
            {
                _current = textBox1.Text;
                if (_current.Length==_previous.Length)
                {
                    _resultTextString = _current;
                    MessageBox.Show("Nuskaitytos prekės buvo sėkmingai redaguotos. Ačiū!");  
                }
                else
                {
                    MessageBox.Show("Ilgis įvesto teksto yra mažesnis už pradinį!");
                }
                }
            else
            {
                MessageBox.Show("Tekstas nebuvo pakeistas!");
            }
        }
    }
}
