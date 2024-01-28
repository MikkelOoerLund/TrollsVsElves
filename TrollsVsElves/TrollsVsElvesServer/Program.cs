



using NetworkTvE.Scripts;
using NetworkTvE.Scripts.ExampleClients;
using System.Diagnostics;
using System.Net;

namespace TrollsVsElvesServer
{

    class Program
    {
        public static void Main(string[] args)
        {
            var listener = new UdpListenerWrapper(12000);
            var networkListener = new NetworkPackageListener(listener);

            var (request, fromEndPoint) = networkListener.RecieveNetworkPackage();

            if (request.Type == NetworkPackageType.CreateExampleDataRequest)
            {
                var createResponse = new CreateExampleDataResponse { Message = "Response" };

                var response = new NetworkPackage()
                {
                    Type = NetworkPackageType.CreateExampleDataResponse,
                };

                response.ConsumeData(createResponse);

                networkListener.SendNetworkPackage(response, fromEndPoint);
            }



        }
    }
}