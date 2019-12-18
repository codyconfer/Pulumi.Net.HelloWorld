# Pulumi.Net.HelloWorld

> A hello world level pulumi solution: Deploying Azure Function Apps with .NET core.

## Getting Started

> How to provision the function app environment in your own azure subscription.

### Dependencies

> Ensure the following dependencies are installed

- [Install Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
- [Install Pulumi](https://www.pulumi.com/docs/get-started/install/)
- [Visual Studio Code  Install](https://code.visualstudio.com/)
- [VSCode C# Language Support](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

> Ensure the following accounts have been created

- [Getting Started with Azure](https://azure.microsoft.com/en-us/get-started/)
- [Get Started With Pulumi in Azure](https://www.pulumi.com/docs/get-started/azure/configure/)

### Project Structure

- ./NewTerra contains the Pulumi app that provisions function app resources
- ./FunctionApps/Say contains the example app to test deployments

### Deploying

1. First use Azure CLI to log into the target azure subscription.

```powershell
az login
```

2. The output from this command lists active subscriptions. Select an extension with Azure CLI.

```powershell
az account set -s {subscriptionId}
```

3. Start Pulumi Provisioning

```powershell
pulumi up
```

4. Deploy Function App via Visual Studio Code.
   - `Ctrl + P` in VsCode
   - Select command "Azure Functions: Deploy to Function App"
   - Select the newly provisioned Function App.

## Azure Resources

- [Getting Started with Azure](https://azure.microsoft.com/en-us/get-started/)
- [Install Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

## Pulumi Resources

- [Install Pulumi](https://www.pulumi.com/docs/get-started/install/)
- [Get Started With Pulumi in Azure](https://www.pulumi.com/docs/get-started/azure/)
- [.NET Core Landing Page](https://www.pulumi.com/docs/intro/languages/dotnet/)
- [Node.js Landing Page](https://www.pulumi.com/docs/intro/languages/javascript/)
- [Python Landing Page](https://www.pulumi.com/docs/intro/languages/python/)

## Azure Function App Resources

- [Azure Function App Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)
- [Azure Function App Open Source Repo](https://github.com/Azure/Azure-Functions)
- [Jeff Hollan's Blog](https://dev.to/jeffhollan)

## Visual Studio Code Resources

- [VSCode Install](https://code.visualstudio.com/)
- [Azure Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-azureextensionpack)
- [C# Language Support](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
- [.NET Core Tools](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet)
  