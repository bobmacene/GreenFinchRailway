using System;
using System.Collections.Generic;

namespace GreenFinchRailway
{
    public class Route
    {
        public Dictionary<string, int> GetRoutesWithDistance(string input, bool isDistanceRequired)
        {
            var nodes = GetRoutes(input);

            var routes = new Dictionary<string, int>(nodes.Length);

            foreach (var node in nodes)
            {
                routes.Add(node[0].ToString() + node[1], Convert.ToInt32(node[2].ToString()));
            }

            return routes;
        }

        public string[] GetRoutes(string input)
        {
            return input.Replace(" ", string.Empty).Split(',');
        }

    }
}

/*
 *  public Dictionary<string, RouteData> GetRouteData(string[] graphs)
        {
            var routeDict = new Dictionary<string, RouteData>();

            foreach(var graph in graphs)
            {
                var route = graph[0].ToString() + graph[1];
                routeDict.Add(route, new RouteData(route));
            }

            return routeDict;
        }

        
        public Tuple<IEnumerable<RouteData>,Dictionary<string, RouteData>> UpdateStartingRoutes(
            Dictionary<string, RouteData> routeDatas, string proposedRoute)
        {
            var startingRoutes = new List<RouteData>();

            foreach(var data in routeDatas)
            {
                if(data.Value.StartCity == proposedRoute[0])
                {
                    data.Value.isAvailble = false;
                    startingRoutes.Add(data.Value);
                }
            }

            return new Tuple<IEnumerable<RouteData>, Dictionary<string, RouteData>>(
                startingRoutes, routeDatas);
        }

    */