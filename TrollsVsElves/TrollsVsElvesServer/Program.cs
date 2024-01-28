



using NetworkTvE.Scripts;
using NetworkTvE.Scripts.ExampleClients;
using System.Diagnostics;
using System.Net;

namespace TrollsVsElvesServer
{

    class Program
    {
        public static async Task Main(string[] args)
        {
            var udpListener = new UdpClientWrapper(12000);
            var networkListener = new NetworkPackageClient(udpListener);

            while (true)
            {
                var networkPackage = await networkListener.ReceiveNetworkPackageAsync();
                var remoteEndPoint = networkPackage.RemoteEndPoint;

                if (networkPackage.Type == NetworkPackageType.CreateExampleDataRequest)
                {
                    var response = new NetworkPackage()
                    {
                        Type = NetworkPackageType.CreateExampleDataResponse,
                    };

                    await networkListener.SendNetworkPackageAsync(response, remoteEndPoint);
                }

            }
        }



        private static void Sync()
        {
            //var listener = new UdpListenerWrapper(12000);
            //var networkListener = new NetworkPackageListener(listener);

            //var (request, fromEndPoint) = networkListener.RecieveNetworkPackage();

            //if (request.Type == NetworkPackageType.CreateExampleDataRequest)
            //{
            //    var createResponse = new CreateExampleDataResponse { Message = "Response" };

            //    var response = new NetworkPackage()
            //    {
            //        Type = NetworkPackageType.CreateExampleDataResponse,
            //    };

            //    response.ConsumeData(createResponse);

            //    networkListener.SendNetworkPackage(response, fromEndPoint);
            //}
        }
    }
}