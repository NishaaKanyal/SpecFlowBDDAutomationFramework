using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.PageObjects
{
    public class SearchPage
    {
        private IWebDriver driver;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By searchTextBox = By.XPath("//*[@name='search_query']");


        public ResultsPage searchText(string text)
        {
            driver.FindElement(searchTextBox).SendKeys(text);
            driver.FindElement(searchTextBox).SendKeys(Keys.Enter);
            return new ResultsPage(driver);
        }


    }
}
