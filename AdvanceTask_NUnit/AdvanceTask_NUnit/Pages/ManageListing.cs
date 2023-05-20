using AdvanceTask_NUnit.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class ManageListing:Base
    {
        public ManageListing()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ListingManagement']")]
        public IWebElement manageListingLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        public IWebElement eyeIcon;

        [FindsBy(How = How.XPath, Using = "//div[@class='active section']")]
        public IWebElement viewListing;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[8]/div/button[2]")]
        public IWebElement writeIcon;

        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement titleTextbox;

        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement descriptionTextbox;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        public IWebElement addTags;

        [FindsBy(How = How.Name, Using = "skillTrades")]
        public IList<IWebElement> skillTrade;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        public IWebElement skillTags;

        [FindsBy(How = How.Name, Using = "charge")]
        public IWebElement credit;

        [FindsBy(How = How.XPath, Using = "//input[@type='button'and@value='Save']")]
        public IWebElement save;

        [FindsBy(How = How.XPath, Using = "//i[@class = 'remove icon']")]
        public IWebElement deleteIcon;

        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        public IWebElement deleteYesbutton;



        //// this is passed from  the test.
        //public ShareSkill varShareSkill;



        public void EditListing(string title, string description, string addtags, string skilltrade, string skilltags, string charge)
        {
            Wait_Helpers.WaitToExist(driver, "XPath", "//a[@href='/Home/ListingManagement']", 10);
            manageListingLink.Click();
            Thread.Sleep(4000);
            Wait_Helpers.WaitToExist(driver, "XPath", "/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[8]/div/button[2]", 10);
            writeIcon.Click();
            Thread.Sleep(2000);
            titleTextbox.Clear();
            titleTextbox.SendKeys(title);
            descriptionTextbox.SendKeys(description);
            addTags.SendKeys(addtags);

            if (skilltrade == "Skill-exchange")
            {
                IWebElement skillElement = skillTrade[0];
                skillElement.Click();
                skillTags.SendKeys(skilltags);
                skillTags.SendKeys(Keys.Enter);
            }
            if (skilltrade == "Credit")
            {
                IWebElement skillElement = skillTrade[1];
                skillElement.Click();
                credit.SendKeys(charge);
            }

            save.Click();

        }

        public string GetEditedManageListing()
        {

            Wait_Helpers.WaitToExist(driver, "XPath", "//div[2]/div[1]/div[1]/table/tbody/tr/td[3]", 10);
            var manageLisitngTitle = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[3]"));
            return manageLisitngTitle.Text;
            
        }



    }

    
}
