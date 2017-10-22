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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            pb1.ImageLocation = "https://insoftd.com/wp-content/uploads/2014/01/online-taxi-booking-system.jpg";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void btnAfterShop_Click(object sender, EventArgs e)
        {
            AfterShop ocr = new AfterShop();
            ocr.Show();
        }

        private void btnBeforeShop_Click(object sender, EventArgs e)
        {
            BeforeShop shop = new BeforeShop();
            shop.Show();
        }
    }
}
