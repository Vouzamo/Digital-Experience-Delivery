using CMS.Delivery.Models;
using System;

namespace CMS.Delivery.Providers
{
    /// <summary>
    /// This interface should be an implementation detail of the DistributedCompositionProvider and not directly used in delivery
    /// </summary>
    public interface ILayoutProvider
    {
        ILayout GetLayoutById(Guid id, IContext context);
    }
}
