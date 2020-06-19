using OpenQA.Selenium;
using System.Collections.Generic;
using TechnicalTask.Constants;
using TechnicalTask.Interfaces;

namespace TechnicalTask.Pages
{
    public class ProviderCreatorPage : IPage
    {
        public Dictionary<string, By> Elements { get; } = new Dictionary<string, By>
        {
            { ElementsNamesConstants.AddLicenseButton, By.CssSelector("button[class*=medical-licencees-group]") },
            { ElementsNamesConstants.MedicalLicenseCountryDropDown, By.Id("__BVID__188") },
            { ElementsNamesConstants.MedicalSchoolField, By.Name("medicalSchool") }
        };
    }
}
