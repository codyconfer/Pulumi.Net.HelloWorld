using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HelloWorld
{
    public static class HelloWorldFunctions
    {
        [FunctionName(nameof(SayHelloWorld))]
        public static IActionResult SayHelloWorld(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log) => new OkObjectResult($"Hello, World");
    }
}
