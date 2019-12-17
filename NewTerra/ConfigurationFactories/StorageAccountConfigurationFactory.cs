using Pulumi.Azure.Storage;

namespace HelloWorld.Deploy.ConfigurationFactories
{
    public static class StorageAccountConfigurationFactory
    {
        public static AccountArgs CreateDefaultConfiguration() =>
            new AccountArgs
            {
                AccountReplicationType = "LRS",
                AccountTier = "Standard",
            };
    }
}
