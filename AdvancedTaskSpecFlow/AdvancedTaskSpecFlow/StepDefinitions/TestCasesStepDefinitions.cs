using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]

    public class TestCasesStepDefinitions : CommonDriver
    {


        SignUp signUpObj = new SignUp();

        LoginPage loginPageObj = new LoginPage();

        NotificationMoreAndLess notificationObj = new NotificationMoreAndLess();


        [Given(@"I entered the required credentials to join the LocalHost")]
        public void GivenIEnteredTheRequiredCredentialsToJoinTheLocalHost()
        {

            signUpObj.Register(driver);
        }

        [When(@"I clicked on the Join Button")]
        public void WhenIClickedOnTheJoinButton()
        {

        }

        [Then(@"It Navigates me to the LocalHost HomePage")]
        public void ThenItNavigatesMeToTheLocalHostHomePage()
        {

        }

        [Then(@"I Successfully Registered as a new User")]
        public void ThenISuccessfullyRegisteredAsANewUser()
        {
            string registrationSuccessfulPopUpMessage = signUpObj.GetPopUpMessage(driver);
            Assert.That(registrationSuccessfulPopUpMessage == "Registration successful", "Actual popup message and expected popup message do not match");


        }



        //For login into the portal


        [Given(@"I entered my credentials for Login")]
        public void GivenIEnteredMyCredentialsForLogin()
        {

           driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I clicked on the Login Button")]
        public void WhenIClickedOnTheLoginButton()
        {

        }

        [Then(@"It Navigates me to the Profile page")]
        public void ThenItNavigatesMeToTheProfilePage()
        {

        }

        [Then(@"I Successfully Logged into the Portal")]
        public void ThenISuccessfullyLoggedIntoThePortal()
        {
            string newName = loginPageObj.GetName(driver);
            Assert.That(newName == "Hi Task", "Actual name and expected name do not match");
        }



        //For Load More

        [Given(@"I Logged into the LocalHost successfully")]
        
        public void GivenILoggedIntoTheLocalHostSuccessfully()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I clicked on the Notification dropdown menu")]
        public void WhenIClickedOnTheNotificationDropdownMenu()
        {
            notificationObj.LoadMoreNotification(driver);
        }

        [When(@"I clicked on the See All Button")]
        public void WhenIClickedOnTheSeeAllButton()
        {

        }

        [Then(@"It navigates me to the notification page")]
        public void ThenItNavigatesMeToTheNotificationPage()
        {
          
        }

        [When(@"I clicked on the LoadMore button at the bottom")]
        public void WhenIClickedOnTheLoadMoreButtonAtTheBottom()
        {
            
        }

        [Then(@"All the Notifications displayed on the page")]
        public void ThenAllTheNotificationsDisplayedOnThePage()
        {
            string ShowLessText = notificationObj.GetShowLessText(driver);
            Assert.That(ShowLessText == "...Show Less", "Actual text and Expected Text do not match");

        }



        // For Show Less


        [When(@"I clicked on the ShowLess button at the bottom")]
        public void WhenIClickedOnTheShowLessButtonAtTheBottom()
        {
          
            notificationObj.ShowLessNotification(driver);
        }

        [Then(@"Only Few Latest notifications displayed on the page")]
        public void ThenOnlyFewLatestNotificationsDisplayedOnThePage()
        {
            string LoadMoreText = notificationObj.GetLoadMoreText(driver);
            Assert.That(LoadMoreText == "Load More...", "Actual text and expected text do not match");

        }
    }
}
