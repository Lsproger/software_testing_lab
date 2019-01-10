using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Framework.Pages
{
    public class MainPage
    {
        
        private readonly WebDriverWait wait;
        private const string BASE_URL = "https://www.s7.ru/";

        [FindsBy(How = How.Id, Using = "flights_origin2")]
        private IWebElement cityFrom;
        

        [FindsBy(How = How.Id, Using = "flights_origin2-error")]
        private IWebElement cityFromError;

        [FindsBy(How = How.Id, Using = "flights_destination2")]
        private IWebElement cityTo;
        

        [FindsBy(How = How.Id, Using = "flights_destination2-error")]
        private IWebElement cityToError;

        [FindsBy(How = How.Id, Using = "date-opener2")]
        private IWebElement datePicker;

        [FindsBy(How = How.Id, Using = "flights_return_way_bot2")]
        private IWebElement bidirectionalTrip;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"flights_one_way_bot2\"]")]
        private IWebElement oneWayTrip;

        [FindsBy(How = How.XPath, Using = @"//*[@id='flights - dates -return-prepop - whitelabel_ru']")]
        private IWebElement returnsDate;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[1]/div[1]/label/div[2]")]
        private IWebElement loginError;


        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div")]
        private IWebElement accountButton;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[1]/div[1]/label/input")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[2]/button[1]")]
        private IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"header - nav\"]/ul/li[6]/a")]
        private IWebElement languageList;

        [FindsBy(How = How.Id, Using = "search-btn-expand-bot")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.XPath, Using = @"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[4]/div/label/div[1]")]
        private IWebElement agreeCheckBox;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div/div[3]/div[1]/div[1]/div[2]/div/div[10]/div[2]/div[5]/div[2]/div[5]/div/div[1]")]
        private IWebElement badSearchParams;


        [FindsBy(How = How.XPath, Using = "//summary[@aria-label='Create new…']")]
        private IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'New repository')]")]
        private IWebElement linkNewRepository;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnCreateNewRepositoryButton()
        {
            buttonCreateNew.Click();
            linkNewRepository.Click();
        }

        public void FillAirports(string from, string to)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(from);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.ArrowDown);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.Enter);

            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.SendKeys(to);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.ArrowDown);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(Keys.ArrowDown);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityTo));
            cityTo.SendKeys(Keys.Enter);
        }

        public void SetOneWayRoute()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(datePicker));
            datePicker.Click();
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].checked = true;", oneWayTrip);
        }

        public void SelectDateToday()
        {
            for (int i = 0; i < 2; i++)
            {
                IWebElement today = driver.FindElement(By.CssSelector("#datepicker2 > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(2) > td:nth-child(5) > a:nth-child(1)"));
                wait.Until(ExpectedConditions.ElementToBeClickable(today));
                today.Click();
            }
        }

        public void SelectDatePast()
        {
            for (int i = 0; i < 2; i++)
            {
                IWebElement today = driver.FindElement(By.CssSelector("#datepicker2 > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(2) > span:nth-child(1)"));
                wait.Until(ExpectedConditions.ElementToBeClickable(today));
                today.Click();
            }
        }

        public void SearchClick()
        {
            buttonSearch.Click();
        }

        public string GetBadDestinationError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("flights_destination2-error")));
            return cityToError.Text;
        }

        public string GetBadOriginationError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("flights_origin2-error")));
            return cityFromError.Text;
        }

        public string GetDateError()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[4]/div[1]")));
            IWebElement dateError = driver.FindElement(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[4]/div[1]"));

            return dateError.Text;
        }

    }
}