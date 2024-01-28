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
}
