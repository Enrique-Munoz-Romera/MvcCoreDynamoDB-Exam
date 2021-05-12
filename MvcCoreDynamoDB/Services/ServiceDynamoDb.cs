using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MvcCoreDynamoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Services
{
    public class ServiceDynamoDb
    {
        private DynamoDBContext context;

        public ServiceDynamoDb()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            this.context = new DynamoDBContext(client);
        }

        public async Task<List<User>> GetUsers()
        {
            var tabla = this.context.GetTargetTable<User>();
            var scanOptions = new ScanOperationConfig();

            var results = tabla.Scan(scanOptions);

            List<Document> data = await results.GetNextSetAsync();

            IEnumerable<User> users =
                this.context.FromDocuments<User>(data);
            return users.ToList();
        }

        public async Task<User> GetUser(string idUsers)
        {
            return await this.context.LoadAsync<User>(idUsers);
        }

        public async Task CreateUser(User usuario)
        {
            await this.context.SaveAsync<User>(usuario);
        }

        public async Task UpdateUser(User usuario)
        {
            string idUsers = usuario.idUsers;
            User user = await this.GetUser(idUsers);
            user.idUsers = usuario.idUsers;
            user.name = usuario.name;
            user.Fape = usuario.Fape;
            user.Sape = usuario.Sape;
            await this.context.SaveAsync<User>(user);
        }

        public async Task DeleteUser(string idUsers)
        {
            await this.context.DeleteAsync<User>(idUsers);
        }
    }
}
