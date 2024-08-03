namespace AspectOrientedPractice.HelloWorld;

public interface IHelloWorldService
{
    Task<string> Execute(HelloWorldInput input);
}