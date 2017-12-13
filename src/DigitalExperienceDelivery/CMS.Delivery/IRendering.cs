using System;

namespace CMS.Delivery
{
    public interface IRendering : IHasData, IHasTemplate, IHasRenderings
    {
        Guid ComponentId { get; }
    }

    public interface IEmbeddedRendering : IHasData, IHasContent, IHasTemplate, IHasEmbeddedRenderings
    {

    }
}
