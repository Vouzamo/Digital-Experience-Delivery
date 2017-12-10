using System;
using System.Collections.Generic;

namespace CMS.Delivery
{
    public interface IComposition
    {
        Guid Id { get; }
        ITemplate Template { get; }
        IEnumerable<IRendering> Renderings { get; }
    }
}
