using CMS.Delivery.Models;
using System;
using System.Collections.Generic;

namespace CMS.Delivery.Providers.DD4T.Models
{
    public class Composition : IComposition
    {
        public Guid Id { get; protected set; }
        public ITemplate Template { get; protected set; }
        public IEnumerable<IEmbeddedRendering> Renderings => _Renderings;

        protected List<IEmbeddedRendering> _Renderings { get; set; }

        public Composition(Guid id, ITemplate template)
        {
            Id = id;
            Template = template;

            _Renderings = new List<IEmbeddedRendering>();
        }

        public void AddRendering(IEmbeddedRendering rendering)
        {
            _Renderings.Add(rendering);
        }
    }
}
