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
            Assert.AreEqual(myCtl.Get(10), "Hong Kong");
        }
        [Test]
        public void SumOf10and20Returns30()
        {
            Assert.AreEqual(myCtl.Sum(10,20), 30);
        }
    }
}