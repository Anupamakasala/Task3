using AdvanceTask_NUnit.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Pages
{
    public class SearchSkills : Base
    {
        public SearchSkills()
        {
            ExcelUtil.PopulateInCollection(excelPath, "SearchShareSkill"); 
        }
        IWebElement SearchSkillTextbox => driver.FindElement(By.XPath("//div[@class = 'ui small icon input search-box']/input[@placeholder = 'Search skills']"));
        
        IWebElement SearchIcon => driver.FindElement(By.XPath("//div[@class = 'ui small icon input search-box']/i[@class = 'search link icon']"));

        IWebElement AllCategories => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]/b"));

        IWebElement ProgrammingTech => driver.FindElement(By.XPath("//section[@class='search-results']//div[@class='four wide column']//div[@class='ui link list']/a[7]"));

        IWebElement Qa => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[11]"));

        //IWebElement SearchUser => driver.FindElement(By.XPath("//div[@class='ui search']/div[@class='ui icon input fluid']/input[@placeholder ='Search user']"));
        //IWebElement SearchUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[3]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));

        
        IWebElement Search2 => driver.FindElement(By.XPath("//section[@class='search-results']//div[@class='ui small icon input search-box']//input[@placeholder='Search skills']"));

        IWebElement Search2Icon => driver.FindElement(By.XPath(" //section[@class='search-results']/div[@class='ui grid']/div[@class='four wide column']/div[@class='ui small icon input search-box']/i"));
        IWebElement SearchByUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));
        IWebElement SearchUserSearchIcon => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[2]/i"));

        IWebElement SelectUser => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span"));

        IWebElement RefreshIcon => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[2]/button/i"));


        IWebElement OnlineFilterBtn => driver.FindElement(By.XPath("//section[@class='search-results']//div[@class='four wide column']/div[@class= 'ui buttons']/button[contains(text(),'Online')]"));
        IWebElement OnsiteFilterBtn => driver.FindElement(By.XPath("//section[@class='search-results']//div[@class='four wide column']/div[@class= 'ui buttons']/button[contains(text(),'Onsite')]"));
        IWebElement ShowAllFilterBtn => driver.FindElement(By.XPath("//section[@class='search-results']//div[@class='four wide column']/div[@class= 'ui buttons']/button[contains(text(),'ShowAll')]"));


        public string WaitSearchTextbox1 = "//div[@class = 'ui small icon input search-box']/input[@placeholder = 'Search skills']";

        
        public string WaitBtn1 = "//section[@class='search-results']//div[@class='ui grid']//div[@class='twelve wide column']//div[@class='right floated column ']/button[1]";
        public string WaitTextResultsPerPage = "//section[@class='search-results']//div[@class='ui grid']//div[@class='twelve wide column']//div[@class='right floated column ']/text()";
        public string WaitPageNo = "//*[@id=\"service-search-section\"]/div[3]/div/section/div/div[2]/div/div[3]/div[2]/div/button[2]";
        public string WaitForUser = "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]";
        //Search a Skill
        public void SearchSkillSteps()
        {
            //Thread.Sleep(3000);
            
            Wait_Helpers.WaitToExist(driver, "XPath", WaitSearchTextbox1, 20);
            SearchSkillTextbox.Click();
            SearchSkillTextbox.SendKeys(ExcelUtil.ReadData(2, "SearchSkill"));         

            SearchIcon.Click();
            Wait_Helpers.WaitToBeVisible(driver, "XPath", WaitBtn1, 10);
            
        }
        public void ClickAllCat()
        {
           
            AllCategories.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
         }

        //Refine the search by a Category
        public void ClickCategory()
        {
           
            ProgrammingTech.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
        }

        //Refine the search by a Subcategory
        public void ClickSubCategory()
        {
           
            Qa.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
        }

        //Refine search by username
        public void UserSearch()
        {
            //Thread.Sleep(3000);
            SearchByUser.Click();
            SearchByUser.SendKeys(ExcelUtil.ReadData(4, "SearchSkill"));
            Wait_Helpers.WaitToExist(driver, "XPath", WaitForUser, 10);
            SelectUser.Click();            
            Thread.Sleep(3000);
            
        }

        //Refresh the search
        public void ClickRefresh()
        {
            
            RefreshIcon.Click();
        }


        //Search a  skill 
        public void ClickSearchSkillInner()
        {
            
            Search2.Click();
            Search2.SendKeys(ExcelUtil.ReadData(3, "SearchSkill"));
            Search2Icon.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
        }

        //Refine the search by Filter
        public void Filters()
        {

            
            OnlineFilterBtn.Click();
            
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
            
            OnsiteFilterBtn.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);
            
            ShowAllFilterBtn.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", WaitBtn1, 10);


        }

        

    }
}
