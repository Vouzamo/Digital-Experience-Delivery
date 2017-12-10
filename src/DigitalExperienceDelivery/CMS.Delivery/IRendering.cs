using System;
using System.Collections.Generic;

namespace CMS.Delivery
{
    public interface IRendering
    {
        Guid ComponentId { get; }
        ITemplate Template { get; }
        IEnumerable<IRendering> Renderings { get; }
    }
}
