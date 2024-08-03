namespace AspectOrientedPractice.HelloWorld;

public class HelloWorldService : IHelloWorldService
{
    [LogInterceptor]
    public Task<string> Execute(HelloWorldInput input)
    {
        return Task.FromResult(input.Value);
    }
}