using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow
{
    [Binding]
    public class Hooks:CommonDriver
    {
        [BeforeTestRun]
        public void login()
        {
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
        }



        [AfterTestRun]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
