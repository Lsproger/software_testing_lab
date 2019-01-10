using System;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Selenium_WebDriver
{
    public class UnitTest1
    {
        static IWebDriver chrome = new ChromeDriver(System.AppDomain.CurrentDomain.BaseDirectory + "..\\");

        Actions builder = new Actions(chrome);
        

        [Fact]
        public void TestMethod1()
        {

            chrome.Navigate().GoToUrl("https://www.s7.ru/");

            chrome.FindElement(By.XPath("//*[@id=\"flights_destination2\"]")).SendKeys("Mosco");
            Thread.Sleep(1000);
            builder.SendKeys(Keys.Enter);
            //chrome.FindElement(By.XPath("//*[@id=\"flights_destination2\"]")).Click();
            //chrome.FindElement(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[3]/div/div[2]/div[2]/div[1]/div[1]/div/div[1]/ul/li[1]")).Click();

            chrome.FindElement(By.XPath("//*[@id=\"flights_origin2\"]")).SendKeys("Krasnod");
            Thread.Sleep(1000);
            builder.SendKeys(Keys.Enter);
            //chrome.FindElement(By.XPath("//*[@id=\"flights_origin2\"]")).Click();
            //chrome.FindElement(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[1]/div/div[3]/div[2]/div[1]/div[1]/div/div/ul/li[1]")).Click();

            chrome.FindElement(By.XPath("//*[@id=\"date - opener2\"]")).Click();
            chrome.FindElement(By.XPath("//*[@id=\"aviaBot\"]/div[2]/div[4]/div[2]/div[1]/div/div[2]/div/label")).Click();
            chrome.FindElement(By.XPath("//*[@id=\"datepicker2\"]/div/table/tbody/tr[5]/td[7]/a")).Click();
            chrome.FindElement(By.XPath("//*[@id=\"search - btn - expand - bot\"]")).Click();


            bool actual = false;
            Thread.Sleep(500);
            try
            {
                // WebDriverWait _wait = new WebDriverWait(chrome, new TimeSpan(0, 0, 20));
                //_wait.Timeout = 500;
                chrome.FindElement(By.XPath("//*[@id=\"selectExactDateSearchFlights\"]/div/div[3]/div[1]/div"));
                //    chrome.FindElement(By.ClassName("ticket-scroll-container"));
                // _wait.Until(d => d.FindElement(By.ClassName("ticket-scroll-container")));
            }
            catch (Exception)
            {
                actual = true;
            }

            Assert.True(actual);

        }
        [Fact]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}