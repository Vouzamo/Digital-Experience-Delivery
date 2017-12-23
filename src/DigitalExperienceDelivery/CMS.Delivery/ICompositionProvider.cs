using CMS.Delivery.Providers;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using CMS.Delivery.Models;

namespace CMS.Delivery
{
    public interface ICompositionResolver : IProvider
    {
        bool TryResolveCompositionId(string uri, IContext context, out Guid id);
    }

    //public interface ICompositionProvider : IProvider
    //{
    //    bool TryGetComposition(Guid id, IContext context, out IComposition composition);
    //}

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

        public string Data { get; set; }
    }

    public class DefaultLayout : ILayout
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<DefaultTemplate>))]
        public ITemplate Template { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<List<DefaultRendering>>))]
        public IEnumerable<IRendering> Renderings { get; set; }
    }

    public class DefaultLayoutProvider : ILayoutProvider
    {
        protected IHostingEnvironment HostingEnvironment { get; set; }

        public DefaultLayoutProvider(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public ILayout GetLayoutById(Guid id, IContext context)
        {
            var jsonPath = HostingEnvironment.WebRootPath + "/data/composition/" + id + ".json";

            var json = System.IO.File.ReadAllText(jsonPath);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<DefaultLayout>(json, settings);
        }
    }

    public class DefaultCompositionResolver : ICompositionResolver
    {
        public Guid Id => new Guid("00804bcd-d975-4fb6-aeba-7e7745f33996");

        public bool TryResolveCompositionId(string uri, IContext context, out Guid id)
        {
            id = new Guid("5df00cba-91a3-4c57-8304-7def935c6c9e");

            return true;
        }
    }
}
