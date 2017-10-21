using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GMap.NET;
using Logic;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace PriceCompEngn
{
    public partial class MapsForm : Form
    {
     /*   public MapsForm()
        {


            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            UserLocation ul = UserLocation.Instance;

            ThreadStart threaddelegate = new ThreadStart(ul.FindUserLocation);
            Thread ulThread = new Thread(threaddelegate);

            ulThread.Start();
            ulThread.Join();
            MapController mc = new MapController(new Map(gmap));

            mc.DisplayMap();

        }

        private void OnClick(object sender, EventArgs e)
        {
            MapController mc = new MapController(new Map(gmap));
            mc.ShowShops(2000);
        }

        private void OnClick2(object sender, EventArgs e)
        {
            MapController mc = new MapController(new Map(gmap));
            mc.ShowShops(2000, "maxima");
        }*/
    }
}
