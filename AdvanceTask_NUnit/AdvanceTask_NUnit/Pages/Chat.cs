using AdvanceTask3.Utilities;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace AdvanceTask3.Pages
{
    public class Chat : CommonDriver
    {
        private IWebElement chatBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]"));
        private IWebElement chatTextBox => driver.FindElement(By.Id("chatTextBox"));
        private IWebElement sentBtn => driver.FindElement(By.Id("btnSend"));
        private IWebElement lastChatMsg => driver.FindElement(By.XPath("//*[@id=\"chatBox\"]/div[last()]/div/div/span"));
        
        public void SendChatMsg(IWebDriver driver, string message) 
        {
            Wait.WaitForElementToExist(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/a[1]", 5);
            chatBtn.Click();

            Thread.Sleep(5000);
            IWebElement lastChatRow = driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div[3]"));
            lastChatRow.Click();

            chatTextBox.Clear();
            chatTextBox.SendKeys(message);
            sentBtn.Click();
        }

        public string getChatMsg()
        {
            IWebElement lastChatRow = driver.FindElement(By.XPath("//*[@id=\"chatList\"]/div[3]"));
            lastChatRow.Click();
            //get last span ? 
            Console.WriteLine("lastChatMsg : " + lastChatMsg.Text);
            return lastChatMsg.Text;
        }
    }
}
