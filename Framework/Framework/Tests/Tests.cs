using NUnit.Framework;
using System.Threading;

namespace Framework
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void FindEmptyDestinationRoute()
        {
            steps.FindRoute("LED", "");
            Assert.AreEqual("Empty field", steps.GetBadDestinationError());
        }

        [Test]
        public void FindOriginationEqualsDestinationRoute()
        {
            steps.FindRoute("LED", "LED");
            Assert.AreEqual("Empty field", steps.GetBadOriginationError());
        }

        [Test]
        public void FindRouteWithoutDate()
        {
            steps.FindRouteWithoutDate("LED", "MSQ");
            Assert.AreEqual("Select departure and return dates", steps.GetDateError());
        }

        [Test]
        public void FindRouteWithoutReturnDate()
        {
            steps.FindRouteWithoutReturnDate("LED", "MSQ");
            Assert.AreEqual("Select flight date", steps.GetDateError());
        }

        [Test]
        public void CheckOriginationFieldAutoComplete()
        {
            steps.FillAirports("LED", "");
            Assert.AreEqual("LED", steps.GetOriginationFieldValue());
        }

        [Test]
        public void CheckDestinationFieldAutoComplete()
        {
            steps.FillAirports("", "LED");
            Assert.AreEqual("LED", steps.GetDestinationFieldValue());
        }

        [Test]
        public void CheckRussianLocale()
        {
            steps.ChangeLocaleToRussian();
            Assert.AreEqual("Найти", steps.GetSearchButtonText());
        }

        [Test]
        public void SwitchToSecondAd()
        {
            steps.SwitchToSecondAd();
            Assert.AreEqual("Collect\r\nimpressions", steps.GetSecondPromoText());
        }

        [Test]
        public void SwitchToThirdAd()
        {
            steps.SwitchToThirdAd();
            Assert.AreEqual("Fly easily", steps.GetThirdPromoText());
        }
    }
}
