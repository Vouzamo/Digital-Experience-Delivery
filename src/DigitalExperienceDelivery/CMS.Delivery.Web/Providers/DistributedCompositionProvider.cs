using CMS.Delivery.Models;
using CMS.Delivery.Providers;
using System;
using System.Collections.Generic;

namespace CMS.Delivery.Web.Providers
{
    public class DistributedCompositionProvider : ICompositionProvider
    {
        private class EmbeddedRendering : IEmbeddedRendering
        {
            public IContent Content { get; protected set; }
            public ITemplate Template { get; protected set; }

            public string Data { get; protected set; }

            public IEnumerable<IEmbeddedRendering> Renderings { get; protected set; }

            public EmbeddedRendering(IContent content, ITemplate template, string data, IEnumerable<IEmbeddedRendering> renderings)
            {
                Content = content;
                Template = template;
                Data = data;
                Renderings = renderings;
            }
        }

        private class DistributedComposition : IComposition
        {
            public Guid Id { get; set; }
            public ITemplate Template { get; set; }
            public IEnumerable<IEmbeddedRendering> Renderings { get; set; }

            public DistributedComposition(Guid id, ITemplate template, IEnumerable<IEmbeddedRendering> renderings)
            {
                Id = id;
                Template = template;
                Renderings = renderings;
            }
        }

        protected ILayoutProvider LayoutProvider { get; set; }
        protected IContentProvider ContentProvider { get; set; }

        public DistributedCompositionProvider(ILayoutProvider layoutProvider, IContentProvider contentProvider)
        {
            LayoutProvider = layoutProvider;
            ContentProvider = contentProvider;
        }

        public IComposition GetCompositionById(Guid id, IContext context)
        {
            if (LayoutProvider.TryGetLayoutById(id, context, out ILayout layout))
            {
                var embeddedRenderings = new List<IEmbeddedRendering>();

                foreach(var rendering in layout.Renderings)
                {
                    var embeddedRendering = ToRendering(rendering, ContentProvider, context);

                    embeddedRenderings.Add(embeddedRendering);
                }

                return new DistributedComposition(layout.Id, layout.Template, embeddedRenderings);
            }

            throw new InvalidCastException("Failed to cast layout");
        }

        private static IEmbeddedRendering ToRendering(IRendering rendering, IContentProvider contentProvider, IContext context)
        {
            if(contentProvider.TryGetContentById(rendering.ComponentId, context, out IContent content))
            {
                var renderings = new List<IEmbeddedRendering>();

                foreach(var child in rendering.Renderings)
                {
                    var embeddedRendering = ToRendering(child, contentProvider, context);

                    renderings.Add(embeddedRendering);
                }

                return new EmbeddedRendering(content, rendering.Template, rendering.Data, renderings);
            }

            throw new InvalidCastException("Failed to cast rendering");
        }
    }
}
