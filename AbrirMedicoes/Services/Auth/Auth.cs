using System;
using System.IdentityModel.Tokens.Jwt;
using AbrirMedicoes.Commands;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace AbrirMedicoes.Services.Auth
{
	public class Auth
	{
        public static SkillResponse IdentificarUsuario(SkillResponse response)
        {
            try
            {

            var requestSession = new Session();

            string requestToken = requestSession.User.AccessToken;

            var token = new JwtSecurityToken(jwtEncodedString: requestToken);

            var name = token.Claims.GetType().Name;
            Types.IAlexaResponse res = new()

            {
                Text = $"Hello {name}"
            };

            AlexaResponse.Responder(res);

            return response;

            } catch
            {
                throw new Exception("Token inválído");
            }
        }
    }
}

