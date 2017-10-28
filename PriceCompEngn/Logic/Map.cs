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
        private GMapControl _gmap;
        private GMapOverlay _markeroverlay = new GMapOverlay("markers");
   
        public Map(GMapControl gmap)
        {
            _gmap = gmap;
        }

        public GMapOverlay GetMarkerOverlay()
        {
            return _markeroverlay;
        }

        public GMapControl GetGMapControl()
        {
            return _gmap;
        }

    }
}
