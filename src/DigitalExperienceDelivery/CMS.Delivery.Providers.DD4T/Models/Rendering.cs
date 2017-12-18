using System.Collections.Generic;
using System.Linq;
using CMS.Delivery.Models;

namespace CMS.Delivery.Providers.DD4T.Models
{
    public class Rendering : IEmbeddedRendering
    {
        public string Data => string.Empty;

        public IContent Content { get; protected set; }

        public ITemplate Template { get; protected set; }

        public IEnumerable<IEmbeddedRendering> Renderings => Enumerable.Empty<IEmbeddedRendering>();

        public Rendering(IContent content, ITemplate template)
        {
            Content = content;
            Template = template;
        }
    }
}
