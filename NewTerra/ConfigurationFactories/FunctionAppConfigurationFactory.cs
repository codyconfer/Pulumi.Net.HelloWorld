using System;
using System.Collections.Generic;
using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;

namespace NewTerra.ConfigurationFactories
{
    public static class FunctionAppConfigurationFactory
    {
        public static PlanArgs DefaultPlanConfiguration =>
            new PlanArgs
            {
                Kind = "FunctionApp",
                Sku = new PlanSkuArgs
                {
                    Size = "Y1",
                    Tier = "Dynamic",
                },
            };

        public static FunctionAppArgs DefaultConfiguration =>
            new FunctionAppArgs
            {
                Version = GetVersionString(3),
                ClientAffinityEnabled = false,
                EnableBuiltinLogging = true,
                Enabled = true,
            };

        public static string GetVersionString(int versionNumber) =>
            versionNumber switch
            {
                1 => "~1",
                2 => "~2",
                3 => "~3",
                _ => throw new NotSupportedException("Function App Versions are 1, 2 or 3")
            };
    }
}