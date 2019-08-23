using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuestlogixDemo.Data;

namespace GuestlogixTests
{
    [TestClass]
    public class ShortestPathTests
    {
        [TestMethod]
        public void GetShortestPath_YYZtoJFK_Found()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("YYZ", "JFK", true);
            Assert.AreEqual(result, "YYZ -> JFK");
        }

        [TestMethod]
        public void GetShortestPath_YYZtoYVR_Found()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("YYZ", "YVR", true);
            Assert.AreEqual(result, "YYZ -> JFK -> LAX -> YVR");
        }

        [TestMethod]
        public void GetShortestPath_YYZtoORD_NoRoute()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("YYZ", "ORD", true);
            Assert.AreEqual(result, "No Route Found. Please change the airports and try again.");
        }

        [TestMethod]
        public void GetShortestPath_XXXtoORD_InvalidOrigin()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("XXX", "ORD", true);
            Assert.AreEqual(result, "Invalid Origin. Please make sure the inputs are valid.");
        }

        [TestMethod]
        public void GetShortestPath_ORDtoXXX_InvalidDestination()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("ORD", "XXX", true);
            Assert.AreEqual(result, "Invalid Destination. Please make sure the inputs are valid.");
        }

        [TestMethod]
        public void GetShortestPath_XXXtoYYY_InvalidDestination()
        {
            DataAccess dataAccess = new DataAccess();
            string result = dataAccess.GetShortestPath("XXX", "YYY", true);
            Assert.AreEqual(result, "Invalid Origin and Destination. Please make sure the inputs are valid.");
        }
    }
}
