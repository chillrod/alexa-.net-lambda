using Alexa.NET;

namespace AbrirMedicoes.Types
{
	public class IAlexaResponse
	{
		public string Text { get; set; }
	}

}


namespace AbrirMedicoes.Commands
{

	public class AlexaResponse {

		public static Alexa.NET.Response.SkillResponse Responder(Types.IAlexaResponse response)
        {
			return ResponseBuilder.Tell(response.Text);
        }
		
	}
}

