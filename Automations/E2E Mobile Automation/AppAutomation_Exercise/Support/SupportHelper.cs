using AppAutomation_Exercise.Configurations;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace AppAutomation_Exercise.Support
{
    public class SupportHelper
    {
        protected AndroidDriver Driver { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            Driver = AppiumDriverSetup.InitializeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}
