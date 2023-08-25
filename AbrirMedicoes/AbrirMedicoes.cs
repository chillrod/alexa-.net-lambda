using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AbrirMedicoes.Intents;
using Alexa.NET.Request;
using Alexa.NET.Response;


namespace AbrirMedicoes
{
    public static class AbrirMedicoes
    {
        [FunctionName("Alexa")]
        public static async Task<IActionResult> Run(
[HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
ILogger log)
        {
            string json = await req.ReadAsStringAsync();
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json);

            var requestType = skillRequest.GetRequestType();

            SkillResponse response = null;


            response = Requests.Launch.AbrirInventário(requestType, response);

            response = await Medicoes.CarregarFeed(skillRequest, requestType, response);

            return new OkObjectResult(response);
        }
    }
}

