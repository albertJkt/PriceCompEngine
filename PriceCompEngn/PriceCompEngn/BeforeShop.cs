using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using DataBase;
using System.Threading;

namespace PriceCompEngn
{
    public partial class BeforeShop : Form
    {
        string[] shops;
        public BeforeShop()
        {           
            InitializeComponent();
        }

        private void BeforeShop_Load(object sender, EventArgs e)
        {
            TopItems top = new TopItems();
            var _perkamiausios = top.GetTopShopItemsList(5);
            label1.Text = @"Top 5 Perkamiausios prekės:";

            int index = 1;

            foreach (KeyValuePair<string, int> x in _perkamiausios)
            {
                string[] row = { index.ToString(), x.Key, x.Value.ToString() };
                var i = new ListViewItem(row);
                listView1.Items.Add(i);
                index++;
            }

            index = 1;

            var _pigiausios = top.GetCheapestShopItemsList(5);
            label3.Text = @"Top 5 Pigiausios prekės:";

            foreach (var x in _pigiausios)
            {
                string[] row = { index.ToString(), x.ItemName, x.Price.ToString() };
                var i = new ListViewItem(row);
                listView2.Items.Add(i);
                index++;
            }

            index = 1;

            var _perkamiausios7 = top.GetTopShopItemsList(5,7);
            var _perk7 = _perkamiausios.Keys.ToList();
            label2.Text = @"Top 5 Savaitės perkamiausios prekės:";

            foreach (KeyValuePair<string, int> x in _perkamiausios7)
            {
                string[] row = { index.ToString(), x.Key, x.Value.ToString() };
                var i = new ListViewItem(row);
                listView3.Items.Add(i);
                index++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AroundMe around = new AroundMe();
            around.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShoppingForm shop = new ShoppingForm();
            shop.Show();
        }
    }
}
