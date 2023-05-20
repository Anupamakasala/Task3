using AdvanceTask3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AdvanceTask3.Pages
{
    public class ProfileExtra : CommonDriver
    {
        private IWebElement locationElement => driver.FindElement(By.XPath("//div/div[3]/div/div[1]/span/strong"));
        private IWebElement availabilityEditBtn => driver.FindElement(By.XPath("//div[2]/div/span/i"));
        private IWebElement availability => driver.FindElement(By.XPath("//div[3]/div/div[2]/div/span"));
        private IWebElement cancelEditAvailabilityBtn => driver.FindElement(By.XPath("//div[2]/div/span/i"));
        private IWebElement hoursEditBtn => driver.FindElement(By.XPath("//div/div[3]/div/span/i"));
        private IWebElement availableHour => driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span"));
        private IWebElement CancelEditHoursBtn => driver.FindElement(By.XPath("//div/div[3]/div/span/i"));
        private IWebElement EarnTargetEditBtn => driver.FindElement(By.XPath("//div/div[4]/div/span/i"));
        private IWebElement earnTarget => driver.FindElement(By.XPath("//div[3]/div/div[4]/div/span"));
        private IWebElement CancelEditEarnTargetBtn => driver.FindElement(By.XPath("//div/div[4]/div/span/i"));

        //Verify "Location" field on Profile page

        public string LocationElement()
        {
            Wait.WaitForElementToExist(driver, "XPath", "//div/div[3]/div/div[1]/span/strong", 5);
            //verify the element presents or not
            return locationElement.Text;
        }

        //Edit "Availability" field on Profile page      
        public void EditAvailability(string availableTimeType)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//div[2]/div/span/i", 5);
            availabilityEditBtn.Click();
            new SelectElement(driver.FindElement(By.Name("availabiltyType"))).SelectByText(availableTimeType);
        }
        public string GetAvailability()
        {          
            return availability.Text;
        }

        //Cancel edit "Availability" field on Profile page
        public void CancelAddAvailability()
        {          
            cancelEditAvailabilityBtn.Click();
        }


        //Edit "Hours" field on Profile page
        public void EditHours(string availableHours)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//div/div[3]/div/span/i", 5);
            hoursEditBtn.Click();
            new SelectElement(driver.FindElement(By.Name("availabiltyHour"))).SelectByText(availableHours);
        }

        //Cancel edit "Hours" field on Profile page      
        public void CancelEditHours()
        {         
            CancelEditHoursBtn.Click();
        }
   
        public string GetHours()
        {
            return availableHour.Text;
        }

        //Edit "Earn Target" field on Profile page      
        public void EditEarnTarget(string earnTarget)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//div/div[4]/div/span/i", 5);
            EarnTargetEditBtn.Click();
            new SelectElement(driver.FindElement(By.Name("availabiltyTarget"))).SelectByText(earnTarget);
        }

        //Cancel edit "EarnTarget" field on Profile page       
        public void CancelEditEarnTarget()
        {         
            CancelEditEarnTargetBtn.Click();
        }
        
        public string  GetEarnTarget()
        {
            return earnTarget.Text;
        }

    }
}
