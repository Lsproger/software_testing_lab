using OpenQA.Selenium;

namespace Framework.Steps
{
    public class Steps
    {
        IWebDriver driver;
        Pages.MainPage mainPage;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void FindRoute(string from, string to)
        {          
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillAirports(from, to);
            mainPage.SelectDateTomorrow(2);
            mainPage.SearchClick();
        }

        public void FindRouteWithoutDate(string from, string to)
        {            
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillAirports(from, to);          
            mainPage.SearchClick();
        }

        public void FindRouteWithoutReturnDate(string from, string to)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillAirports(from, to);
            mainPage.SelectDateTomorrow(1);
            mainPage.SearchClick();
        }

        public void CheckFromFieldAutoComplete(string from, string to)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillAirports(from, to);
        }

        public void ChangeLocaleToRussian()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.SetRussian();
        }

        public void SwitchToSecondAd()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoToSecondAd();
        }

        public void SwitchToThirdAd()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoToThirdAd();
        }

        public string GetBadDestinationError()
        {            
            return mainPage.GetBadDestinationError();
        }

        public string GetOriginationFieldValue()
        {
            return mainPage.GetOriginationFieldValue();
        }

        public string GetDestinationFieldValue()
        {
            return mainPage.GetDestinationFieldValue();
        }

        public string GetBadOriginationError()
        {
            return mainPage.GetBadOriginationError();
        }

        public string GetSearchButtonText()
        {
            return mainPage.GetSearchButtonText();
        }

        public string GetDateError()
        {
            return mainPage.GetDateError();
        }

        public string GetSecondPromoText()
        {
            return mainPage.GetSecondPromoText();
        }

        public string GetThirdPromoText()
        {
            return mainPage.GetThirdPromoText();
        }
    }
}
