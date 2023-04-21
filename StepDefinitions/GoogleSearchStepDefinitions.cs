using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class GoogleSearchStepDefinitions
    {
        private IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public GoogleSearchStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open the Browser")]
        public void GivenOpenTheBrowser()
        {
            //driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "https://www.google.com/";
            Thread.Sleep(2000);
        }

        [Then(@"Search for Selenium tutorials")]
        public void ThenSearchForSeleniumTutorials()
        {
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys("Selenium Tutorial");
            driver.FindElement(By.XPath("//*[@id='APjFqb']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Selenium Tutorial PDF")).Click();
            string title = driver.Title.ToString();
            Console.WriteLine("Page it took me after navigation is:" + title);
            if (title.Contains("PDF"))
            {
                Assert.AreEqual(title, "Selenium Tutorial PDF for Beginners (Download Free Material)", "Value for the title matches:" + title + " !=" + "Selenium Tutorial PDF for Beginners(Download Free Material)+");
            }
            else
            {
                Assert.AreEqual(title, "Selenium Tutorial PDF for Beginners (Download Free Material)", "Value for the title did not match:" + title + " !=" + "Selenium Tutorial PDF for Beginners(Download Free Material)+");
            }            
        }

        [Then(@"Click on First Chapter Link displayed on the webpage")]
        public void ThenClickOnFirstChapterLinkDisplayedOnTheWebpage()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebElement element = (WebElement)driver.FindElement(By.LinkText("First Chapter"));
            js.ExecuteScript("arguments[0].scrollIntoView();", element); // scroll to your desired webelement on the webpage
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)"); // scroll until end of webpage
            Thread.Sleep(1000);
            //driver.Quit();
        }

    }
}