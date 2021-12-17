using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Steps
{
    [Binding]
    class DeleteProductFromCartStepDef
    {
        private readonly String _product = "Телевизоры";

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly SearchResultPage _searchResultPage;
        private readonly ProductPage _productPage;
        private readonly PreviewCartPage _productCartPage;

        public DeleteProductFromCartStepDef(Driver driver)
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
            _previewResultPage = new PreviewResultPage(driver.CurrentDriver);
            _searchResultPage = new SearchResultPage(driver.CurrentDriver);
            _productPage = new ProductPage(driver.CurrentDriver);
            _productCartPage = new PreviewCartPage(driver.CurrentDriver);  
        }

        [Given(@"User has the product to buy")]
        public void GivenUserHasTheProductToBuy()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname();
            _loginPage.EnterPassword();
            _loginPage.ClickOnSubmitBtn();
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);
            _searchResultPage.ClickOnFirstItem();
            _productPage.AddProductCart();
            _productCartPage.ProceedToCart();

        }

        [When(@"The product has been removed from the cart")]
        public void WhenTheProductHasBeenRemovedFromTheCart()
        {
            Thread.Sleep(6000);
            throw new PendingStepException();
        }

        [Then(@"The cart no longer includes the product")]
        public void ThenTheCartNoLongerIncludesTheProduct()
        {
            throw new PendingStepException();
        }

    }
}
