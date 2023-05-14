using AdvanceTask_NUnit.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class EducationPage:Base
    {
        public IWebElement addEducation => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        public IWebElement uniTextBox => driver.FindElement(By.XPath("//input[@name='instituteName']"));
        public IWebElement dropDownCty => driver.FindElement(By.XPath("//select[@name='country']"));
        public IWebElement selectCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[66]"));
        public IWebElement dropdownTitle => driver.FindElement(By.XPath("//select[@name='title']"));
        public IWebElement degreeName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[3]"));
        public IWebElement degreenameTextbox => driver.FindElement(By.XPath("//input[@name='degree']"));
        public IWebElement dropdownyear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        public IWebElement yearLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[28]"));
        public IWebElement addeducationButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button ']"));

        public void AddEducation()
        {


            GlobalDefinitions.ExcelUtil.PopulateInCollection(@"C:\Users\solan\Desktop\Group Prject advance task\Task 3\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "Education");


            //Add education
            addEducation.Click();

            //click on Uni Name
            uniTextBox.Click();
            uniTextBox.SendKeys(GlobalDefinitions.ExcelUtil.ReadData(2, "College"));

            //Dropdown Click'
            dropDownCty.Click();

            //Select Country
            selectCountry.Click();

            //Dropdown title
            dropdownTitle.Click();

            //Degree Name
            degreeName.Click();

            //Enter degree name
            degreenameTextbox.SendKeys(GlobalDefinitions.ExcelUtil.ReadData(2, "Degree"));

            //Dropdown year level
            dropdownyear.Click();

            //Choose year level
            yearLevel.Click();

            addeducationButton.Click();

        }
    }
}

