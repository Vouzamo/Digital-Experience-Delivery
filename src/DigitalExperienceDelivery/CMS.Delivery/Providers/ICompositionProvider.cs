using System;

namespace CMS.Delivery.Providers
{
    /// <summary>
    /// Used to provide an IComposition that describes the composition template and each rendering
    /// </summary>
    public interface ICompositionProvider
    {
        IComposition GetCompositionById(Guid id, IContext context);
    }
}
