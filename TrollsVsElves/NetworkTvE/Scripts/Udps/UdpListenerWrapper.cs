using System;
using System.Net;
using System.Net.Sockets;

namespace NetworkTvE.Scripts
{
    public class UdpListenerWrapper : IDisposable
    {
        private UdpClient _udpClient;
        private IPEndPoint _remoteIpEndPoint;

        public UdpListenerWrapper(int port)
        {
            _udpClient = new UdpClient(port);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public void Send(byte[] bytes, IPEndPoint ipEndPoint)
        {
            _udpClient.Send(bytes, bytes.Length, ipEndPoint);
        }

        public (byte[], IPEndPoint) Recieve()
        {
            var data = _udpClient.Receive(ref _remoteIpEndPoint);
            return (data, _remoteIpEndPoint);
        }


        public void Dispose()
        {
            _udpClient.Dispose();
        }
    }
}
