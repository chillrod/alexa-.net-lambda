using System;
using System.Threading.Tasks;
using Alexa.NET.Request.Type;
using Alexa.NET.Request;
using Alexa.NET.Response;
using System.Collections.Generic;
using System.Linq;

namespace AbrirMedicoes.Commands.Intents
{
    public class Weather
    {
        public DateTime date;
        public int temperatureC;
        public string summary;
        public int temperatureF;
    }

    public static class Medicoes
    {


        public static async Task<SkillResponse> CarregarFeed(SkillRequest skillRequest, SkillResponse response)
        {
          
            {
                var intentRequest = skillRequest.Request as IntentRequest;

                if (intentRequest.Intent.Name == "Medicoes")
                {
                    string rss = "https://rss.app/feeds/MlQou76wkj50rPqJ.xml";
                    List<string> news = await Utils.RSSFeedUtils.ParseFeed(rss);


                    Types.IAlexaResponse res = new()
                    {
                        Text = news.FirstOrDefault()
                    };


                    response = AlexaResponse.Responder(res);

                }
            }


            return response;
        }
    }
}

