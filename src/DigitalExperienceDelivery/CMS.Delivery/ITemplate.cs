using System;

namespace CMS.Delivery
{

    public interface ITemplate : IHasData
    {
        Guid Id { get; }
    }
}
