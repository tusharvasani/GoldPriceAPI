using NUnit.Framework;
using GoldPriceAPI.Controllers;
namespace GoldPriceAPI.Test
{
    public class WeatherForcastTest
    {
        WeatherForecastController myCtl = new WeatherForecastController();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIDReturnsHongKong()
        {
            Assert.AreEqual(myCtl.Get(1), "Hong Kong");
        }
    }
}