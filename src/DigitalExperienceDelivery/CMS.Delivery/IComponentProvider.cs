using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace CMS.Delivery
{
    public interface IComponentProvider
    {
        bool TryGetComponent(Guid id, IContext context, out IComponent component);
    }

    public class DefaultComponent : IComponent
    {
        public Guid Id { get; set; }

        [JsonProperty("data")]
        public JRaw Json { get; set; }

        [JsonIgnore]
        public string Data => Json.Value<string>();
    }

    public class DefaultComponentProvider : IComponentProvider
    {
        protected IHostingEnvironment HostingEnvironment { get; set; }

        public DefaultComponentProvider(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public bool TryGetComponent(Guid id, IContext context, out IComponent component)
        {
            try
            {
                var jsonPath = HostingEnvironment.WebRootPath + "/data/components/" + id.ToString() + ".json";

                var json = System.IO.File.ReadAllText(jsonPath);

                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                component = JsonConvert.DeserializeObject<DefaultComponent>(json, settings);

                return true;
            }
            catch(Exception ex)
            {
                component = null;
                return false;
            }
        }
    }
}
