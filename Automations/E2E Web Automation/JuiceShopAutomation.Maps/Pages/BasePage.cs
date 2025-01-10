using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Interface;
using JuiceShopAutomation.Maps.WebCommon;

namespace JuiceShopAutomation.Maps.Pages;

public abstract class BasePage
{
    private readonly WebDriverWait wait;

    protected IControlLocator Locator { get; }

    protected IPageActionWrapper Wrapper { get; }

    protected BasePage(IControlLocator locator, IPageActionWrapper wrapper)
    {
        Locator = locator;
        Wrapper = wrapper;
        wait = new WebDriverWait(Locator.GetDriver(), TimeSpan.FromSeconds(30));
        PageFactoryHelper.InitElements(locator.GetDriver(), this);
    }

    public IWebDriver GetWebDriver()
    {
        return Locator.GetDriver();
    }

    public void ScrollIntoView(By by, bool alignToTop = false)
    {
        Locator.GetJsExecutor().ExecuteScript($"arguments[0].scrollIntoView({alignToTop.ToString().ToLower()})", Locator.FindElement(by));
    }

    public void ScrollToElement(By by)
    {
        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)GetWebDriver();
        javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", Locator.FindElement(by));
    }

    public void WaitUntilDocumentIsReady()
    {
        try
        {
            WaitUntil(() => !Locator.GetJsExecutor().ExecuteScript("return document.readyState").Equals("complete"), exceptionMessage: "Document is not ready");
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void SelectRandomValueFromDropdown(By dropdownLocator)
    {
        var dropdownElement = Locator.FindElement(dropdownLocator);
        var selectElement = new SelectElement(dropdownElement);
        var options = selectElement.Options;

        if (options.Count > 0)
        {
            var random = new Random();
            int randomIndex = random.Next(0, options.Count);
            selectElement.SelectByIndex(randomIndex);
        }
        else
        {
            throw new InvalidOperationException("The dropdown has no options to select.");
        }
    }


    public void ClickAfterWaitingForElementToBeClickable(By by)
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by)).Click();
    }

    public int GetCountOfElements(By by)
    {
        return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by)).Count;
    }

    public bool ElementExists(By by, int timeOut = 60)
    {
        try
        {
            var wait = new WebDriverWait(Locator.GetDriver(), TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    protected void WaitForElementToBeInvisible(By elementToWait)
    {
        try
        {
            var wait = new WebDriverWait(Locator.GetDriver(), TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementToWait));
        }
        catch (Exception e)
        {
            throw;
        }
    }

    protected void ExplicitWaitByVisibility(By elementToWait)
    {
        try
        {
            var wait = new WebDriverWait(Locator.GetDriver(), TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(elementToWait));
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void WaitUntil(Func<bool> condition, int timeoutInSeconds = 60, string exceptionMessage = "Timeout exceeded.", int retryRateDelay = 300)
    {
        var start = DateTime.Now;
        while (condition())
        {
            var now = DateTime.Now;
            var totalSeconds = (now - start).TotalSeconds;
            if (totalSeconds >= timeoutInSeconds)
            {
                throw new TimeoutException(exceptionMessage);
            }

            Thread.Sleep(retryRateDelay);
        }
    }
}
