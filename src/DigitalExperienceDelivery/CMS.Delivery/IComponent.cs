using System;

namespace CMS.Delivery
{
    public interface IComponent : IHasData
    {
        Guid Id { get; }
    }

    public interface IComponentModel
    {
        IRendering Rendering { get; set; }
    }

    public class ComponentModel : IComponentModel
    {
        public IRendering Rendering { get; set; }
    }
}
