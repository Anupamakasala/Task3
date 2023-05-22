using AdvanceTask3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System;


namespace AdvanceTask3.Pages
{
    public class LanguageTab
    {
        public void AddLanguage(IWebDriver driver, string language, string level)
        {

            Wait.WaitForElementToExist(driver, "XPath", "//div/table/thead/tr/th[3]/div", 20);

            IWebElement addNewBtn = driver.FindElement(By.XPath("//div/table/thead/tr/th[3]/div"));  // <div> Add New </div>
            addNewBtn.Click();

            IWebElement newLang = driver.FindElement(By.Name("name"));
            newLang.SendKeys(language);

            //IWebElement newLangLevel = driver.FindElement(By.Name("level"));
            new SelectElement(driver.FindElement(By.Name("level"))).SelectByValue(level);

            IWebElement addBtn = driver.FindElement(By.XPath("//input[@value='Add']"));
            addBtn.Click();
        }
    
        //verification 
        public string GetLangName(IWebDriver driver)
        {

            Thread.Sleep(5000);
            Wait.WaitForElementToExist(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 5);
            IWebElement langName = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Console.WriteLine("5. langName.Text : " + langName.Text);
            return langName.Text;
        }

        //verification 
      
        public string GetLangLevel(IWebDriver driver)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[2]/tr[last()]/td[2]", 5);
            IWebElement langLevel = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[2]/tr[last()]/td[2]"));
            Debug.WriteLine(langLevel.Text);
            return langLevel.Text;
        }

      
        public void EditLanguage(IWebDriver driver, string lang, string level)
        {
            Wait.WaitForElementToExist(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]", 6);
            string newLangCreated = GetLangName(driver);
            Console.WriteLine("0 Lang to be edited : " + newLangCreated);

            //check record exist before edit it, avoid affecting other records
            
            if (newLangCreated == "English")
            {
                Wait.WaitForElementToExist(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]", 6);
                //edit button
                driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]")).Click();

            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found, language record not edited");
            }
            
            Thread.Sleep(10);
            //driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]")).Click();
            Wait.WaitForElementToExist(driver, "Name", "name", 16);
            IWebElement langTextBox = driver.FindElement(By.Name("name"));
            langTextBox.Clear();
            langTextBox.SendKeys(lang);

            Thread.Sleep(10);
            new SelectElement(driver.FindElement(By.Name("level"))).SelectByValue(level);
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
      
 
        public void DeleteLang(IWebDriver driver)
        {
            //find the record to be deleted
            Wait.WaitForElementToExist(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 6);

            IWebElement langName = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr[last()]/td[1]"));
            Debug.WriteLine(langName.Text);

            //find the delete button
            IWebElement deleteBtn = driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            //click delete button
            deleteBtn.Click();

        }

        public string DeleteLangConfirm(IWebDriver driver) 
        {
            Thread.Sleep(3000);
            IWebElement successNotification = driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));

            Wait.WaitForElementToExist(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 10);
            string successMessage = successNotification.Text;
            return successMessage;

        }
    }
}
