using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Say
{
    public static class SayFunctions
    {
        public const string ReturnMessageAppSettingKey = "ReturnMessage";

        [FunctionName(nameof(Say))]
        public static Task<IActionResult> Say(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log) => Task.FromResult(
                new OkObjectResult(Environment.GetEnvironmentVariable(ReturnMessageAppSettingKey)) as IActionResult
            );
                
    }
}
