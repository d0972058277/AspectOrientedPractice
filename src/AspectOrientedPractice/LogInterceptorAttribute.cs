using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace AspectOrientedPractice;

public class LogInterceptorAttribute : AbstractInterceptorAttribute
{
    public override async Task Invoke(AspectContext context, AspectDelegate next)
    {
        var logger = context.ServiceProvider.GetRequiredService<ITestLogger>();

        var className = context.ServiceMethod.DeclaringType?.Name;
        var methodName = context.ServiceMethod.Name;
        var parameterName = context.Parameters[0].GetType().Name;
        var parameterValue = context.Parameters[0];

        logger.Log("Before");
        await next(context);
        logger.Log("After");
    }
}