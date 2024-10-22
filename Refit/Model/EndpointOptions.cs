namespace RefitExample.Model;

public class EndpointOptions
{
    public string BaseAddress { get; set; } = string.Empty;
    public TimeSpan TimeOut { get; set; } = TimeSpan.Zero;
}
