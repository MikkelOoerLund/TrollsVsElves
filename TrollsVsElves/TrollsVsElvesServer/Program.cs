



using NetworkTvE.Scripts;
using System.Diagnostics;

namespace TrollsVsElvesServer
{

    class Program
    {
        public static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("Initializing...");


            var udpListener = new UdpClientWrapper(12000);
            var networkListener = new NetworkPackageClient(udpListener);

            await Console.Out.WriteLineAsync("Listening...");

            while (true)
            {
                var request = await networkListener.ReceiveNetworkPackageAsync();
                var remoteEndPoint = request.RemoteEndPoint;

                await Console.Out.WriteLineAsync($"Request: {request.Type}");

                if (request.Type == NetworkPackageType.CreateExampleDataRequest)
                {
                    var response = new NetworkPackage()
                    {
                        Type = NetworkPackageType.CreateExampleDataResponse,
                    };


                    await Console.Out.WriteLineAsync($"Response: {response.Type}");
                    await networkListener.SendNetworkPackageAsync(response, remoteEndPoint);
                }

            }
        }
    }
}