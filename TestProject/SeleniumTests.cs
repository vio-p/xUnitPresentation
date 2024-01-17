using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TestProject
{
    // Custom TestCaseOrderer specified for test method ordering
    [TestCaseOrderer(
        ordererTypeName: "TestProject.PriorityOrderer",
        ordererAssemblyName: "TestProject")]
    public class SeleniumTests : IDisposable
    {
        private readonly IWebDriver _driver;

        // Constructor sets up the ChromeDriver with specific configurations
        public SeleniumTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

        }

        // Test for verifying correct title is displayed when navigating to the home page
        [Fact]
        [TestPriority(0)]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://mateinfo.unitbv.ro/ro/");
            Assert.Equal("Acasă - Facultatea de Matematică și informatică", _driver.Title);
        }

        // Test for verifying correct page is opened when navigating to the educational plan
        [Fact]
        [Trait("Category", "SeleniumTest")]
        [TestPriority(1)]
        //[RetryFact(MaxRetries = 3)]
        public void CorrectPageOpened_When_NavigateToEducationalPlan()
        {
            // Navigation steps to the educational plan page
            _driver.Navigate().GoToUrl("https://mateinfo.unitbv.ro/ro/");

            Thread.Sleep(3000);
            IWebElement acceptCookiesButton = _driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/button[3]"));
            acceptCookiesButton.Click();

            Thread.Sleep(1000);
            IWebElement studyProgramsAnchor = _driver.FindElement(By.XPath("//*[@id=\"item_161\"]/div[1]/a"));
            studyProgramsAnchor.Click();

            Thread.Sleep(1000);
            IWebElement bachelorDetailsAnchor = _driver.FindElement(By.XPath("//*[@id=\"item_88\"]/div/a"));
            bachelorDetailsAnchor.Click();

            Thread.Sleep(1000);
            IReadOnlyCollection<IWebElement> accordionElements = _driver.FindElements(By.CssSelector("#accordion334 > div > div.accordion-heading > a"));
            accordionElements.ElementAt(0).Click();

            Thread.Sleep(1000);
            accordionElements.ElementAt(2).Click();

            Thread.Sleep(1000);
            IWebElement plan2021to2024Anchor = _driver.FindElement(By.XPath("//*[@id=\"collapse_334_296\"]/div/p[9]/a"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", plan2021to2024Anchor);
            plan2021to2024Anchor.Click();

            // Assertion to check if the URL matches the expected value
            Assert.Equal("https://mateinfo.unitbv.ro/images/2023/planuri_inv/PI_IA_20211-2024.pdf", _driver.Url);
        }

        // Dispose method to quit the WebDriver after test execution
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}