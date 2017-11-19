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
using ServiceClient;
using Newtonsoft.Json;

namespace PriceCompEngn
{
    public partial class AfterShop : Form
    {
        public string ImagePath { get; set; }
        private string _resultTextString;
        List<ShopItem> items;
        string response;
        RestRequestExecutor executor = new RestRequestExecutor();
        byte[] image;


        public AfterShop()
        {
            InitializeComponent();
        }

        private async void btnAddImage_Click(object sender, EventArgs e)
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

                    image = File.ReadAllBytes(ImagePath);

                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnAddImage.Enabled = true;
                }
            }
            PCEUriBuilder builder = new PCEUriBuilder(Resources.TextManager);
            

            response = await executor.ExecuteRestPostRequest(builder, image);

            var typeList = new[]
            {
                new
                {
                    ItemName = "",
                    ShopName = "",
                    Type = "",
                    Price = (float)0.00,
                    PurchaseTime = new DateTime(),
                    Id = 1
                }
            }.ToList();

            var result = JsonConvert.DeserializeAnonymousType(response, typeList);
            var result2 = JsonConvert.SerializeObject(result);

            StringBuilder sb = new StringBuilder("");
            sb.Append(result.First().ShopName+""+Environment.NewLine);

            foreach (var x in result)
            {
                sb.Append(x.Type+" "+x.ItemName+"   "+x.Price+" Eur"+Environment.NewLine);
            }

            sb.Append(result.First().PurchaseTime.Year+"-"+result.First().PurchaseTime.Month+"-"+result.First().PurchaseTime.Day);

            _resultTextString = sb.ToString();          
            textBox1.Text = _resultTextString;
        }

        private void bntUpload_Click(object sender, EventArgs e)
        {
            PCEUriBuilder builder = new PCEUriBuilder(Resources.ShopItems);

            Dictionary<string, string> arguments = new Dictionary<string, string>()
            {
                {"itemListJson", response }
            };
            builder.AppendStringArgs(arguments);
            executor.ExecuteRestPostRequest(builder);

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
                var typeList = new[]
                {
                    new
                     {
                         ItemName = "",
                         ShopName = "",
                         Type = "",
                         Price = (float)0.00,
                         PurchaseTime = new DateTime(),
                         Id = 1
                    }
                }.ToList();


                MessageBox.Show("Tekstas nebuvo pakeistas!");
            }
        }
    }
}
