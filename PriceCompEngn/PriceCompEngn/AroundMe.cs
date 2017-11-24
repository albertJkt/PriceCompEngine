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
using System.Text.RegularExpressions;



namespace PriceCompEngn
{
    public partial class AroundMe : Form
    {
        string regex1 = @"^(([1-4][0-9]{0,4})|([1-9][0-9]{0,3})|(5000))$";
        string regex2 = @"|[rimi]|[norfa]|[iki]|[maxima]|[lidl]";

        public AroundMe()
        {
            InitializeComponent();
        }

        private void AroundMe_Load(object sender, EventArgs e)
        {

            MapController mc = new MapController(new Map(gmap));

            mc.DisplayMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var radius = txtRadius.Text;

            var name = txtName.Text;
            MapController mc = new MapController(new Map(gmap));

            if (!string.IsNullOrEmpty(name) && Regex.Match(name, regex2, RegexOptions.IgnoreCase).Success && Regex.Match(radius.ToString(), regex1).Success)
            {
                mc.ShowShops(Convert.ToInt32(radius), name);
            }
            else if ((Regex.Match(radius.ToString(), regex1)).Success) mc.ShowShops(Convert.ToInt32(radius));
        }
    }
}
