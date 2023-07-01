using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Light_bulb_Testing
{
    internal class MainPage
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        string lightBulbOffXpath = "//img[@src='https://www.w3schools.com/js/pic_bulboff.gif']";
        string lightBulbOnXpath = "//img[@src='https://www.w3schools.com/js/pic_bulbon.gif']";
        string turnLightOnXpath = "//button[contains(text(),'Turn on the light')]";
        string turnLightOffXpath = "//button[contains(text(),'Turn off the light')]";

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void CheckLightBulbIsOff()
        {
            generalMethods.CheckElement(lightBulbOffXpath);
        }

        public void CheckLightBulbIsOn()
        {
            generalMethods.CheckElement(lightBulbOnXpath);
        }
        public void ClickTurnOn()
        {
            generalMethods.ClickButton(turnLightOnXpath);
        }

        public void ClickTurnOff()
        {
            generalMethods.ClickButton(turnLightOffXpath);
        }
        public void ClickThreeTimesOnAndOff()
        {
            generalMethods.ClickButtonTripleTime(turnLightOnXpath);
            generalMethods.ClickButtonTripleTime(turnLightOffXpath);
        }
        public void NavigateToDifferentPage()
        {
            driver.Navigate().GoToUrl("https://www.google.lt/");
            driver.Navigate().GoToUrl("http://qacamp.online/?page_id=2");
        }

    }
}
