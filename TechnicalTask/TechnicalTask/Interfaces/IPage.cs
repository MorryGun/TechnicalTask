using OpenQA.Selenium;
using System.Collections.Generic;

namespace TechnicalTask.Interfaces
{
    public interface IPage
    {
        public Dictionary<string, By> Elements { get; }
    }
}
