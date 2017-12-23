using CMS.Delivery.Models;
using System.Collections.Generic;

namespace CMS.Delivery
{
    public interface IHasData
    {
        string Data { get; }
    }

    public interface IHasTemplate
    {
        ITemplate Template { get; }
    }

    public interface IHasContent
    {
        IContent Content { get; }
    }

    public interface IHasRenderings
    {
        IEnumerable<IRendering> Renderings { get; }
    }

    public interface IHasEmbeddedRenderings
    {
        IEnumerable<IEmbeddedRendering> Renderings { get; }
    }
}
