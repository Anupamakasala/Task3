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
    public class Skills : Base
    {
        public Skills()
        {
            ExcelUtil.PopulateInCollection(excelPath, "Skills");
        }

        IWebElement skillTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
        IWebElement skillAddButton => driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement skillTextbox => driver.FindElement(By.Name("name"));
        IWebElement skillAdd => driver.FindElement(By.XPath("//input [@type ='button' and @value='Add']"));
        IWebElement newSkill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        IWebElement newSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        IWebElement editSkillIcon => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]/i"));
        IWebElement editSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        IWebElement skillUpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
        IWebElement newUpdatedskill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        IWebElement newUpdatedSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        IWebElement deleteSkillIcon => driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
        IWebElement deletedSkill => driver.FindElement(By.XPath("//div[@class='form-wrapper']/table/tbody[last()]/tr[1]/td[1]"));
        //IWebElement msgError1 => driver.FindElement(By.XPath("//div[@class='ns-box-inner' and text()='Please enter skill and experience level'] "));
        IWebElement msgError1 => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Wait for the AddNew button to be clickable
        public string wait0 = "//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div";
        //Wait for the textbox to be clickable
        public string wait1 = "//div[@data-tab='second']/div/div[2]/div/div/div[1]/input";
        //Wait for the text to exist
        public string wait2 = "//div[@data-tab='second']//table/tbody/tr/td[1]";
        //Wait for Delete icon to be clickable
        public string wait3 = "//div[@data-tab='second']//table/tbody/tr/td[3]/span[2]/i";

        

        //Add Skills
        public void ClickSkillTab()
        {
            
            skillTab.Click();
            //Wait_Helpers.WaitToBeVisible(driver, "XPath", "wait0", 5);
            Thread.Sleep(3000);
        }

        public void CreateSkillSteps()
        {
            //ADD Skills                    
            
            skillAddButton.Click();
            Wait_Helpers.WaitToBeClickable(driver, "XPath", wait1, 5);
            skillTextbox.SendKeys(ExcelUtil.ReadData(2, "Skill"));
            SelectElement skillLevel = new SelectElement(driver.FindElement(By.Name("level")));
            skillLevel.SelectByValue(ExcelUtil.ReadData(2, "SkillLevel"));

        }
        public void SkillsAdd()
        { 
            skillAdd.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", wait2, 10);
            Thread.Sleep(3000);
        }


        public string GetSkill()
        {
            return newSkill.Text;
        }
        public string GetSkillLevel()
        {
            return newSkillLevel.Text;
        }

        public string GetSkillFromExcel()
        {
            string getSkillFromExcel = ExcelUtil.ReadData(2, "Skill");
            return getSkillFromExcel;

        }

        public string GetLevelFromExcel()
        {
            string getLevelFromExcel = ExcelUtil.ReadData(2, "SkillLevel");
            return getLevelFromExcel;

        }



        //UPDATE Skills
        public void UpdateSkillSteps()
        {

            //SkillTab.Click();
            editSkillIcon.Click();


            editSkill.Clear();
            editSkill.SendKeys(ExcelUtil.ReadData(3, "Skill"));

            SelectElement editSkillLevel = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select")));
            editSkillLevel.SelectByValue(ExcelUtil.ReadData(3, "SkillLevel"));

        }
        public void SkillUpdate()
        { 
            skillUpdateButton.Click();
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
            string updatedskillFromExcel = ExcelUtil.ReadData(3, "Skill");
            return updatedskillFromExcel;
        }
        public string GetUpdatedSkillLevelFromExcel()
        {
            string updatedLevelFromExcel = ExcelUtil.ReadData(3, "SkillLevel");
            return updatedLevelFromExcel;
        }

        //Delete Skills
        public void DeleteSkillSteps()

        {
            //skillTab.Click();
            Wait_Helpers.WaitToBeClickable(driver, "XPath", wait3, 5);
            deleteSkillIcon.Click();
            Thread.Sleep(3000);
        }

        //Validate Deleted Skill

        public string GetDeleteSkills()
        {
            return deletedSkill.Text;

        }


        //Duplicate Skill
        public string Duplicate()
        {
            //skillTab.Click();
            Thread.Sleep(3000);

            skillAddButton.Click();

            skillTextbox.SendKeys(ExcelUtil.ReadData(2, "Skill"));
            SelectElement SkillLevel = new SelectElement(driver.FindElement(By.Name("level")));
            SkillLevel.SelectByValue(ExcelUtil.ReadData(2, "SkillLevel"));

            skillAdd.Click();
            Thread.Sleep(3000);
            return msgError1.Text;

        }
        //Negative Tests
        public string NegativeTestNoSkill()
        {
            //skillTab.Click();
            Thread.Sleep(3000);

            skillAddButton.Click();

            //skillTextbox.SendKeys(ExcelUtil.ReadData(4, "Skill"));
            SelectElement SkillLevel = new SelectElement(driver.FindElement(By.Name("level")));
            SkillLevel.SelectByValue(ExcelUtil.ReadData(4, "SkillLevel"));

            skillAdd.Click();
            Thread.Sleep(3000);
            return msgError1.Text;

        }

        public string NegativeTestNoSkillLevel()
        {
            //skillTab.Click();
            Thread.Sleep(3000);
            skillAddButton.Click();
            skillTextbox.SendKeys(ExcelUtil.ReadData(5, "Skill"));            
            skillAdd.Click();
            Thread.Sleep(3000);
            return msgError1.Text;
        }

        public string NegativeTestNone()
        {
            //skillTab.Click();
            Thread.Sleep(3000);
            skillAddButton.Click();
            skillAdd.Click();
            Thread.Sleep(3000);
            return msgError1.Text;
        }


        public string DuplicateUpdateSkill()
        {

            //skillTab.Click();
            editSkillIcon.Click();
            Thread.Sleep(3000);
            skillUpdateButton.Click();
            return msgError1.Text;
        }



    }
}
