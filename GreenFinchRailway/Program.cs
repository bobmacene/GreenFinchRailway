using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GreenFinchRailway
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\bob\Documents\AlgorithmProblems\GreenFinchRailway\Nodes.txt";

            var routes = new Route().GetRoutes(File.ReadAllText(path));

            var trip = new Trip("AC", 4);

            var trips = trip.GetTrips(routes);
            var count = trip.CountTripsByNumberOfStops(trips);
        }      
           
    }
}
