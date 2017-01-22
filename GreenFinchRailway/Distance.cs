using System;
using System.Collections.Generic;

namespace GreenFinchRailway
{
    public class Distance
    {
        public int GetDistance(string proposedRoute, Dictionary<string, int> routes)
        {
            var cities = proposedRoute.Split('-');

            var distance = 0;

            for (var v = 0; v < cities.Length - 1; v++)
            {
                var routeKey = cities[v] + cities[v + 1];

                if (routes.ContainsKey(routeKey))
                {
                    distance += routes[routeKey];
                }
                else
                {
                    return distance = -1;
                }
            }

            return distance;
        }

        public string GetDistanceFormatOutput(
           int outputNumber,
           Func<string, Dictionary<string, int>, int> getDistance,
           string proposedRoute,
           Dictionary<string, int> allRoutes
           )
        {
            var distance = getDistance(proposedRoute, allRoutes);

            return distance == -1
                ? $"Output #{outputNumber}: NO SUCH ROUTE"
                : $"Output #{outputNumber}: {distance}";
        }
    }
}
