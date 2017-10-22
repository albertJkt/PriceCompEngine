using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using Logic;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.Threading;

namespace PriceCompEngn
{
    public partial class AroundMe : Form
    {
        public AroundMe()
        {
            InitializeComponent();
        }

        private void AroundMe_Load(object sender, EventArgs e)
        {
            UserLocation ul = UserLocation.Instance;

            ThreadStart threaddelegate = new ThreadStart(ul.FindUserLocation);
            Thread ulThread = new Thread(threaddelegate);

            ulThread.Start();
            ulThread.Join();
            MapController mc = new MapController(new Map(gmap));

            mc.DisplayMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int radius = Convert.ToInt32(txtRadius.Text);
            string name = txtName.Text;
            MapController mc = new MapController(new Map(gmap));

            if (name != null)
            {
                mc.ShowShops(radius, name);
            }
            else
                mc.ShowShops(radius);
        }
    }
}
