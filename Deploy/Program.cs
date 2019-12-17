using System.Threading.Tasks;
using HelloWorld.Deploy.ConfigurationFactories;
using Pulumi;
using Pulumi.Azure.AppService;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

namespace HelloWorld.Deploy
{
    class Program
    {
        static Task<int> Main()
        {
            return Deployment.RunAsync(() =>
            {
                // Define Names, Prefixes, and Ids
                const string appServicePlanName = "devnorthcentralus";
                const string resourceGroupName = "rg-PulumiHelloWorld";
                const string functionStorageAccountName = "hwpDocStore";
                const string functionAppPrefix = "f9-pulumi-helloWorld-";

                // Provision Resource Group
                var resourceGroup = new ResourceGroup(resourceGroupName);

                // Provision Storage Account
                var storageAccountSettings =
                    StorageAccountConfigurationFactory.CreateDefaultConfiguration()
                        .DefineResourceGroup(resourceGroup);

                var functionStorageAccount = new Account(functionStorageAccountName, storageAccountSettings);

                // Provision Function Apps
                var planSettings = FunctionAppConfigurationFactory.CreateDefaultPlanConfiguration()
                    .DefineResourceGroup(resourceGroup);

                var appServicePlan = new Plan(appServicePlanName, planSettings);

                var functionAppSettings =
                    FunctionAppConfigurationFactory.CreateDefaultConfiguration()
                        .DefineResourceGroup(resourceGroup)
                        .DefineAppServicePlanId(appServicePlan)
                        .AddStorageConnectionString(functionStorageAccount);

                var helloWorld = new FunctionApp($"{functionAppPrefix}HelloWorld", functionAppSettings);
                var helloCosmosDb = new FunctionApp($"{functionAppPrefix}HelloCosmosDb", functionAppSettings);
            });
        }
    }
}
