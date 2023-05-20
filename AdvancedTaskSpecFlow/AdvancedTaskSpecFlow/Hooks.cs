﻿using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow
{
    [Binding]
    public sealed class Hooks:CommonDriver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void login()
        {
            driver = new ChromeDriver();
           
            LoginPage loginPageObj = new LoginPage();
           
        }



        //[AfterTestRun]
        //public static void CloseBrowser()
        //{
           // driver.Close();
       // }

        [BeforeScenario("@tag1")]
        public static void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public static void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}