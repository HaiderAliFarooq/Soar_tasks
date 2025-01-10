using AppAutomation_Exercise.Support.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;

namespace AppAutomation_Exercise.Support
{
    public class ElementLocators
    {
        private readonly AndroidDriver _driver;
        public ElementLocators(AndroidDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ClickOnMainTasb(MainScreenTabs tab) => _driver.FindElement(By.XPath($"(//android.widget.ImageView[@resource-id='org.wikipedia.alpha:id/icon'])[{(int)tab}]"));

        public void ClickOnSearchBar()
        {
            _driver.FindElement(By.XPath("//android.view.View[@resource-id=\"org.wikipedia.alpha:id/fragment_feed_header\"]")).Click();
        }

        public void EnterSearchValue(string value)
        {
            _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id=\"org.wikipedia.alpha:id/search_src_text\"]")).SendKeys(value);
        }

        public void ScrollDown(int count = 20)
        {
            _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollToEnd({count});"));
        }

        public void ScrollUp(int count = 60)
        {
            _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollToBeginning({count});"));
        }

        public void ClickOnCloseButtonTwice()
        {
            var doubleClickElement = _driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"Clear query\"]"));
            DoubleClickOnElement(doubleClickElement);
        }

        public int SearchResultCount()
        {
            return _driver.FindElements(By.XPath("(//android.widget.LinearLayout[@resource-id=\"org.wikipedia.alpha:id/page_list_item_container\"])")).Count;
        }

        public void ClickOnMoreOptions()
        {
            _driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"More options\"]")).Click();
        }

        public void ClickOnSettingsMenu()
        {
            _driver.FindElement(By.XPath("//android.widget.TextView[@resource-id=\"org.wikipedia.alpha:id/explore_overflow_settings\"]")).Click();
        }

        public void ClickOnAllTogglesInSettings()
        {
            var toggles = _driver.FindElements(By.XPath("(//android.widget.Switch[@resource-id=\"org.wikipedia.alpha:id/switchWidget\"])"));
            foreach (var toggle in toggles)
            {
                toggle.Click();
            }
        }

        public void ClickOnBackButton()
        {
            _driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc=\"Navigate up\"]")).Click();
        }

        private void DoubleClickOnElement(IWebElement element)
        {
            Actions action = new(_driver);
            action.MoveToElement(element)
                  .Click()
                  .Pause(TimeSpan.FromMilliseconds(300))
                  .Click()
                  .Perform();
        }
    }
}
