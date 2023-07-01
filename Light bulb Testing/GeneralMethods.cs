using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light_bulb_Testing
{
    public class GeneralMethods
    {
        IWebDriver driver;

        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
        }
       
        public void CheckElement(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException($"Element whoose xpath is:  '{xpath}', not found.");
            }
        }

        public void ClickButton(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }
        public void ClickButtonTripleTime(string xpath)
        {
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.XPath(xpath)).Click();
            }
        }

        public static void TakeScreenShot(IWebDriver driver, string fileName)
        {
            var screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            if (!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }

            screenshot.SaveAsFile(
                $"Screenshots\\{fileName}.png",
                ScreenshotImageFormat.Png);
        }
    }
}
