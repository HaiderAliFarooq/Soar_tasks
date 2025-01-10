using Autofac;
using JuiceShopAutomation.Maps;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner;

public abstract class TestBase : IDisposable
{
    protected PageFactory PageFactory { get; set; }

    protected IContainer Container { get; set; }

    protected TestBase(AppFixture fixture, ITestOutputHelper testOutputHelper)
    {
        fixture.TestOutputHelper = testOutputHelper;
        fixture.Build();
        Container = fixture.Container;
        PageFactory = Container.Resolve<PageFactory>();
    }

    public virtual void Dispose()
    {
        IWebDriver? driver = null;
        try
        {
            GC.SuppressFinalize(this);
            driver = Container.Resolve<IWebDriver>();
            driver.Close();
            driver.Quit();
        }
        finally
        {
            driver?.Quit();
        }
    }
}
