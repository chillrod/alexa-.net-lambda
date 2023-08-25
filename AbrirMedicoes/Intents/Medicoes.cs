using System;
using System.Threading.Tasks;
using Alexa.NET.Request.Type;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using System.Collections.Generic;
using Microsoft.SyndicationFeed.Rss;
using System.Xml;
using System.Linq;
using System.Net.Http;

namespace AbrirMedicoes.Intents
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


        public static async Task<SkillResponse> CarregarFeed(SkillRequest skillRequest, Type requestType, SkillResponse response)
        {
          
            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;

                if (intentRequest.Intent.Name == "Medicoes")
                {



                    string rss = "https://rss.app/feeds/MlQou76wkj50rPqJ.xml";
                    List<string> news = await ParseFeed(rss);

                    string output = $"O nome desse canal é {news.FirstOrDefault()}";

                    response = ResponseBuilder.Tell(output);
                }
            }


            return response;
        }

        private static async Task<List<string>> ParseFeed(string url)
        {
            List<string> news = new List<string>();
            using (var xmlReader = XmlReader.Create(url, new XmlReaderSettings { Async = true }))
            {
                RssFeedReader feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == Microsoft.SyndicationFeed.SyndicationElementType.Image)
                    {
                        var item = await feedReader.ReadImage();
                        news.Add(item.Title);
                    }
                }
            }

            return news;
        }
    }
}

