using Pulumi.Azure.Storage;

namespace NewTerra.ConfigurationFactories
{
    public static class StorageAccountConfigurationFactory
    {
        public static AccountArgs CreateDefaultStorageConfiguration() =>
            new AccountArgs
            {
                AccountReplicationType = "LRS",
                AccountTier = "Standard",
            };
    }
}
