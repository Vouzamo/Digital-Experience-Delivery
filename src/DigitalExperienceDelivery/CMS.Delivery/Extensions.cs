using CMS.Delivery.Models;
using CMS.Delivery.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace CMS.Delivery
{
    public static class Extensions
    {
        public static bool TryGetLayout(this ILayoutProvider provider, IContext context, out ILayout layout)
        {
            layout = provider.GetLayout(context);

            return layout != null;
        }

        public static bool TryGetComposition(this ICompositionProvider provider, IContext context, out IComposition composition)
        {
            composition = provider.GetComposition(context);

            return composition != null;
        }

        public static bool TryGetContentById(this IContentProvider provider, Guid id, IContext context, out IContent content)
        {
            content = provider.GetContentById(id, context);

            return content != null;
        }

        public static T Data<T>(this IHasData subject)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(subject.Data, settings);
        }

        public static bool TryData<T>(this IHasData subject, out T data)
        {
            data = subject.Data<T>();

            return data != null;
        }

        public static T Data<T>(this IHasData subject, IEmbeddedRendering rendering) where T : IComponentModel
        {
            var model = subject.Data<T>();

            model.Rendering = rendering;

            return model;
        }
    }
}
