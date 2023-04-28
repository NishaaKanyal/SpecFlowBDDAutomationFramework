using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenTestingStepDefinitions
    {
        private IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public DataDrivenTestingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Then(@"Search for '([^']*)'")]
        public void ThenSearchFor(string searchKey)
        {
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(searchKey);
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }



    }
}