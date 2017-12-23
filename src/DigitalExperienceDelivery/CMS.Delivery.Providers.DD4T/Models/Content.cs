using CMS.Delivery.Models;
using System;

namespace CMS.Delivery.Providers.DD4T.Models
{
    public class Content : IContent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public Content(Guid id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}
