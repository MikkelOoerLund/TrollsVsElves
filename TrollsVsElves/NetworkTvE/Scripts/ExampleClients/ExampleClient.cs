using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTvE.Scripts.ExampleClients
{


    public class ExampleClient
    {
        private NetworkPackage _networkPackage;
        private NetworkPackageClient _networkClient;

        public ExampleClient(NetworkPackageClient networkClient)
        {
            _networkPackage = new NetworkPackage();
            _networkClient = networkClient;
        }

        public void CreateExampleData(CreateExampleDataRequest createExampleDataRequest)
        {
            _networkPackage.Type = NetworkPackageType.CreateExampleDataRequest;
            _networkPackage.ConsumeData(createExampleDataRequest);
            _networkClient.SendNetworkPackage(_networkPackage);
        }
    }
}
