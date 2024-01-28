using MessagePack;
using System.Net;

namespace NetworkTvE.Scripts
{
    [MessagePackObject]
    public class NetworkPackage
    {
        [Key(0)] public NetworkPackageType Type { get; set; }
        [Key(1)] public string Message { get; set; }
        [Key(2)] public byte[] Data { get; set; }


        [IgnoreMember] public IPEndPoint RemoteEndPoint { get; set; }

        public T GetData<T>()
        {
            return MessagePackSerializer.Deserialize<T>(Data);
        }

        public void ConsumeData<T>(T data)
        {
            Data = MessagePackSerializer.Serialize<T>(data);
        }
    }
}
