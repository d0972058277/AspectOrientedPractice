using AspectOrientedPractice.None;
using Moq;

namespace AspectOrientedPractice.Test;

public class NoneServiceTest(IEnumerable<INoneService> sut, Mock<ITestLogger> logger)
{
    [Fact]
    public async Task Execute_ShouldDoNothing()
    {
        var tasks = sut.Select(x => x.Execute(new NoneInput()));
        await Task.WhenAll(tasks);

        logger.Verify(x => x.Log("Before"), Times.Once);
        logger.Verify(x => x.Log("After"), Times.Once);
    }
}