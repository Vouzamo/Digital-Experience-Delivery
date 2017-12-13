using CMS.Delivery.Models;
using System;

namespace CMS.Delivery.Providers
{
    /// <summary>
    /// Used to provide IContent which is content as data with no consideration of how it should be rendered
    /// </summary>
    public interface IContentProvider
    {
        IContent GetContentById(Guid id, IContext context);
    }
}
