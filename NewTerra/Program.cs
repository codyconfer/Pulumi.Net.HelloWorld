using System.Threading.Tasks;
using NewTerra.ConfigurationFactories;
using Pulumi;
using Pulumi.Azure.AppService;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

namespace NewTerra
{
    internal class Program
    {
        internal static Task<int> Main()
        {
            return Deployment.RunAsync(() =>
            {
                // Names, Prefixes
                const string appServicePlanName = "devnorthcentralus";
                const string resourceGroupName = "rg-Pulumi-HelloWorld-";
                const string functionStorageAccountName = "hwpDocStore";
                const string functionAppPrefix = "f9-pulumi-helloWorld-";

                // Resource Group
                var resourceGroup = new ResourceGroup(resourceGroupName);

                // Storage Account
                var storageAccountSettings = StorageAccountConfigurationFactory.CreateDefaultConfiguration();
                storageAccountSettings.Name = resourceGroup.Name;

                var functionStorageAccount = new Account(functionStorageAccountName, storageAccountSettings);

                // App Service Plan
                var planSettings = FunctionAppConfigurationFactory.CreateDefaultPlanConfiguration();
                planSettings.ResourceGroupName = resourceGroup.Name;

                var appServicePlan = new Plan(appServicePlanName, planSettings);

                // Function Apps
                var functionAppSettings = FunctionAppConfigurationFactory.CreateDefaultConfiguration();
                functionAppSettings.ResourceGroupName = resourceGroup.Name;
                functionAppSettings.AppServicePlanId = appServicePlan.Id;
                functionAppSettings.StorageConnectionString = functionStorageAccount.PrimaryConnectionString;

                var helloWorld = new FunctionApp($"{functionAppPrefix}HelloWorld", functionAppSettings);
                var helloCosmosDb = new FunctionApp($"{functionAppPrefix}HelloCosmosDb", functionAppSettings);
            });
        }
    }
}
