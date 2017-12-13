using CMS.Delivery.Providers;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using CMS.Delivery.Models;

namespace CMS.Delivery
{
    public interface IComponentProvider : IProvider
    {
        bool TryGetComponent(Guid id, IContext context, out IComponent component);
    }

    public class DefaultContent : IContent
    {
        public Guid Id { get; set; }

        [JsonProperty("data")]
        public JRaw Json { get; set; }

        [JsonIgnore]
        public string Data => Json.Value<string>();
    }

    public class DefaultContentProvider : IContentProvider
    {
        public Guid Id => new Guid("5196b1ff-2c12-4833-bb79-a47c3a5e09cc");

        protected IHostingEnvironment HostingEnvironment { get; set; }

        public DefaultContentProvider(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public IContent GetContentById(Guid id, IContext context)
        {
            var jsonPath = HostingEnvironment.WebRootPath + "/data/components/" + id.ToString() + ".json";

            var json = System.IO.File.ReadAllText(jsonPath);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<DefaultContent>(json, settings);
        }
    }
}
