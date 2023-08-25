using System;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System.Threading.Tasks;

namespace AbrirMedicoes.Requests
{
    public class Launch
    {
        public static SkillResponse AbrirInventário(Type requestType, SkillResponse response)
        {
            if (requestType == typeof(LaunchRequest))
            {
                response = ResponseBuilder.Tell("Bem vindo ao inventário Inflor");
                response.Response.ShouldEndSession = false;
            }


            return response;
        }
    }
}

