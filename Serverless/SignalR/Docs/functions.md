# Azure Functions CLI

`func --help`

`func init --docker`

`func start`

`func azure functionapp publish my-signalr-functions`

## Azure functions v3 & Docker

- https://dev.to/azure/develop-azure-functions-using-net-core-3-0-gcm
- https://hub.docker.com/_/microsoft-azure-functions-dotnet
- https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-function-linux-custom-image?tabs=portal%2Cbash&pivots=programming-language-csharp
- https://codetraveler.io/2020/02/12/visual-studio-for-mac-updating-to-azure-functions-v3/

### Azure functions & pipelines

- https://www.hanselman.com/blog/SettingUpAzureDevOpsCICDForANETCore31WebAppHostedInAzureAppServiceForLinux.aspx


                  %%%%%%
                 %%%%%%
            @   %%%%%%    @
          @@   %%%%%%      @@
       @@@    %%%%%%%%%%%    @@@
     @@      %%%%%%%%%%        @@
       @@         %%%%       @@
         @@      %%%       @@
           @@    %%      @@
                %%
                %

### REST playground

`https://my-signalr-functions.azurewebsites.net/`

GET https://my-signalr-functions.azurewebsites.net/api/HttpGetTrigger

POST https://my-signalr-functions.azurewebsites.net/api/hubs/broadcast/negotiate

POST https://my-signalr-functions.azurewebsites.net/api/HttpPostTrigger

    {
        "_t": "MyToDo",
        "Title": "Do something 3",
        "IsCompleted": false
    }

PUT https://my-signalr-functions.azurewebsites.net/api/todo/44bca6da-126e-4168-b000-a5c145ba81db

content-type: application/json

    {
        "Title": "Buy food",
        "IsCompleted": true
    }
