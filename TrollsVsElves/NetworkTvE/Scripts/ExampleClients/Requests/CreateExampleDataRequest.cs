using MediatR;
using MessagePack;

namespace NetworkTvE.Scripts.ExampleClients
{

    [MessagePackObject]
    public class CreateExampleDataRequest : IRequest<CreateExampleDataResponse>
    {
        [Key(0)] public string Message { get; set; }
    }
}
