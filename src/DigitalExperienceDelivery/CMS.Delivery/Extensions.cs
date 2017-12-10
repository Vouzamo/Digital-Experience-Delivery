using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CMS.Delivery
{
    public static class Extensions
    {
        public static T Data<T>(this IHasData subject)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(subject.Data, settings);
        }

        public static T Data<T>(this IHasData subject, IRendering rendering) where T : IComponentModel
        {
            var model = subject.Data<T>();

            model.Rendering = rendering;

            return model;
        }
    }
}
