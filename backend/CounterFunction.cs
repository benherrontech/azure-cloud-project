using System.Net;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace CounterFunction
{
    public class CounterFunction
    {

        [Function("IncrementVisitCount")]
        [CosmosDBOutput("ResumeDb", "Counter", Connection = "CosmosDBConnection")]
        public static async Task<VisitCounter>  IncrementVisitCount([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
         [CosmosDBInput(databaseName: "ResumeDb", containerName: "Counter", Connection = "CosmosDBConnection", Id = "1", PartitionKey = "1")] VisitCounter item)
        {
            // Increment visit count
            item.Count++;

            // Write new count to HTTP response
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(item);

            // Save updated item to CosmosDB
            return item;
        }
    }
}