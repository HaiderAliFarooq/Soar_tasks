using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using JuiceShopAutomation.Maps.Interface;
using JuiceShopAutomation.Maps.Common;

namespace JuiceShopAutomation.Maps;

public class RetryLocator : IControlLocator
{
    private readonly IWebDriver _driver;

    public RetryLocator(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool ElementDoesExist(By by, int numberOfRetries = 30)
    {
        GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2.0);
        bool result = true;
        for (int i = 0; i < numberOfRetries; i++)
        {
            result = true;
            if (HandleElementRetrieval(by) != null)
            {
                break;
            }

            result = false;
            Thread.Sleep(1000);
        }

        GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
        return result;
    }

    public void ElementDoesntExist(By by, int defaultTime = 60)
    {
        try
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
            new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(defaultTime)).Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
        }
        catch (Exception)
        {
            throw new Exception($"ElementDoesntExist method thrown an exception. The provided element is either visible or prent present on the UI. Locator: {by}");
        }
    }

    public void TextToBePresentInElement(By by, string text, int defaultTime = 60)
    {
        try
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
            new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(defaultTime)).Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
        }
        catch (Exception)
        {
            throw new Exception($"WaitForElementText method thrown an exception. The provided text is not visible or prent present in the provided selector. Locator: {by}");
        }
    }

    public IWebElement FindElement(By by)
    {
        bool flag = true;
        IWebElement webElement = null;
        for (int i = 0; i < 6; i++)
        {
            flag = true;
            webElement = HandleElementRetrieval(by);
            if (webElement != null)
            {
                break;
            }

            flag = false;
            Thread.Sleep(1000);
        }

        if (!flag)
        {
            throw new Exception($"Could not find Web element on page by {by}");
        }

        return webElement;
    }

    public List<IWebElement> FindElements(By by)
    {
        bool flag = true;
        List<IWebElement> list = null;
        for (int i = 0; i < 3; i++)
        {
            flag = true;
            list = HandleElementsRetrieval(by);
            if (list != null)
            {
                break;
            }

            flag = false;
            Thread.Sleep(1000);
        }

        if (!flag)
        {
            throw new Exception($"Could not find collection of Web elements on page by {by}");
        }

        return list;
    }

    public IWebDriver GetDriver()
    {
        return _driver;
    }

    public IJavaScriptExecutor GetJsExecutor()
    {
        return (IJavaScriptExecutor)_driver;
    }

    public void NavigateToUrl(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public Actions GetAction()
    {
        return new Actions(_driver);
    }

    private IWebElement HandleElementRetrieval(By by)
    {
        IWebElement result = null;
        try
        {
            result = _driver.FindElement(by);
        }
        catch (Exception ex)
        {
            
        }

        return result;
    }

    private List<IWebElement> HandleElementsRetrieval(By by)
    {
        List<IWebElement> result = null;
        try
        {
            result = new List<IWebElement>(_driver.FindElements(by));
        }
        catch (Exception ex)
        {
        }

        return result;
    }
}