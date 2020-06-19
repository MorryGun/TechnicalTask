using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using TechnicalTask.Constants;
using TechnicalTask.Interfaces;
using TechnicalTask.Pages;
using TechTalk.SpecFlow;

namespace TechnicalTask.Steps
{
    [Binding]
    public class BaseSteps
    {
        protected readonly FeatureContext featureContext;
        protected readonly ScenarioContext scenarioContext;

        public BaseSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        protected IPage CurrentPage => this.featureContext.Get<IPage>(ContextConstants.CurrentPage);
        protected IWebDriver Driver => this.featureContext.Get<IWebDriver>(ContextConstants.Driver);
        protected WebDriverWait Wait => new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
        protected Dictionary<string, By> SideBar { get; } = new Dictionary<string, By>
        {
            { ElementsNamesConstants.ProviderButton, By.CssSelector(".router-link-exact-active router-link-active") }
        };

        [Given(@"the user logged into the system")]
        public void GivenTheUserLoggedIntoTheSystem()
        {
            this.Wait.Until(ExpectedConditions.ElementToBeClickable(this.CurrentPage.Elements[ElementsNamesConstants.UserNameField]));

            var usernameField = this.GetElement(ElementsNamesConstants.UserNameField);
            usernameField.Click();
            usernameField.SendKeys(LoginConstants.UserName);

            var passwordField = this.GetElement(ElementsNamesConstants.PasswordField);
            passwordField.Click();
            passwordField.SendKeys(LoginConstants.Password);

            this.GetElement(ElementsNamesConstants.LoginButton).Click();
        }

        [Given(@"the user navigated to the Provider Creation form")]
        public void GivenTheUserNavigatedToTheProviderCreationForm()
        {
            this.Wait.Until(ExpectedConditions.ElementToBeClickable(this.CurrentPage.Elements[ElementsNamesConstants.ProviderButton]));
            this.GetElement(ElementsNamesConstants.ProviderButton).Click();
            this.SetPage<ProviderCreatorPage>();
        }

        protected IWebElement GetElement(string elementName)
        {
            try
            {
                return this.Driver.FindElement(this.CurrentPage.Elements[elementName]);
            }
            catch (InvalidOperationException)
            {
                throw new Exception($"No {elementName} on current Page");
            }
        }

        protected void SetPage<T>() where T : IPage, new()
        {
            this.featureContext.Remove(ContextConstants.CurrentPage);
            this.featureContext.Add(ContextConstants.CurrentPage, Activator.CreateInstance<T>());
        }

        protected void SelectDropDownValue(string dropdownName, string value)
        {
            var select = new SelectElement(this.GetElement(dropdownName));
            select.SelectByValue(value);
        }
    }
}
