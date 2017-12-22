using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Delivery
{
    public interface IProvider
    {
        Guid Id { get; }
    }

    public class Identity
    {
        public Guid FrameworkId { get; protected set; }
        public Guid ProviderId { get; protected set; }
        public string ExternalId { get; protected set; }

        public Identity(Guid frameworkId, Guid providerId, string externalId)
        {
            FrameworkId = frameworkId;
            ProviderId = providerId;
            ExternalId = externalId;
        }
    }

    public interface IIdentityManager
    {
        void Seed();
        Guid ToFrameworkId(IProvider provider, string externalId);
        string FromFrameworkId(IProvider provider, Guid frameworkId);
    }

    public class IdentityManager : IIdentityManager
    {
        protected List<Identity> Map { get; set; }

        public IdentityManager()
        {
            Map = new List<Identity>();
        }

        public void Seed()
        {
            Map.Add(new Identity(Guid.NewGuid(), new Guid("3253b2df-9b21-4a08-b4a3-969f257694a0"), "tcm:21-462-64"));
        }

        public string FromFrameworkId(IProvider provider, Guid frameworkId)
        {
            // Lookup string from database using provider.Id and framewordId
            var identity = Map.SingleOrDefault(x => x.ProviderId == provider.Id && x.FrameworkId == frameworkId);

            return identity?.ExternalId;
        }

        public Guid ToFrameworkId(IProvider provider, string externalId)
        {
            // Lookup guid from database using provider.Id and externalId
            var identity = Map.SingleOrDefault(x => x.ProviderId == provider.Id && x.ExternalId == externalId);

            if(identity == null)
            {
                var frameworkId = Guid.NewGuid();

                identity = new Identity(frameworkId, provider.Id, externalId);

                Map.Add(identity);
            }

            return identity.FrameworkId;
        }
    }
}
