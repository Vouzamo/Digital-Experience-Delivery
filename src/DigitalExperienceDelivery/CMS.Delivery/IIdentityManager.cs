using System;

namespace CMS.Delivery
{
    public interface IProvider
    {
        Guid Id { get; }
    }

    public interface IIdentityManager
    {
        Guid ToFrameworkId(IProvider provider, string externalId);
        string FromFrameworkId(IProvider provider, Guid frameworkId);
    }

    public class IdentityManager : IIdentityManager
    {
        public string FromFrameworkId(IProvider provider, Guid frameworkId)
        {
            // Lookup string from database using provider.Id and framewordId

            return string.Empty;
        }

        public Guid ToFrameworkId(IProvider provider, string externalId)
        {
            // Lookup guid from database using provider.Id and externalId

            return Guid.NewGuid();
        }
    }
}
