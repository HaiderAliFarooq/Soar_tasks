using AppAutomation_Exercise.Support;
using AppAutomation_Exercise.Support.Enums;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AppAutomation_Exercise.Tests
{
    public class MobileAutomation_Task1 : SupportHelper
    {
        private ElementLocators _locators = null!;

        [SetUp]
        public void SetupDriver()
        {
            _locators = new ElementLocators(Driver);
        }

        [Test]
        public void MobileAutomation_Task1_Test()
        {
           _locators.ScrollDown();
            _locators.ClickOnMainTasb(MainScreenTabs.MyLists).Click();
            Thread.Sleep(3000);
            _locators.ClickOnMainTasb(MainScreenTabs.History).Click();
            Thread.Sleep(3000);
            _locators.ClickOnMainTasb(MainScreenTabs.Location).Click();
            Thread.Sleep(3000);
            _locators.ClickOnMainTasb(MainScreenTabs.Explore).Click();
            _locators.ScrollUp();
        }
    }
}
