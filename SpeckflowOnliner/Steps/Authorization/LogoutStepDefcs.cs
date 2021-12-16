using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Steps.Authorization
{
    [Binding]
    public sealed class LogoutStepDef
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        public LogoutStepDef(Driver driver)
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
        }

        [Given(@"A user logs in with valid credentials")]
        public void GivenAUserLogsInWithValidCredentials()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname();
            _loginPage.EnterPassword();
            _loginPage.ClickOnSubmitBtn();
        }

        [When(@"The user attempts to logout")]
        public void WhenTheUserAttemptsToLogout()
        {
            _homePage.ClickOnProfileItem();
            _homePage.ClickOnLogoutBtn();
        }

        [Then(@"User's profile is disappeared")]
        public void ThenUserProfileIsDisappeared()
        {
            Assert.IsTrue(_homePage.IsLoginBtnDisplayed());
        }

    }
}
