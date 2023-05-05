using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectDemo.Driver;
using SpecFlowProjectDemo.Utility;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo.Hooks
{
    [Binding]
    public class HookInitialization: ExtentReport
    {
        private readonly IObjectContainer _container;
        public static Startup startup;
        IWebDriver driver;
        //static readonly string PATH = "\\SpecFlow_BDD_Training\\Configuration\\";
        static readonly string configSettingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Configuration\\ConfigSettings.json");


        public HookInitialization(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run");
            ExtentReportInit();
        }

        [BeforeScenario]
        public void BeforeTestRun1()
        {
            try
            {
                startup = new Startup();
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(configSettingPath);
                IConfiguration configuration = builder.Build();
                configuration.Bind(startup);
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Failed_To_Initialize_Configuration={e.Message}");
            }
            }

            [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            ExtentReportTearDown();
        }

      
        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            BeforeTestRun1();
            //string browserValue = startup.BrowserType.ToString();
           // SelectBrowserInHeadlessMode(browserValue);
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            Thread.Sleep(1000);
        }
    

        [BeforeScenario("@GoogleSearch")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("First step running in the Specflow file");

        }
         

        [AfterScenario]
        public void AfterScenario()
        {
           var driver =  _container.Resolve<IWebDriver>();
            if(driver != null) //if driver is opened, only than you need to close it
            {
                driver.Quit();
            }
        }

        public void SelectBrowserInHeadlessMode(string browserType)
        {
                switch (browserType)
                {
                    case "Chrome":


                    IWebDriver driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                }
        }
            

                        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();

            // When all our scenarios is passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            // When our scenarios do not work as we want them to//fail
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }

        
     

        }
}