using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Interface;

public interface IControlLocator
{
    IWebDriver GetDriver();

    IJavaScriptExecutor GetJsExecutor();

    IWebElement FindElement(By by);

    List<IWebElement> FindElements(By by);

    bool ElementDoesExist(By by, int numberOfRetries = 30);

    void ElementDoesntExist(By by, int waitTime = 60);

    void NavigateToUrl(string url);

    Actions GetAction();

    void TextToBePresentInElement(By locator, string text, int defaultTime = 60);
}
