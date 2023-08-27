using System;
using Alexa.NET;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

namespace AbrirMedicoes.Commands.Requests
{
    public class Launch
    {
        public static SkillResponse AbrirInventário(Type requestType, SkillResponse response)
        {
            if (requestType == typeof(LaunchRequest))
            {
                response = ResponseBuilder.Tell("Bem vindo ao inventário Inflor");
            }


            return response;
        }
    }
}

