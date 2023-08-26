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
		public static void Responder(Types.IAlexaResponse response)
        {
			ResponseBuilder.Tell(response.Text);
        }
		
	}
}

