using System;
using System.Collections.Generic;
using System.Linq;
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
                var locations = new List<string> { "northcentralus", "eastus" };
                foreach (var location in locations)
                {
                    // Names, Prefixes
                    var appServicePlanName = $"dev{location}";
                    var resourceGroupName = $"rg-Pulumi-{location}";
                    var functionStorageAccountName = $"f9store{location.Substring(0, 4)}";
                    var functionAppPrefix = $"f9-pulumi-{location}-";

                    // Resource Group
                    var resourceGroup = new ResourceGroup(resourceGroupName, new ResourceGroupArgs { Location = location });

                    // Storage Account
                    var storageAccountSettings = StorageAccountConfigurationFactory.CreateDefaultConfiguration();
                    storageAccountSettings.ResourceGroupName = resourceGroup.Name;
                    storageAccountSettings.Location = location;

                    var functionStorageAccount = new Account(functionStorageAccountName, storageAccountSettings);

                    // App Service Plan
                    var planSettings = FunctionAppConfigurationFactory.DefaultPlanConfiguration;
                    planSettings.ResourceGroupName = resourceGroup.Name;
                    planSettings.Location = location;

                    var appServicePlan = new Plan(appServicePlanName, planSettings);

                    // Function Apps
                    var functionAppSettings = FunctionAppConfigurationFactory.DefaultConfiguration;
                    functionAppSettings.ResourceGroupName = resourceGroup.Name;
                    functionAppSettings.AppServicePlanId = appServicePlan.Id;
                    functionAppSettings.StorageConnectionString = functionStorageAccount.PrimaryConnectionString;
                    functionAppSettings.Location = location;

                    var sayHelloWorld = new FunctionApp($"{functionAppPrefix}SayHello", functionAppSettings.AddAppSetting(("ReturnMessage", "Hello, World!")));
                }
                
            });
        }
    }
}
