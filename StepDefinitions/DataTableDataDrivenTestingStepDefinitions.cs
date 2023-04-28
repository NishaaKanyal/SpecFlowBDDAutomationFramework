using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class DataTableDataDrivenTestingStepDefinitions
    {
        private IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public DataTableDataDrivenTestingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"Enter Search keyword in Google")]
        public void ThenEnterSearchKeywordInGoogle(Table table)
        {
            var searchCriteria = table.CreateSet<SearchKeyTestData>();
            foreach (var keyword in searchCriteria)
            {
                driver.FindElement(By.XPath("//*[@id='APjFqb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(keyword.searchKey);
                driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
            }
        }



        public class SearchKeyTestData
        {
            public string searchKey { get; set; }
        }




    }
}