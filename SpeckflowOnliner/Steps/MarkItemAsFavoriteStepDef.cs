using System;
using System.Collections.Generic;
using System.Text;
using SpeckflowOnliner.Pages;

namespace SpeckflowOnliner.Steps
{
    class MarkItemAsFavoriteStepDef
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        public MarkItemAsFavoriteStepDef()
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
        }
    }
}
