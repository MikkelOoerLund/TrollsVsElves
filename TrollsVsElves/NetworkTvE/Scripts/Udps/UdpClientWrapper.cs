using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTvE.Scripts
{
    public class UdpClientWrapper : IDisposable
    {
        private UdpClient _udpClient;
        private IPEndPoint _remoteIpEndPoint;

        public UdpClientWrapper()
        {
            _udpClient = new UdpClient();
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public UdpClientWrapper(int port)
        {
            _udpClient = new UdpClient(port);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);
        }


        public void Connect(string ipAddress, int port)
        {
            _udpClient.Connect(ipAddress, port);
        }

        public void Send(byte[] bytes)
        {
            _udpClient.Send(bytes, bytes.Length);
        }

        public async Task SendAsync(byte[] bytes)
        {
            await _udpClient.SendAsync(bytes, bytes.Length);
        }


        public async Task SendAsync(byte[] bytes, IPEndPoint remoteEndPoint)
        {
            await _udpClient.SendAsync(bytes, bytes.Length, remoteEndPoint);
        }


        public byte[] Recieve()
        {
            return _udpClient.Receive(ref _remoteIpEndPoint);
        }

        public async Task<UdpReceiveResult> RecieveAsync()
        {
            return await _udpClient.ReceiveAsync();
        }

        public void Dispose()
        {
            _udpClient.Dispose();
        }
    }
}
