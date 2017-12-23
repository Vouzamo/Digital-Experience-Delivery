using System.IO;
using System.Web;
using DD4T.ContentModel.Contracts.Resolvers;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Resolvers
{
    public class PublicationResolver : IPublicationResolver
    {
        public int ResolvePublicationId()
        {
            var httpContext = HttpContext.Current;

            Context context = null;

            if (httpContext.Items.Contains("Context"))
            {
                context = (Context)httpContext.Items["Context"];
            }

            if (context == null)
            {
                using (var reader = new StreamReader(httpContext.Request.InputStream))
                {
                    var json = reader.ReadToEnd();

                    context = JsonConvert.DeserializeObject<Context>(json);
                }

                httpContext.Items["Context"] = context;
            }

            var cultureCode = $"{context?.LanguageCode.ToLowerInvariant()}-{context?.CountryCode.ToUpperInvariant()}";

            switch (cultureCode)
            {
                case "en-ES":
                    return 25;
                case "en-FR":
                    return 23;
                case "en-GB":
                    return 21;
                case "en-IT":
                    return 22;
                case "en-US":
                    return 26;
                case "es-ES":
                    return 29;
                case "es-US":
                    return 30;
                case "fr-FR":
                    return 28;
                case "it-IT":
                    return 27;
                default:
                    return 21; // Use en-GB as the default
            }
        }
    }
}