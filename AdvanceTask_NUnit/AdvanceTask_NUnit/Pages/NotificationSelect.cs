using AdvanceTask3.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask3.Pages
{
    public class Notification : CommonDriver
    {
        private IWebElement notificationTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement seeAll => driver.FindElement(By.LinkText("See All..."));
        
        public bool SelectAllNotifications(IWebDriver driver)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div", 10);
            notificationTab.Click();
            Wait.WaitForElementToExist(driver, "LinkText", "See All...", 3);
            seeAll.Click();
            Thread.Sleep(2000);

            IWebElement selectAllBtn = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]"));
            selectAllBtn.Click();

            IWebElement firstNonitication = driver.FindElement(By.XPath("//input[@value='0']"));
            return firstNonitication.Selected;
        }

        public bool UnselectNotifications(IWebDriver driver)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div", 10);
            notificationTab.Click();
            Wait.WaitForElementToExist(driver, "LinkText", "See All...", 3);
            seeAll.Click();
            Thread.Sleep(2000);

            IWebElement firstNonitication = driver.FindElement(By.XPath("//input[@value='0']"));
            if (!firstNonitication.Selected)
            {
                firstNonitication.Click();
            }
            IWebElement unselectAll = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
            unselectAll.Click();

            return firstNonitication.Selected; 
        }

    }
}
