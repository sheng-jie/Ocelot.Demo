# Precondition
1. Install consul.

# How to run
1. Clone code to your local computer.
2. Execute command `consul agent -dev -config-dir=consul.d` under the `Ocelot.Demo\Ocelot.ApiGateways` folder. After that visist the [http://localhost:8500/ui](http://localhost:8500/ui) to go to consul dashboard.
3. Start `Ocelot.Identity.Api`(6003), `Ocelot.ApiGateways`(60000), `Ocelot.Catalog.Api`(6002) and `Ocelot.Basket.Api`(6001) with `dotnet run` command.
4. Use postman to post a request with the following parameters to `localhost:6003/connect/token` to get bearer token. 
```
client_id:client
client_secret:secret
grant_type:client_credentials
```
5. Use postman to visist the `localhost:60000/index` with the token for testing Ocelot request aggregate.
```
Authorization:Bearer {token}
```
6. Use postman to send a request to `localhost:60000/admin/configuration` for getting or modifying ocelot configuration at runtime.
(First of all, you must get bearer token with `client_id:ocelot.admin,client_secret:secret` and then use the token to send request. Just reference step 4, step 5.)

For more detail visis ：
1. [.NET Core + Ocelot + IdentityServer4 + Consul 基础架构实现](https://www.cnblogs.com/Zhang-Xiang/p/10437488.html).
2. [APIGatewayDemo][https://github.com/catcherwong-archive/APIGatewayDemo]

