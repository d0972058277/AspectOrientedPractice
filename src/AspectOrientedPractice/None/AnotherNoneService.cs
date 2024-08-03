namespace AspectOrientedPractice.None;

public class AnotherNoneService : INoneService
{
    public Task Execute(NoneInput input)
    {
        return Task.CompletedTask;
    }
}