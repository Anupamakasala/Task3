using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_NUnit.Global;

namespace AdvanceTask_NUnit.Pages
{
    public class ChatPage:Base
    {
     
        public IWebElement searchSkillTextBox => driver.FindElement(By.XPath("//input[@placeholder ='Search skills']"));

        public IWebElement searchButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
        public IWebElement createBlogClk => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p"));
        public IWebElement chatButton => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/div/a"));
        
        public IWebElement typeMessage => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div/div/div/div/input"));

        public IWebElement sendBtn => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div/div/div/div/button[1]"));
        public void OpenChatTextbox()
        {

        
            Thread.Sleep(2000);
           
            searchSkillTextBox.Click();

            searchSkillTextBox.SendKeys("Create Blogs");

            Wait_Helpers.wait(1000);
            // Click Search button
            searchButton.Click();

            //click on the icon
            createBlogClk.Click();

            Wait_Helpers.wait(1000);
            //Click on Chat btn
            chatButton.Click();

            //Type message
            typeMessage.SendKeys("Hello");
            //Go to last page
            sendBtn.Click();

        }
    }
}
