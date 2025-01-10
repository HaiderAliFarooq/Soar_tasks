using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Interface;

public interface IPageActionWrapper
{
    void Click(IWebElement element);

    void EnterText(IWebElement element, string value, bool clearText = false);

    void DropdownSelect(IWebElement element, string option, string selectBy = "text");

    void CheckboxSelect(IWebElement element, string markAsChecked);

    string GetText(IWebElement element, string expectedValue = "#skip");

    string GetAttributeValue(IWebElement element, string attributeName, string expectedValue = "#skip");

    string GetPropertyValue(IWebElement element, string propertyName, string expectedValue = "#skip");

    string GetCssValue(IWebElement element, string cssValue, string expectedValue = "#skip");

    bool GetState(IWebElement element, string state);

    void MouseHover(IWebElement element);

    void HoverAndClick(IWebElement element, string option, string selectBy = "text");

    void ClosePopup();
}
