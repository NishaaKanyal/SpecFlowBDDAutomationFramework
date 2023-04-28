using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class ExamplesDataDrivenTestingStepDefinitions
    {
        private IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public ExamplesDataDrivenTestingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Then(@"Search with (.*)")]
        public void ThenSearchWithSeleniumTutorials(string searchKey)
        {
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(searchKey);
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }




    }
}