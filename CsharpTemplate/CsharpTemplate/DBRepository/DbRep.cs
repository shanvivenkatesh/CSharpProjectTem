using CsharpTemplate.Framework.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CsharpTemplate.DBRepository
{
    public class DbRep : IDbRep
    {
        private IDbConnection _dbConnection;
        private readonly string _connectionString;



        public DbRep(EnvironmentConfiguration envconfig)
        {
            _connectionString = envconfig.ConnectionString;
        }



        public List<string> GetRoutedFundProviderForgivenClient(string clientCode)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return _dbConnection.Query<string>("SELECT c.Name FROM OPENJSON((SELECT ClientData FROM orders.Clients WHERE ISjson(ClientData) > 0 and JSON_VALUE(ClientData, '$.Code') = @clientCode), '$.DistributorNetworkRoutes') AS a JOIN(SELECT JSON_VALUE(ClientData, '$.Code') AS Code, JSON_VALUE(ClientData, '$.Name') AS Name FROM orders.Clients WHERE ISJSON(ClientData) > 0) AS c ON a.value = c.Code", new { clientCode }).ToList();
            }
        }



        public string GetFundProviderExistForGivenClient(string clientCode, string name)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return _dbConnection.Query<string>("SELECT Name FROM OPENJSON((SELECT ClientData FROM orders.Clients WHERE ISjson(ClientData) > 0 and JSON_VALUE(ClientData, '$.Code') = @clientCode),'$.DistributorNetworkRoutes') AS a JOIN(SELECT JSON_VALUE(ClientData, '$.Code') AS Code, JSON_VALUE(ClientData, '$.Name') AS Name FROM orders.Clients WHERE ISJSON(ClientData) > 0) AS c ON a.value = c.Code and c.name =@name", new { clientCode, name }).First();
            }
        }
    }
}
