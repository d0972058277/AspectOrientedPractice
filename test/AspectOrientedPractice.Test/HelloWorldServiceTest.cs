using AspectOrientedPractice.HelloWorld;
using FluentAssertions;
using Moq;

namespace AspectOrientedPractice.Test;

public class HelloWorldServiceTest(IHelloWorldService sut, Mock<ITestLogger> logger)
{
    [Fact]
    public async Task Execute_ShouldReturnHelloWorld()
    {
        var result = await sut.Execute(new HelloWorldInput("Hello World"));

        result.Should().Be("Hello World");
        logger.Verify(x => x.Log("Before"), Times.Once);
        logger.Verify(x => x.Log("After"), Times.Once);
    }
}