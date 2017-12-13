using System;

namespace CMS.Delivery
{
    public interface IComponent : IHasData
    {
        Guid Id { get; }
    }

    public interface IComponentModel
    {
        IEmbeddedRendering Rendering { get; set; }
    }

    public class ComponentModel : IComponentModel
    {
        public IEmbeddedRendering Rendering { get; set; }
    }
}
