using OpenQA.Selenium;
using JuiceShopAutomation.Maps.Interface;

namespace JuiceShopAutomation.Maps.WebCommon;

public class WindowsDriverDecorator : BaseDriverDecorator
{
    public WindowsDriverDecorator(IDriverCreator driverCreator)
        : base(driverCreator)
    {
    }

    public override IWebDriver CreateDriver()
    {
        IWebDriver webDriver = base.CreateDriver();
        webDriver.Manage().Window.Maximize();
        return webDriver;
    }
}
