using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;
using Pulumi.Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Pulumi.Azure.Storage;

namespace HelloWorld.Deploy.ConfigurationFactories
{
    public static class FunctionAppConfigurationFluentExtensions
    {
        public static PlanArgs DefineResourceGroup(this PlanArgs planArgs, ResourceGroup resourceGroup)
        {
            planArgs.ResourceGroupName = resourceGroup.Name;
            return planArgs;
        }

        public static FunctionAppArgs DefineAppServicePlanId(this FunctionAppArgs functionAppArgs, Plan appServicePlan)
        {
            functionAppArgs.AppServicePlanId = appServicePlan.Id;
            return functionAppArgs;
        }

        public static FunctionAppArgs DefineResourceGroup(this FunctionAppArgs functionAppArgs, ResourceGroup resourceGroup)
        {
            functionAppArgs.ResourceGroupName = resourceGroup.Name;
            return functionAppArgs;
        }

        public static FunctionAppArgs DefineStorageConnectionString(this FunctionAppArgs functionAppArgs, string storageConnectionString)
        {
            functionAppArgs.StorageConnectionString = storageConnectionString;
            return functionAppArgs;
        }

        public static FunctionAppArgs DefineAuthSettings(this FunctionAppArgs functionAppArgs, FunctionAppAuthSettingsArgs authSettings)
        {
            functionAppArgs.AuthSettings = authSettings;
            return functionAppArgs;
        }

        public static FunctionAppArgs DefineIdentity(this FunctionAppArgs functionAppArgs, FunctionAppIdentityArgs identity)
        {
            functionAppArgs.Identity = identity;
            return functionAppArgs;
        }

        public static FunctionAppArgs DefineSiteConfig(this FunctionAppArgs functionAppArgs, FunctionAppSiteConfigArgs siteConfig)
        {
            functionAppArgs.SiteConfig = siteConfig;
            return functionAppArgs;
        }

        public static FunctionAppArgs AddAppSettings(this FunctionAppArgs functionAppArgs, Dictionary<string, string> appSettings)
        {
            foreach (var setting in appSettings) 
                functionAppArgs.AppSettings.Add(setting.Key, setting.Value); 
            return functionAppArgs;
        }

        public static FunctionAppArgs AddConnectionStrings(this FunctionAppArgs functionAppArgs, List<FunctionAppConnectionStringsArgs> connectionStrings)
        {
            connectionStrings.ForEach(connectionString => functionAppArgs.ConnectionStrings.Add(connectionString));
            return functionAppArgs;
        }

        public static FunctionAppArgs AddStorageConnectionString(this FunctionAppArgs functionAppArgs, Account storageAccount)
        {
            functionAppArgs.StorageConnectionString = storageAccount.PrimaryConnectionString;
            return functionAppArgs;
        }
    }
}
