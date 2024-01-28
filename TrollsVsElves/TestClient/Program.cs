



using NetworkTvE.Scripts;
using NetworkTvE.Scripts.ExampleClients;
using System.Diagnostics;
using System.Net;

namespace TestClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var udpClient = new UdpClientWrapper();
            var networkClient = new NetworkPackageClient(udpClient);

            udpClient.Connect(IPAddress.Loopback.ToString(), 12000);

            var networkPackage = new NetworkPackage()
            {
                Type = NetworkPackageType.CreateExampleDataRequest,
            };

            await networkClient.SendNetworkPackageAsync(networkPackage);


            var response = await networkClient.ReceiveNetworkPackageAsync();
        }
    }
}