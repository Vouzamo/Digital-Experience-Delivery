using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace CMS.Delivery
{
    public interface ICompositionResolver
    {
        bool TryResolveCompositionId(string uri, IContext context, out Guid id);
    }

    public interface ICompositionProvider
    {
        bool TryGetComposition(Guid id, IContext context, out IComposition composition);
    }

    public class DefaultTemplate : ITemplate
    {
        public Guid Id { get; set; }

        [JsonProperty("data")]
        public JRaw Json { get; set; }

        [JsonIgnore]
        public string Data => Json.Value<string>();
    }

    public class DefaultRendering : IRendering
    {
        public Guid ComponentId { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<DefaultTemplate>))]
        public ITemplate Template { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<List<DefaultRendering>>))]
        public IEnumerable<IRendering> Renderings { get; set; }
    }

    public class DefaultComposition : IComposition
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<DefaultTemplate>))]
        public ITemplate Template { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<List<DefaultRendering>>))]
        public IEnumerable<IRendering> Renderings { get; set; }
    }

    public class DefaultCompositionProviderResolver : ICompositionProvider, ICompositionResolver
    {
        protected IHostingEnvironment HostingEnvironment { get; }

        public DefaultCompositionProviderResolver(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public bool TryGetComposition(Guid id, IContext context, out IComposition composition)
        {
            try
            {
                var jsonPath = HostingEnvironment.WebRootPath + "/data/composition/" + id + ".json";

                var json = System.IO.File.ReadAllText(jsonPath);

                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                composition = JsonConvert.DeserializeObject<DefaultComposition>(json, settings);

                return true;
            }
            catch(Exception ex)
            {
                composition = null;
                return false;
            }
        }

        public bool TryResolveCompositionId(string uri, IContext context, out Guid id)
        {
            id = new Guid("5df00cba-91a3-4c57-8304-7def935c6c9e");

            return true;
        }
    }
}
