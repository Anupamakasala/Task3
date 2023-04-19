using AdvanceTask_NUnit.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class Notifications : Base
    {
        public static IWebElement notificationTab => driver.FindElement(By.XPath("//div[1]/div[2]/div/div"));
        public static IWebElement seeAllElement => driver.FindElement(By.XPath("//a[@href='/Account/Dashboard']"));
        public static IWebElement checkBox => driver.FindElement(By.XPath("//input[@type='checkbox']"));
        public static IWebElement deleteIcon => driver.FindElement(By.XPath("//div[@data-tooltip='Delete selection']"));
        public static IWebElement selectAllIcon => driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
        public static IWebElement markAsReadIcon => driver.FindElement(By.XPath("//i[@class='check square icon']"));

        public string MarkAsRead()
        {
            //Wait_Helpers.WaitToExist(driver, "XPath", "//div[1]/div[2]/div/div", 10);
            Thread.Sleep(3000);
            notificationTab.Click();
            // Wait_Helpers.WaitToExist(driver, "XPath", "//a[@href='/Account/Dashboard']", 10);
            Thread.Sleep(2000);
            seeAllElement.Click();
            //Wait_Helpers.WaitToExist(driver, "XPath", "//i[@class='mouse pointer icon']", 10);
            Thread.Sleep(2000);
            selectAllIcon.Click();
            markAsReadIcon.Click();
            driver.Navigate().Refresh();
            Wait_Helpers.WaitToExist(driver, "XPath", " //div[@class='item link']", 10);

            var HighlightedText = driver.FindElement(By.XPath(" //div[@class='item link']")).GetCssValue("font-weight");
            return HighlightedText;

        }
        public string DeleteNotification()
        {
            //Wait_Helpers.WaitToExist(driver, "XPath", "/div[@class='ui top left pointing dropdown item']", 20);
            Thread.Sleep(3000);
            notificationTab.Click();
            Thread.Sleep(3000);
            //Wait_Helpers.WaitToExist(driver, "XPath", "//a[@href='/Account/Dashboard']", 10);
            seeAllElement.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", "//input[@type='checkbox']", 10);
            selectAllIcon.Click();
            deleteIcon.Click();
            driver.Navigate().Refresh();
            Wait_Helpers.WaitToExist(driver, "XPath", "//div[2]/div/div/div[3]/div[2]/span/div", 10);
            var NotificationText = driver.FindElement(By.XPath("//div[2]/div/div/div[3]/div[2]/span/div")).Text;
            Console.WriteLine(NotificationText);
            return NotificationText;

        }






    }
}