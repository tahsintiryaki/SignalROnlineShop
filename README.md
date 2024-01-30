This solution has 2 project. SignalRServer.API and SignalRClient.MVC. I managed SignalR hub in SignalRServer.API project. 
Firstly I send request to signalR hub for getting signalR connectionId from MVC project. 
Secondly I send request to GetGamesMethod with connectionId in API project. I created request with ajax.
After that, when the UpdateGame method is triggered in the API project, SignalRHub(ChangeGame) is triggered and products are automatically updated in client projects that listen to SignulRHub.
