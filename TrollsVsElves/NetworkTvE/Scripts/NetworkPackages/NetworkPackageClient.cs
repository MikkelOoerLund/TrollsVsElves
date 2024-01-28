using MessagePack;
using System.Net;
using System.Threading.Tasks;

namespace NetworkTvE.Scripts
{
    public class NetworkPackageClient
    {
        private UdpClientWrapper _udpClientWrapper;

        public NetworkPackageClient(UdpClientWrapper udpClientWrapper)
        {
            _udpClientWrapper = udpClientWrapper;
        }

        public void SendNetworkPackage(NetworkPackage networkPackage)
        {
            var bytes = MessagePackSerializer.Serialize<NetworkPackage>(networkPackage);
            _udpClientWrapper.Send(bytes);
        }

        public NetworkPackage RecieveNetworkPackage()
        {
            var bytes = _udpClientWrapper.Recieve();
            return MessagePackSerializer.Deserialize<NetworkPackage>(bytes);
        }

        public async Task SendNetworkPackageAsync(NetworkPackage networkPackage)
        {
            var bytes = MessagePackSerializer.Serialize<NetworkPackage>(networkPackage);
            await _udpClientWrapper.SendAsync(bytes);
        }

        public async Task SendNetworkPackageAsync(NetworkPackage networkPackage, IPEndPoint remoteEndPoint)
        {
            var bytes = MessagePackSerializer.Serialize<NetworkPackage>(networkPackage);
            await _udpClientWrapper.SendAsync(bytes, remoteEndPoint);
        }



        public async Task<NetworkPackage> ReceiveNetworkPackageAsync()
        {
            var result = await _udpClientWrapper.RecieveAsync();
            var networkPackage = MessagePackSerializer.Deserialize<NetworkPackage>(result.Buffer);
            networkPackage.RemoteEndPoint = result.RemoteEndPoint;
            return networkPackage;
        }

    }
}
