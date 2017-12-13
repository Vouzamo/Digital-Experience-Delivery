using System;

namespace CMS.Delivery.Models
{
    public interface ILayout : IHasTemplate, IHasRenderings
    {
        Guid Id { get; }
    }

    public interface ITemplate : IHasData
    {
        Guid Id { get; }
    }

    public interface IRendering : IHasTemplate, IHasData, IHasRenderings
    {
        Guid ContentId { get; }
    }
}
