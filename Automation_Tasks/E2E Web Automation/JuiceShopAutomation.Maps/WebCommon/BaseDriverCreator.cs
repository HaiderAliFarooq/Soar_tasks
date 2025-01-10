using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using JuiceShopAutomation.Maps.Interface;

namespace JuiceShopAutomation.Maps.WebCommon;

public abstract class BaseDriverCreator : IDriverCreator
{
    protected virtual string GetVersionResolveStrategy => "MatchingBrowser";

    protected Platform Platform { get; }

    protected string DownloadDirectoryPath { get; }

    protected BaseDriverCreator()
    {
        Enum.TryParse<PlatformType>("windows", out var result);
        Platform = new Platform(result);
    }

    public IWebDriver CreateDriver()
    {
        DriverOptions driverOptions = CreateDriverOptions();

        IWebDriver webDriver2;
        webDriver2 = CreateDriver(driverOptions);

        if (webDriver2 is IAllowsFileDetection allowsFileDetection)
        {
            allowsFileDetection.FileDetector = new LocalFileDetector();
        }

        return webDriver2;
    }

    protected abstract DriverOptions CreateDriverOptions();

    protected abstract IWebDriver CreateDriver(DriverOptions options);
}
