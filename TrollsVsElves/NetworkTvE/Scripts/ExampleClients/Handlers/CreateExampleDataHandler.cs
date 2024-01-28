using System.Threading.Tasks;
using System.Threading;
using System;
using MediatR;

namespace NetworkTvE.Scripts.ExampleClients
{
    public class CreateExampleDataHandler : IRequestHandler<CreateExampleDataRequest, CreateExampleDataResponse>
    {
        public async Task<CreateExampleDataResponse> Handle(CreateExampleDataRequest request, CancellationToken cancellationToken)
        {
            return new CreateExampleDataResponse()
            {
                Message = request.Message,
            };
        }
    }
}
