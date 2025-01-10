using AppAutomation_Exercise.Support;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AppAutomation_Exercise.Tests
{
    public class MobileAutomation_Task3 : SupportHelper
    {
        private ElementLocators _locators = null!;

        [SetUp]
        public void SetupDriver()
        {
            _locators = new ElementLocators(Driver);
        }

        [Test]
        public void MobileAutomation_Task3_Test()
        {
            _locators.ClickOnMoreOptions();
            _locators.ClickOnSettingsMenu();

            _locators.ClickOnAllTogglesInSettings();
            _locators.ClickOnBackButton();
        }
    }
}
