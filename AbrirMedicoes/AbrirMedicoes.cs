using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AbrirMedicoes.Commands.Intents;
using AbrirMedicoes.Commands.Requests;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Request.Type;

namespace AlexaSkill
{
    public static class AlexaSkill
    {
        [FunctionName("Alexa")]
        public static async Task<IActionResult> Run(
[HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            string json = await req.ReadAsStringAsync();
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json);

            var requestType = skillRequest.GetRequestType();

            SkillResponse response = null;

            try
            {
                response = AbrirMedicoes.Services.Auth.Auth.IdentificarUsuario(response);

                response = Launch.AbrirInventário(requestType, response);

                if (requestType == typeof(IntentRequest))
                {
                    response = await Medicoes.CarregarFeed(skillRequest, response);

                }

            }
            catch
            {
                response.Response.ShouldEndSession = true;

            }


            return new OkObjectResult(response);
        }
    }
}

