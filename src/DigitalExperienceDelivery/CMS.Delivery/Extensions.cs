﻿using CMS.Delivery.Models;
using CMS.Delivery.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace CMS.Delivery
{
    public static class Extensions
    {
        public static bool TryGetLayoutById(this ILayoutProvider provider, Guid id, IContext context, out ILayout layout)
        {
            layout = provider.GetLayoutById(id, context);

            return layout != null;
        }

        public static bool TryGetCompositionById(this ICompositionProvider provider, Guid id, IContext context, out IComposition composition)
        {
            composition = provider.GetCompositionById(id, context);

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

        public static T Data<T>(this IHasData subject, IEmbeddedRendering rendering) where T : IComponentModel
        {
            var model = subject.Data<T>();

            model.Rendering = rendering;

            return model;
        }
    }
}
