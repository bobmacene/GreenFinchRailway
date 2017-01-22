using NUnit.Framework;
using System.Collections.Generic;

namespace GreenFinchRailway.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private const string fakeDigraph = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
        private Distance fakeDistance;
        private Dictionary<string, int> fakeRoutesWithDistance;
        private string[] fakeRoutes;
        private Trip fakeTrip;

        [SetUp]
        public void SetUp()
        {
            var fakeRoute = new Route();
            var fakeIsDistanceRequired = true;
            
            fakeRoutesWithDistance = fakeRoute.GetRoutesWithDistance(fakeDigraph, fakeIsDistanceRequired);

            fakeRoutes = fakeRoute.GetRoutes(fakeDigraph);

            fakeDistance = new Distance();
     
        }


        [Test]
        public void Question1()
        {
            var fakeDistanceResult = fakeDistance.GetDistanceFormatOutput(
                1, fakeDistance.GetDistance, "A-B-C", fakeRoutesWithDistance);

            Assert.AreEqual(fakeDistanceResult, "Output #1: 9");
        }

        [Test]
        public void Question2()
        {
            var fakeDistanceResult = fakeDistance.GetDistanceFormatOutput(
                2, fakeDistance.GetDistance, "A-D", fakeRoutesWithDistance);

            Assert.AreEqual(fakeDistanceResult, "Output #2: 5");
        }

        [Test]
        public void Question3()
        {
            var fakeDistanceResult = fakeDistance.GetDistanceFormatOutput(
                3, fakeDistance.GetDistance, "A-D-C", fakeRoutesWithDistance);

            Assert.AreEqual(fakeDistanceResult, "Output #3: 13");
        }

        [Test]
        public void Question4()
        {
            var fakeDistanceResult = fakeDistance.GetDistanceFormatOutput(
                4, fakeDistance.GetDistance, "A-E-B-C-D", fakeRoutesWithDistance);

            Assert.AreEqual(fakeDistanceResult, "Output #4: 22");
        }

        [Test]
        public void Question5()
        {
            var fakeDistanceResult = fakeDistance.GetDistanceFormatOutput(
                5, fakeDistance.GetDistance, "A-E-D", fakeRoutesWithDistance);

            Assert.AreEqual(fakeDistanceResult, "Output #5: NO SUCH ROUTE");
        }

        [Test]
        public void Question6()
        {
            var fakeTrip = new Trip("CC", 3);
            var fakeNumberOfPossibleTrips = 
                fakeTrip.CountTrips(fakeTrip.GetTrips(fakeRoutes));

            Assert.AreEqual(fakeNumberOfPossibleTrips, 2);
        }

        [Test]
        public void Question7()
        {
            var fakeTrip = new Trip("AC", 4);
            var fakeNumberOfPossibleTrips = 
                fakeTrip.CountTripsByNumberOfStops(fakeTrip.GetTrips(fakeRoutes));

            Assert.AreEqual(fakeNumberOfPossibleTrips, 2);
        }

        [TearDown]
        public void TearDown()
        {
            fakeRoutesWithDistance = null;
            fakeTrip = null;
            fakeDistance = null;
        }

    }
}
