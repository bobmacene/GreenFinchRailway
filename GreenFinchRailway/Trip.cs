using System.Collections.Generic;
using System.Linq;

namespace GreenFinchRailway
{
    public class Trip
    {
        private string _proposedTrip;
        private int _stopLimit;

        public Trip(string proposedTrip, int stopLimit)
        {
            _proposedTrip = proposedTrip;
            _stopLimit = stopLimit;
        }

        public IEnumerable<RouteInfo> GetTrips(string[] routes)
        {
            IEnumerable<string> startingRoutes = routes.Where(x => x[0] == _proposedTrip[0]);

            var addedRoutes = new List<RouteInfo>(0);

            foreach (var start in startingRoutes)
            {
                var routeInfos = GetRouteInfo(routes);

                var current = routeInfos.FirstOrDefault(x => x.Route == start);

                while (current != null)
                {
                    current = GetPossibleRoutes(addedRoutes, routeInfos, current);
                }

                routeInfos = GetRouteInfo(routes).OrderByDescending(x => x.Route);

                current = routeInfos.FirstOrDefault(x => x.Route == start);

                while (current != null)
                {
                    current = GetPossibleRoutes(addedRoutes, routeInfos, current);
                }
            }

            return addedRoutes.Distinct();
        }

        private static RouteInfo GetPossibleRoutes(
            ICollection<RouteInfo> addedRoutes, IEnumerable<RouteInfo> routeInfos, RouteInfo current)
        {
            {
                var isFinished = true;

                foreach (var info in routeInfos)
                {
                    if (info.isAvailable == false) continue;

                    if (current.Route == info.Route)
                    {
                        info.isAvailable = false;
                    }

                    if (current.Route[1] == info.Route[0])
                    {
                        info.isAvailable = false;
                        info.Depth = ++current.Depth;
                        current = info;

                        var newRoute = new RouteInfo(current.Route);
                        newRoute.Depth = current.Depth;
                        addedRoutes.Add(newRoute);

                        isFinished = false;
                        break;
                    }
                }

                current = isFinished == false ? current : null;
            }

            return current;
        }

        public int CountTripsByNumberOfStops(IEnumerable<RouteInfo> routeInfo)
        {
            return routeInfo
                .Where(x => x.Route[1] == _proposedTrip[1] && x.Depth == _stopLimit)
                .Count();
        }

        public int CountTrips(IEnumerable<RouteInfo> routeInfo)
        {
            return routeInfo
                .Where(x => x.Route[1] == _proposedTrip[1] && x.Depth <= _stopLimit)
                .Count();
        }

        private static IEnumerable<RouteInfo> GetRouteInfo(string[] basicRoutes)
        {
            var routeInfos = new List<RouteInfo>();

            foreach (var route in basicRoutes)
            {
                routeInfos.Add(new RouteInfo(route));
            }

            return routeInfos;
        }

    }
}


/*
 *   public IEnumerable<RouteInfo> GetTrips(string[] routes)
        {
            IEnumerable<string> startingRoutes = routes.Where(x => x[0] == _proposedTrip[0]);

            var addedRoutes = new List<RouteInfo>(0);

            foreach (var start in startingRoutes)
            {
                var routeInfos = GetRouteInfo(routes);

                var current = routeInfos.FirstOrDefault(x => x.Route == start);

                while (current != null)
                {
                    current = GetPossibleRoutes(addedRoutes, routeInfos, current);
                }
            }

            return addedRoutes;
        }
 * 
 * 
 * 
 * 
 * 
 *         public IEnumerable<RouteInfo> GetAllPossibleRoutes(string[] routes)
        {
            IEnumerable<string> startingRoutes = routes.Where(x => x[0] == _proposedTrip[0]);

            var allRoutes = new List<RouteInfo>();

            foreach (var start in startingRoutes)
            {
                var routeInfos = GetRouteInfo(routes);

                var current = routeInfos.FirstOrDefault(x => x.Route == start);
                current.isAvailable = false;

                var added = new List<RouteInfo>();
                added.Add(current);

                var isFinished = false;

                while (!isFinished)
                {
                    isFinished = true;

                    List<RouteInfo> newAdded = null;

                    foreach (var routeinfo in added)
                    {
                        newAdded = new List<RouteInfo>();

                        foreach (var info in routeInfos)
                        {
                            if (info.isAvailable && info.Route[0] == current.Route[1])
                            {
                                info.isAvailable = false;
                                current.Routes.Add(info);
                                newAdded.Add(info);
                                isFinished = false;
                            }
                        }
                    }
                    added = newAdded;
                }
                allRoutes.Add(current);
            }

            return allRoutes;
        }
*/
