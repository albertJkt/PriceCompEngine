using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Map
    {
        GMapControl Gmap;
        GMapOverlay Markeroverlay = new GMapOverlay("markers");
   
        public Map(GMapControl gmap)
        {
            Gmap = gmap;
        }

        public GMapOverlay GetMarkerOverlay()
        {
            return Markeroverlay;
        }

        public GMapControl GetGMapControl()
        {
            return Gmap;
        }

    }
}
