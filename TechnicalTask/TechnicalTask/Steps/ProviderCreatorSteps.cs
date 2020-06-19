using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace TechnicalTask.Steps
{
    [Binding]
    public class ProviderCreatorSteps : BaseSteps
    {
        public ProviderCreatorSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext)
        { }

        [Given(@"the user clicks on (Add License button|Medical license country drop-down)")]
        [When(@"the user picks (Medical School field)")]
        public void GivenTheUserClicksOnAddLicenseButton(string elementName)
        {
            this.GetElement(elementName).Click();
        }

        [When(@"the user picks (Austria) from (Medical license country drop-down)")]
        public void WhenTheUserPicksAustriaFromMedicalLicenseCountryDrop_Down(string value, string elementName)
        {
            this.SelectDropDownValue(elementName, value);
        }

        [Then(@"(Austria) is displayed on (Medical license country drop-down)")]
        public void ThenAustriaIsDisplayedOnMedicalLicenseCountryDrop_Down(string value, string elementName)
        {
            var select = new SelectElement(this.GetElement(elementName));

            Assert.IsTrue(select.SelectedOption.Text == value && select.SelectedOption.Displayed);
        }

        [Then(@"no country name is displayed on (Medical license country drop-down)")]
        public void ThenNoCountryNameIsDisplayedOnMedicalLicenseCountryDrop_Down(string elementName)
        {
            var select = new SelectElement(this.GetElement(elementName));

            Assert.IsTrue(select.SelectedOption.Text == string.Empty && select.SelectedOption.Displayed);
        }
    }
}
