using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.WebRequestMethods;
using System.IO;

namespace Light_bulb_Testing
{
    public class LightTest
    {
        static IWebDriver driver;

        GeneralMethods generalMethods;
        MainPage mainPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://qacamp.online/?page_id=2";
            
            generalMethods = new GeneralMethods(driver);
            mainPage = new MainPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var name =
                    $"{TestContext.CurrentContext.Test.MethodName}" +
                    $" Error at " +
                    $"{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}";

                GeneralMethods.TakeScreenShot(driver, name);

                System.IO.File.WriteAllText(
                    $"Screenshots\\{name}.txt",
                    TestContext.CurrentContext.Result.Message);
            }
            driver.Quit();
        }
        //1.Test Case: Initial light status
        [Test]
        public void InitialLightStatus()
        {
            mainPage.CheckLightBulbIsOff();
        }

        //2.Test Case: Turn on the light
        [Test]
        public void TurnOnTheLight()
        {
            mainPage.CheckLightBulbIsOff();
            mainPage.ClickTurnOn();
            mainPage.CheckLightBulbIsOn();
        }

        //3.Test Case: Turn off the light
        [Test]
        public void TurnOffTheLight()
        {
            mainPage.CheckLightBulbIsOff();
            mainPage.ClickTurnOn();
            mainPage.ClickTurnOff();
            mainPage.CheckLightBulbIsOff();
        }

        //4.Test Case: The status of the light remains unchanged
        [Test]
        public void LightStatusRemains()
        {
            mainPage.CheckLightBulbIsOff();
            mainPage.ClickTurnOn();
            mainPage.NavigateToDifferentPage();
            mainPage.CheckLightBulbIsOn();
        }

        //5.Test Case: Multiple clicks
        [Test]
        public void MultipleClicks()
        {
            mainPage.CheckLightBulbIsOff();
            mainPage.ClickThreeTimesOnAndOff();
            mainPage.CheckLightBulbIsOff();
        }
    }
}
