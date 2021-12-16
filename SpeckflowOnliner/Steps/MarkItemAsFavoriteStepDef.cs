using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Steps
{
    [Binding]
    class MarkItemAsFavoriteStepDef
    {
        private readonly String _product = "Телевизоры";
        private String _expectedProductTitle;

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly SearchResultPage _searchResultPage;
        private readonly ProductPage _productPage;
        private readonly BookmarkPage _bookmarkPage;

        public MarkItemAsFavoriteStepDef(Driver driver)
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
            _previewResultPage = new PreviewResultPage(driver.CurrentDriver);
            _searchResultPage = new SearchResultPage(driver.CurrentDriver);
            _productPage = new ProductPage(driver.CurrentDriver);
            _bookmarkPage = new BookmarkPage(driver.CurrentDriver);
        }

        [Given(@"User logs into the system")]
        public void GivenUserLogsIntoTheSystem()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname();
            _loginPage.EnterPassword();
            _loginPage.ClickOnSubmitBtn();
        }

        [When(@"The user looks for a specific item")]
        public void WhenTheUserLooksForASpecificItem()
        {
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);
            _searchResultPage.ClickOnFirstItem();
        }

        public string Get_expectedProductTitle()
        {
            return _expectedProductTitle;
        }

        [When(@"Marks it as a favorite one")]
        public void WhenMarksItAsAFavoriteOne()
        {
            _expectedProductTitle = _productPage.GetProductTitle();
            _productPage.AddProductToFavoriteList();
        }

        public BookmarkPage Get_bookmarkPage()
        {
            return _bookmarkPage;
        }

        [Then(@"The item is added to the favorite list")]
        public void ThenTheItemIsAddedToTheFavoriteList()
        {
            _productPage.ProccedToPersonalBookmarks();
            Assert.AreEqual(_expectedProductTitle, _bookmarkPage.GetSpecificProductName(_expectedProductTitle));
        }


    }
}
