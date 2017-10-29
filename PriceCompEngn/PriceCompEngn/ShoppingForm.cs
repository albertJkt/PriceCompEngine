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

namespace PriceCompEngn
{
    public partial class ShoppingForm : Form
    {
        string[] shops;
        List<ShopItem> shopItems = new DBController().GetShopItemsList();
        int index = 1;
        public List<string> Bucket;
        public ShoppingForm()
        {
            InitializeComponent();

            shops = AddShops().ToArray();

            var temp = (from x in shopItems
                    where shops.Contains(x.ShopName.ToLower())
                    select x).ToList();

            foreach (var x in temp)
            {
                string[] row = { index.ToString(), x.ItemName, x.Type, x.ShopName, x.Price.ToString() };
                var i = new ListViewItem(row);
                listView1.Items.Add(i);
                index++;
            }
            index = 1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string _text = textBox1.Text;
            string _type = textBox2.Text;
            PriceComparator pc = new PriceComparator();
            shops = AddShops().ToArray();
            var temp = new List<ShopItem>();
            
            if (!String.IsNullOrEmpty(_text) && !String.IsNullOrEmpty(_type))
            {
                 temp = (from x in shopItems
                           where shops.Contains(x.ShopName.ToLower()) && x.ItemName.Contains(_text) && x.Type.Contains(_type)
                           select x).ToList();
            }
            if (String.IsNullOrEmpty(_text) && !String.IsNullOrEmpty(_type))
            {
                temp = (from x in shopItems
                        where shops.Contains(x.ShopName.ToLower()) && x.Type.Contains(_type)
                        select x).ToList();
            }
            if (!String.IsNullOrEmpty(_text) && String.IsNullOrEmpty(_type))
            {
                temp = (from x in shopItems
                        where shops.Contains(x.ShopName.ToLower()) && x.ItemName.Contains(_text)
                        select x).ToList();
            }

            if(String.IsNullOrEmpty(_text) && String.IsNullOrEmpty(_type))
            {
                 temp = (from x in shopItems
                           where shops.Contains(x.ShopName.ToLower())
                           select x).ToList();
            }

            listView1.Items.Clear();

            foreach (var x in temp)
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

            // cia reikes bucket'a paduot i Rycio konstruktoriu ir po to istrint komentara
            // nes destytojas nemegsta lietuvisku komentaru xD
        }
    }
}
