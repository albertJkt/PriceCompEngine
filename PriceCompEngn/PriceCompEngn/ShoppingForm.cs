using DataBase;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceClient;
using Newtonsoft.Json;

namespace PriceCompEngn
{
    public partial class ShoppingForm : Form
    {
        

        RestRequestExecutor executor = new RestRequestExecutor();

        

        string[] shops;
        List<ShopItem> shopItems = new DBController().GetShopItemsList();
        int index = 1;
        public List<string> Bucket;
        public ShoppingForm()
        {
            
            InitializeComponent();
        }

        List<string> AddShops()
        {
            List<string> shops = new List<string>();
            if (checkIki.Checked)
            {
                shops.Add("iki");
            }
            if (checkMaxima.Checked)
            {
                shops.Add("maxima");
            }
            if (checkNorfa.Checked)
            {
                shops.Add("norfa");
            }
            if (checkRimi.Checked)
            {
                shops.Add("rimi");
            }
            if (checkLidl.Checked)
            {
                shops.Add("lidl");
            }
            if (!checkIki.Checked && !checkMaxima.Checked && !checkNorfa.Checked && !checkRimi.Checked && !checkLidl.Checked)
            {
                shops.Add("iki");
                shops.Add("maxima");
                shops.Add("norfa");
                shops.Add("rimi");
                shops.Add("lidl");
            }

            return shops;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            string _text = textBox1.Text;
            string _type = textBox2.Text;

            /**/

            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.ShopItems);
            shops = AddShops().ToArray();
            var response = await executor.ExecuteRestGetRequest(builder);

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
            /**/

            shops = AddShops().ToArray();
           
            
            if (!String.IsNullOrEmpty(_text) && !String.IsNullOrEmpty(_type))
            {
                 result = (from x in result
                           where shops.Contains(x.ShopName.ToLower()) && x.ItemName.Contains(_text) && x.Type.Contains(_type)
                           select x).ToList();
            }
            if (String.IsNullOrEmpty(_text) && !String.IsNullOrEmpty(_type))
            {
                result = (from x in result
                          where shops.Contains(x.ShopName.ToLower()) && x.Type.Contains(_type)
                        select x).ToList();
            }
            if (!String.IsNullOrEmpty(_text) && String.IsNullOrEmpty(_type))
            {
                result = (from x in result
                          where shops.Contains(x.ShopName.ToLower()) && x.ItemName.Contains(_text)
                        select x).ToList();
            }

            if(String.IsNullOrEmpty(_text) && String.IsNullOrEmpty(_type))
            {
                result = (from x in result
                          where shops.Contains(x.ShopName.ToLower())
                           select x).ToList();
            }

            listView1.Items.Clear();

            foreach (var x in result)
            {
                string[] row = { index.ToString(), x.ItemName, x.Type, x.ShopName, x.Price.ToString() };
                var i = new ListViewItem(row);
                listView1.Items.Add(i);
                index++;
            }
            index = 1;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = (ListViewItem)listView1.SelectedItems[0].Clone();

                item.SubItems.RemoveAt(0);
                item.SubItems.RemoveAt(1);
                item.SubItems.RemoveAt(1);

                listView2.Items.Add(item);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                listView2.SelectedItems[0].Remove();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bucket = listView2.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();

            ShoppingCart shoppingCart = new ShoppingCart(Bucket, shops);
            label3.Text = "Pigiausia apsipirkti " + shoppingCart.BestShop + " parduotuvėje";
            label4.Text = "Apsipirkimas parduotuvėje " + shoppingCart.BestShop + " kainuotų " + shoppingCart.LowestPrice.ToString("n2") + " €";
            label5.Text = "Vidutinė apsipirkimo kaina kitose parduotuvėse: " + shoppingCart.AveragePrice + " €";

            label3.Show();
            label4.Show();
            label5.Show();
        }

        private async void On_Load(object sender, EventArgs e)
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.ShopItems);
            shops = AddShops().ToArray();
            var response = await executor.ExecuteRestGetRequest(builder);

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

            foreach (var x in result)
            {
                string[] row = { index.ToString(), x.ItemName, x.Type, x.ShopName.ToLower(), x.Price.ToString() };
                var i = new ListViewItem(row);
                listView1.Items.Add(i);
                index++;
            }
            index = 1;
        }
    }
}
