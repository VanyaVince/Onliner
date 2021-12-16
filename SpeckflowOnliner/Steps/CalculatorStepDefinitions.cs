using FluentAssertions;
using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;
using TechTalk.SpecFlow;

namespace SpeckflowOnliner.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Page Object for Calculator
        private readonly CalculatorPage _calculatorPage;

        public CalculatorStepDefinitions(Driver driver)
        {
            _calculatorPage = new CalculatorPage(driver.CurrentDriver);
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPage.Open();
            _calculatorPage.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPage.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //delegate to Page Object
            _calculatorPage.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            //delegate to Page Object
            var actualResult = _calculatorPage.WaitForNonEmptyResult();

            actualResult.Should().Be(expectedResult.ToString());
        }
    }

    

}
