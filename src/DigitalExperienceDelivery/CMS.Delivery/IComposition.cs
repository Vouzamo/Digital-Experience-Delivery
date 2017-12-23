using System;

namespace CMS.Delivery
{
    public interface IComposition : IHasTemplate, IHasEmbeddedRenderings
    {
        Guid Id { get; }
    }
}
