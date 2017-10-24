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
            items = tm.GetListOfProducts(_resultTextString);

            foreach(ShopItem item in items)
            {
                textBox1.AppendText(item.Type + " " + item.ItemName + " " + item.Price + "\n");
            }
        }

        private void bntUpload_Click(object sender, EventArgs e)
        {
            DBController cntrl = new DBController();
            cntrl.PushToDatabase(items);
            label2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
