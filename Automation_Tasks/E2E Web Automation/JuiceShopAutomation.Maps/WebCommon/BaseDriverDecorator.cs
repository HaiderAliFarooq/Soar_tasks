using OpenQA.Selenium;
using JuiceShopAutomation.Maps.Interface;

namespace JuiceShopAutomation.Maps.WebCommon;

public abstract class BaseDriverDecorator : IDriverCreator
{
    private IDriverCreator DriverCreator { get; }

    protected BaseDriverDecorator(IDriverCreator driverCreator)
    {
        DriverCreator = driverCreator;
    }

    public virtual IWebDriver CreateDriver()
    {
        IWebDriver webDriver = DriverCreator.CreateDriver();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
        return webDriver;
    }
}
