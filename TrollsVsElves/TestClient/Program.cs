



using NetworkTvE.Scripts;
using NetworkTvE.Scripts.ExampleClients;
using System.Diagnostics;
using System.Net;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new UdpClientWrapper();

            client.Connect(IPAddress.Loopback.ToString(), 12000);


            var networkClient = new NetworkPackageClient(client);
            var exampleClient = new ExampleClient(networkClient);

            var createRequest = new CreateExampleDataRequest { Message = "Hegne" };
            exampleClient.CreateExampleData(createRequest);


            var response = networkClient.RecieveNetworkPackage();


            Console.WriteLine(response.Type);

            Console.ReadLine();
        }
    }
}