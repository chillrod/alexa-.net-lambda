using Microsoft.SyndicationFeed.Rss;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace AbrirMedicoes.Utils
{
	public class RSSFeedUtils
	{
            public static async Task<List<string>> ParseFeed(string url)
            {
                List<string> rssResponse = new();

                using (var xmlReader = XmlReader.Create(url, new XmlReaderSettings { Async = true }))

                {
                    RssFeedReader feedReader = new RssFeedReader(xmlReader);

                    while (await feedReader.Read())
                    {
                        if (feedReader.ElementType == Microsoft.SyndicationFeed.SyndicationElementType.Image)
                        {
                            var item = await feedReader.ReadImage();

                            rssResponse.Add(item.Title);
                        }
                    }
                }

                return rssResponse;
            }
        }
}

