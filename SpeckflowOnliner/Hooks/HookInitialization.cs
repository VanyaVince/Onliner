using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeckflowOnliner.Drivers;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        private readonly Driver _driver;

        public HookInitialization(Driver driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.CurrentDriver.Quit();
        }
    }
}
