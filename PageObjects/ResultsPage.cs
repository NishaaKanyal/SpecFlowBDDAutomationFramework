using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.PageObjects
{
    public class ResultsPage
    {
        private IWebDriver driver;
        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By channelName = By.LinkText("Testers Talk");

        public ChannelPage clickOnChannel()
        {
            driver.FindElement(channelName).Click();
            return new ChannelPage(driver);
        }

    }
}
