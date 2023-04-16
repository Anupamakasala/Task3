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
    public class ManageListingPg:Base
    {
        public IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        public IWebElement ConfirmButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));


        public void DeleteSkill()
        {
            

            //Click on delet button
            deleteButton.Click();

            ConfirmButton.Click();

        }
    }
}
