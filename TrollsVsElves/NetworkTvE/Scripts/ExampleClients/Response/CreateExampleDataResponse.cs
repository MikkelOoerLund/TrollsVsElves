using MessagePack;

namespace NetworkTvE.Scripts.ExampleClients
{
    [MessagePackObject]
    public class CreateExampleDataResponse
    {
        [Key(0)] public string Message { get; set; }
    }
}
