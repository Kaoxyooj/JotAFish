using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JotAFish.Models
{
    public class Coord
    {
        public string lat;
        public string lng;
        public Coord(string lat, string lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
    }
}