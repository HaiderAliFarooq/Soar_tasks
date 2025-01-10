using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using Microsoft.Extensions.Configuration;

namespace AppAutomation_Exercise.Configurations
{
    /// <summary>
    /// Appium driver setup.
    /// </summary>
    public static class AppiumDriverSetup
    {
        /// <summary>
        /// Registring the app settings and getting the appttings section for getting the values.
        /// </summary>
        public static readonly IConfigurationSection configuration
            = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetSection("AppSettings");

        /// <summary>
        /// Initialize appium driver with device and apk setup.
        /// </summary>
        /// <returns>Appium driver.</returns>
        public static AndroidDriver InitializeDriver()
        {
            AndroidDriver _driver;
            var serverUri = new Uri("http://127.0.0.1:4723/");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = configuration["DeviceName"],
                App= Environment.CurrentDirectory + configuration["ApkName"]
            };

            //driverOptions.AddAdditionalAppiumOption("appPackage", "com.android.settings");
            //driverOptions.AddAdditionalAppiumOption("appActivity", ".Settings");
            // NoReset assumes the app com.google.android is preinstalled on the emulator
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(180);

            //var appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, configuration["PlatformName"]);
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, configuration["DeviceName"]);
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Environment.CurrentDirectory + configuration["ApkName"]);
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, configuration["AutomationName"]);
            //_driver = new AndroidDriver(new Uri("http://localhost:4723/"), driverOptions, TimeSpan.FromSeconds(180));
            return _driver;
            //return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/"), appiumOptions, TimeSpan.FromMinutes(10));
        }
    }
}
