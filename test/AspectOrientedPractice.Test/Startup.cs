using AspectCore.Extensions.DependencyInjection;
using AspectOrientedPractice.HelloWorld;
using AspectOrientedPractice.None;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace AspectOrientedPractice.Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<Mock<ITestLogger>>(_ => new Mock<ITestLogger>());
        services.AddScoped<ITestLogger>(sp => sp.GetRequiredService<Mock<ITestLogger>>().Object);

        // 被代理的類別必須要有 interface
        services.AddTransient<IHelloWorldService, HelloWorldService>();
        services.AddTransient<INoneService, NoneService>();
        services.AddTransient<INoneService, AnotherNoneService>();

        services.AddSingleton<LogInterceptorAttribute>();
    }

    public void ConfigureHost(IHostBuilder hostBuilder)
    {
        // 使用 DynamicProxyServiceProviderFactory 取代 DefaultServiceProviderFactory 以便支持 AspectCore 的 Proxy 機制
        hostBuilder.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());
    }
}