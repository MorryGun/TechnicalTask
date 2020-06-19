using OpenQA.Selenium;
using System.Collections.Generic;
using TechnicalTask.Constants;
using TechnicalTask.Interfaces;

namespace TechnicalTask.Pages
{
    public class LoginPage : IPage
    {
        public Dictionary<string, By> Elements { get; } = new Dictionary<string, By>
        {
            { ElementsNamesConstants.UserNameField, By.Name("username") },
            { ElementsNamesConstants.PasswordField, By.Name("password")},
            { ElementsNamesConstants.LoginButton, By.CssSelector(".content-wrapper-blue_link green")}
        };
    }
}
