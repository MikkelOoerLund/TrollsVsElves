using MessagePack;
using System.Net;

namespace NetworkTvE.Scripts
{
    public class NetworkPackageListener
    {
        private UdpListenerWrapper _udpListenerWrapper;

        public NetworkPackageListener(UdpListenerWrapper udpListenerWrapper)
        {
            _udpListenerWrapper = udpListenerWrapper;
        }

        public void SendNetworkPackage(NetworkPackage networkPackage, IPEndPoint endPoint)
        {
            var bytes = MessagePackSerializer.Serialize<NetworkPackage>(networkPackage);
            _udpListenerWrapper.Send(bytes, endPoint);
        }

        public (NetworkPackage, IPEndPoint) RecieveNetworkPackage()
        {
            var (bytes, remoteEndPoint) = _udpListenerWrapper.Recieve();
            var networkPackage = MessagePackSerializer.Deserialize<NetworkPackage>(bytes);
            return (networkPackage, remoteEndPoint);
        }
    }


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
    }
}
