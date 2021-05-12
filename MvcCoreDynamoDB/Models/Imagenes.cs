using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Models
{
    public class Imagenes
    {
        [DynamoDBProperty("imagenes")]
        public String url { get; set; }
    }
}
