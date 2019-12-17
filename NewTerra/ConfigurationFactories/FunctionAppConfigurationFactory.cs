using System.Collections.Generic;
using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;

namespace NewTerra.ConfigurationFactories
{
    public static class FunctionAppConfigurationFactory
    {
        public static PlanArgs CreateDefaultPlanConfiguration() =>
            new PlanArgs
            {
                Kind = "FunctionApp",
                Location = "northcentralus",
                Sku = new PlanSkuArgs
                {
                    Size = "Y1",
                    Tier = "Dynamic",
                },
            };

        public static FunctionAppArgs CreateDefaultConfiguration() =>
            new FunctionAppArgs
            {
                AppSettings = new Dictionary<string, string>
                {
                    { "setting1", "value1" }
                },
                Version = "3",
                ClientAffinityEnabled = false,
                EnableBuiltinLogging = true,
                Enabled = true,
            };
    }
}