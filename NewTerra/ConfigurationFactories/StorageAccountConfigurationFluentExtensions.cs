using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

namespace HelloWorld.Deploy.ConfigurationFactories
{
    public static class StorageAccountConfigurationFluentExtensions
    {
        public static AccountArgs DefineResourceGroup(this AccountArgs storageAccountArgs, ResourceGroup resourceGroup)
        {
            storageAccountArgs.ResourceGroupName = resourceGroup.Name;
            return storageAccountArgs;
        }
    }
}
