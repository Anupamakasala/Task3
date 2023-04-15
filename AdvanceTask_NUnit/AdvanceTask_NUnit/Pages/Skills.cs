using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_NUnit.Global;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Pages
{
    public class Skills :Base
    {
        public Skills()
        {
            ExcelUtil.PopulateInCollection(@"D:\Advanced_Tasks\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "Skills");
        }

        IWebElement SkillTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
        IWebElement SkillAddButton => driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement SkillTextbox => driver.FindElement(By.Name("name"));
        IWebElement SkillAdd => driver.FindElement(By.XPath("//input [@type ='button' and @value='Add']"));
        IWebElement newskill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        IWebElement newSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        IWebElement EditSkillIcon => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]/i"));
        IWebElement EditSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        IWebElement SkillUpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
        IWebElement newUpdatedskill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        IWebElement newUpdatedSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        IWebElement DeleteSkillIcon => driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
        IWebElement deletedSkill => driver.FindElement(By.XPath("//div[@class='form-wrapper']/table/tbody[last()]/tr[1]/td[1]"));

        //Wait for the AddNew button to be clickable
        public string Wait0 = "//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div";
        //Wait for the textbox to be clickable
        public string Wait1 = "//div[@data-tab='second']/div/div[2]/div/div/div[1]/input";
        //Wait for the text to exist
        public string Wait2 = "//div[@data-tab='second']//table/tbody/tr/td[1]";
        //Wait for Delete icon to be clickable
        public string Wait3 = "//div[@data-tab='second']//table/tbody/tr/td[3]/span[2]/i";

        //Add Skills
        public void clickSkillTab()
        {
            SkillTab.Click();
            //Wait_Helpers.WaitToBeVisible(driver, "XPath", "Wait0", 5);
            Thread.Sleep(3000);
        }

        public void createSkillSteps()
        {
            //ADD Skills                    

            SkillAddButton.Click();
            Wait_Helpers.WaitToBeClickable(driver, "XPath", Wait1, 5);
            SkillTextbox.SendKeys(ExcelUtil.ReadData(2, "Skill"));
            SelectElement SkillLevel = new SelectElement(driver.FindElement(By.Name("level")));
            SkillLevel.SelectByValue(ExcelUtil.ReadData(2, "SkillLevel"));

        }
        public void SkillsAdd()
        { 
            SkillAdd.Click();
            Wait_Helpers.WaiToExist(driver, "XPath", Wait2, 10);
            Thread.Sleep(3000);
        }


        public string GetSkill()
        {
            return newskill.Text;
        }
        public string GetSkillLevel()
        {
            return newSkillLevel.Text;
        }

        public string GetSkillFromExcel()
        {
            string GetSkillFromExcel = ExcelUtil.ReadData(2, "Skill");
            return GetSkillFromExcel;

        }

        public string GetLevelFromExcel()
        {
            string GetLevelFromExcel = ExcelUtil.ReadData(2, "SkillLevel");
            return GetLevelFromExcel;

        }



        //UPDATE Skills
        public void UpdateSkillSteps()
        {

            //SkillTab.Click();
            EditSkillIcon.Click();


            EditSkill.Clear();
            EditSkill.SendKeys(ExcelUtil.ReadData(3, "Skill"));

            SelectElement EditSkillLevel = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select")));
            EditSkillLevel.SelectByValue(ExcelUtil.ReadData(3, "SkillLevel"));

        }
        public void SkillUpdate()
        { 
            SkillUpdateButton.Click();
            Thread.Sleep(3000);
        }

        public string GetUpdatedSkill()
        {
            return newUpdatedskill.Text;
        }
        public string GetUpdatedSkillLevel()
        {

            return newUpdatedSkillLevel.Text;
        }

        public string GetUpdatedSkillFromExcel()
        {
            string UpdatedskillFromExcel = ExcelUtil.ReadData(3, "Skill");
            return UpdatedskillFromExcel;
        }
        public string GetUpdatedSkillLevelFromExcel()
        {
            string UpdatedLevelFromExcel = ExcelUtil.ReadData(3, "SkillLevel");
            return UpdatedLevelFromExcel;
        }






        //Delete Skills
        public void DeleteSkillSteps()

        {
            SkillTab.Click();
            Wait_Helpers.WaitToBeClickable(driver, "XPath", Wait3, 5);
            DeleteSkillIcon.Click();
            Thread.Sleep(3000);
        }

        //Validate Deleted Skill

        public string GetDeleteSkills()
        {
            return deletedSkill.Text;

        }


    }
}
