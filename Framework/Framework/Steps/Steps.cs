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


        public string GetDateError()
        {
            return mainPage.GetDateError();
        }







        public void LoginGithub(string username, string password)
        {
            //Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            //loginPage.OpenPage();
            //loginPage.Login(username, password);
        }

        //public string GetLoggedInUserName()
        //{
        //    //Pages.LoginPage loginPage = new Pages.LoginPage(driver);
        //    //return loginPage.GetLoggedInUserName();
        //}

        //public void CreateNewRepository(string repositoryName, string repositoryDescription)
        //{
        //    //Pages.MainPage mainPage = new Pages.MainPage(driver);
        //    //mainPage.ClickOnCreateNewRepositoryButton();
        //    //Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    //createNewRepositoryPage.CreateNewRepository(repositoryName, repositoryDescription);
        //}

        //public string GenerateRandomRepositoryNameWithCharLength(int howManyChars)
        //{
        //    //string repositoryNamePrefix = "testRepo_";
        //    //return string.Concat(repositoryNamePrefix, Utils.RandomGenerator.GetRandomString(howManyChars));
        //}

        //public bool CurrentRepositoryIsEmpty()
        //{
        //    //Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    //return createNewRepositoryPage.IsCurrentRepositoryEmpty();
        //}

        //public string GetCurrentRepositoryName()
        //{
        //    //Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    //return createNewRepositoryPage.GetCurrentRepositoryName();
        //}
    }
}
