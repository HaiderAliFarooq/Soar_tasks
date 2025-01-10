using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace JuiceShopAutomation.Maps.WebCommon;

public class ChromeDriverCreator : BaseDriverCreator
{
    protected override DriverOptions CreateDriverOptions()
    {
        ChromeOptions chromeOptions = new();
        chromeOptions.AddArgument("no-sandbox");
        chromeOptions.AddArgument("--ignore-ssl-errors=yes");
        chromeOptions.AddArgument("--ignore-certificate-errors");
        chromeOptions.AddUserProfilePreference("download.default_directory", base.DownloadDirectoryPath);
        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
        chromeOptions.AddUserProfilePreference("enable-webgl-draft-extensions", true);
        chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
        chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        return chromeOptions;
    }

    protected override IWebDriver CreateDriver(DriverOptions options)
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), GetVersionResolveStrategy);
        return new ChromeDriver(Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Chrome") ?? "", "*").SelectMany((string path) => Directory.EnumerateDirectories(path, "*")).FirstOrDefault(), options as ChromeOptions, TimeSpan.FromMinutes(3.0));
    }
}
