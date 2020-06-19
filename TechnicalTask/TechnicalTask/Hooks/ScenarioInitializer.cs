using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using TechnicalTask.Constants;
using TechnicalTask.Pages;
using TechnicalTask.Steps;
using TechTalk.SpecFlow;

namespace TechnicalTask.Hooks
{
    [Binding]
    class ScenarioInitializer : BaseSteps
    {
        public ScenarioInitializer(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        { }

        [BeforeScenario(Order = 0)]
        public void GetDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--enable-javascript");
            options.AddArgument("--disable-notifications");
            options.AddUserProfilePreference(LoginConstants.UserName, LoginConstants.Password);

            var driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(LoginConstants.HomePage);

            this.featureContext.Add(ContextConstants.Driver, driver);
            this.SetPage<LoginPage>();
        }

        [BeforeScenario(Order = 1)]
        public void Authenticate()
        {
            this.Wait.Until(ExpectedConditions.AlertIsPresent());
            this.Driver.SwitchTo().Alert().SetAuthenticationCredentials(LoginConstants.Password, LoginConstants.Password);
        }

        [AfterScenario()]
        public void KillDriver()
        {
            this.Driver.Close();
        }
    }
}
