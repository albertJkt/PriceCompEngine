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
            var _perk = _perkamiausios.Keys.ToList();
            label1.Text = @"Top 5 Perkamiausios prekės:" +"\n" + 
                "1. " + _perk[0] + "\n"+
                "2. " + _perk[1] + "\n" +
                "3. " + _perk[2] + "\n" +
                "4. " + _perk[3] + "\n" +
                "5. " + _perk[4];

            var _pigiausios = top.GetCheapestShopItemsList(5);
            label3.Text = @"Top 5 Pigiausios prekės:" + "\n" +
                "1. " + _pigiausios[0].ItemName + "\n" +
                "2. " + _pigiausios[1].ItemName + "\n" +
                "3. " + _pigiausios[2].ItemName + "\n" +
                "4. " + _pigiausios[3].ItemName + "\n" +
                "5. " + _pigiausios[4].ItemName;

            var _perkamiausios7 = top.GetTopShopItemsList(5,7);
            var _perk7 = _perkamiausios.Keys.ToList();
            label2.Text = @"Top 5 Savaitės perkamiausios prekės:" + "\n" +
                "1. " + _perk7[0] + "\n" +
                "2. " + _perk7[1] + "\n" +
                "3. " + _perk7[2] + "\n" +
                "4. " + _perk7[3] + "\n" +
                "5. " + _perk7[4];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AroundMe around = new AroundMe();
            around.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string _text = textBox1.Text;
            ShopItem si;
            PriceComparator pc = new PriceComparator();
            shops = AddShops().ToArray();

            if (_text != null)
            {
                si = pc.GetCheapestItem(_text, shops);
                label5.Text = "Prekė: " + si.ItemName + " " + si.Type + " " + si.Price + " pigiausiai kainuoja: " + si.ShopName + " parduotuvėje";
                label5.Show();
            }
        }

        private void checkIki_CheckedChanged(object sender, EventArgs e)
        {

        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            string _text = textBox2.Text;
            List<ShopItem> si;
            PriceComparator pc = new PriceComparator();
            shops = AddShops().ToArray();

            if (_text != null)
            {
                si = pc.GetCheapestItemTypeList(_text, shops, 1);
                label7.Text = "Prekė: " + si[0].ItemName + " " + si[0].Type + " " + si[0].Price + " pigiausiai kainuoja: " + si[0].ShopName + " parduotuvėje";
                label7.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
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
            return shops;
        }
    }
}
