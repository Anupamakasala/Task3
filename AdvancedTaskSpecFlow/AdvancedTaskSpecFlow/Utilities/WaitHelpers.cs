using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Utilities
{
    public class WaitHelpers
    {
            public static void WaitToBeClickable(IWebDriver driver, string locator, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            public static void WaitToExist(IWebDriver driver, string locator, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            }

            public static void WaitToBeVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }



    }

    }

