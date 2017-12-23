using System;

namespace CMS.Delivery.Models
{
    public interface IContent : IHasData
    {
        Guid Id { get; }
    }
}
