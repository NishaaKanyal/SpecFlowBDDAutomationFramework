using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public class PageObjectModelStepDefinitions
    {
        private IWebDriver driver;
        SearchPage searchPage;
        ResultsPage resultsPage;
        ChannelPage channelPage;

        public PageObjectModelStepDefinitions(IWebDriver driver) 
        {
            this.driver = driver;
            
        }

        [Given(@"Enter the youtube URL")]
        public void GivenEnterTheYoutubeURL()
        {
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(3000);
        }

        [When(@"Search for testers talk in youtube")]
        public void WhenSearchForTestersTalkInYoutube()
        {
            searchPage = new SearchPage(driver);
            resultsPage = searchPage.searchText("testers talk");
            Thread.Sleep(3000);
        }

        [When(@"Navigate to the channel")]
        public void WhenNavigateToTheChannel()
        {
            channelPage= resultsPage.clickOnChannel();
            Thread.Sleep(3000);
        }

        [Then(@"Verify the title of the page")]
        public void ThenVerifyTheTitleOfThePage()
        {
            Assert.AreEqual("Testers Talk - YouTube", channelPage.getTitle());
        }

    }
}
