using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Models
{
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("idUsers")]
        public string idUsers { get; set; }

        [DynamoDBProperty("name")]
        public string name { get; set; }

        [DynamoDBProperty("Fape")]
        public string Fape { get; set; }

        [DynamoDBProperty("Sape")]
        public string Sape { get; set; }

        [DynamoDBProperty("imagenes")]
        public Imagenes imagen { get; set; }
    }
}
