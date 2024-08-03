namespace AspectOrientedPractice.None;

public class NoneService : INoneService
{
    [LogInterceptor]
    public Task Execute(NoneInput input)
    {
        return Task.CompletedTask;
    }
}