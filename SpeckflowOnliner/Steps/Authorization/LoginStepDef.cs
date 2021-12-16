using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Steps
{
    [Binding]
    public sealed class LoginStepDef
    {
        private int expectedId = 3397717;

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        public LoginStepDef(Driver driver)
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
        }
        
        [Given("The login page is opened")]
        public void GivenTheLoginPageIsOpened()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
        }

        [When("Valid credentials are entered")]
        public void WhenValidCredentialsAreEntered()
        {
            _loginPage.EnterNickname();
            _loginPage.EnterPassword();
        }

        [When("The enter button is pushed")]
        public void WhenTheEnterButtonIsPushed()
        {
            _loginPage.ClickOnSubmitBtn(); 
        }

        [Then("User's profile is appeared")]
        public void ThenUserProfileIsAppeared()
        {
            _homePage.ClickOnProfileItem();
            var actualId = _homePage.GetUserId();
            Assert.AreEqual(expectedId, actualId);
        }
    }
}
