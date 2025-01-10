using AppAutomation_Exercise.Support;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AppAutomation_Exercise.Tests
{
    public class MobileAutomation_Task2 : SupportHelper
    {
        private ElementLocators _locators = null!;

        [SetUp]
        public void SetupDriver()
        {
            _locators = new ElementLocators(Driver);
        }

        [Test]
        public void MobileAutomation_Task2_Test()
        {
            _locators.ClickOnSearchBar();
            _locators.EnterSearchValue("New York");

            Assert.That(_locators.SearchResultCount() > 0, "Search results are not returned");

            _locators.ClickOnCloseButtonTwice();
        }
    }
}
