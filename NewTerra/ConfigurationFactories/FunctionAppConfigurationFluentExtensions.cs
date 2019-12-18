using System.Collections.Generic;
using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

namespace NewTerra.ConfigurationFactories
{
    public static class FunctionAppConfigurationFluentExtensions
    {
        public static FunctionAppArgs AddAppSetting(this FunctionAppArgs functionAppArgs, (string name, string value) setting)
        {
            functionAppArgs.AppSettings.Add(setting.name, setting.value); 
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
    }
}
