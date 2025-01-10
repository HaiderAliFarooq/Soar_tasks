using Autofac;
using JuiceShopAutomation.Maps;
using JuiceShopAutomation.Maps.Interface;
using JuiceShopAutomation.Maps.Runner;
using JuiceShopAutomation.Maps.WebCommon;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner;

public class AppFixture
{
    public required IContainer Container { get; set; }

    public required ITestOutputHelper TestOutputHelper { get; set; }

    public virtual void Build()
    {
        Container = ConfigureContainerBuilder()
            .Build();
    }

    public virtual ContainerBuilder ConfigureContainerBuilder()
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(TestOutputHelper).SingleInstance();
        builder.RegisterType<ChromeDriverCreator>().Named<IDriverCreator>("chrome");
        builder.Register(context =>
        {
            var result = context.ResolveNamed<IDriverCreator>("chrome");
            return new WindowsDriverDecorator(result);
        }).As<IDriverCreator>().SingleInstance();

        builder.Register(context => context.Resolve<IDriverCreator>().CreateDriver()).As<IWebDriver>().SingleInstance();
        builder.RegisterType<RetryLocator>().As<IControlLocator>().InstancePerLifetimeScope();
        builder.RegisterType<RetryWrapper>().As<IPageActionWrapper>().InstancePerLifetimeScope();
        builder.RegisterType<PageFactory>().InstancePerLifetimeScope();

        return builder;
    }
}
