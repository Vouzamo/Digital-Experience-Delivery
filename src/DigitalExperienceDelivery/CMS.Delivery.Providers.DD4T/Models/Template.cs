using CMS.Delivery.Models;
using System;

namespace CMS.Delivery.Providers.DD4T.Models
{
    public class Template : ITemplate
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public Template(Guid id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}
