using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinchRailway
{
    public class RouteInfo
    {
        public int Depth { get; set; }
        public string Route { get; set; }
        public bool isAvailable { get; set; } = true;
        public int Distance { get; set; }
        public RouteInfo(string route)
        {
            Depth = 1;
            Route = route;
            Distance = Convert.ToInt32(route[2]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RouteInfo)) return false;
            RouteInfo info = (RouteInfo)obj;
            return (info.Route == Route && info.Depth == Depth && info.isAvailable == isAvailable && info.Distance == Distance);
        }
  
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Depth.GetHashCode();
                hash = hash * 23 + Distance.GetHashCode();
                hash = hash * 23 + Route.GetHashCode();
                hash = hash * 23 + isAvailable.GetHashCode();
                return hash;
            }
        }
    }
}
