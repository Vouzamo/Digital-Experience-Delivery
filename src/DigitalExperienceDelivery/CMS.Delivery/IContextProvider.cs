using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Delivery
{
    public interface ILocalizationContext
    {
        string LanguageCode { get; }
        string CountryCode { get; }
    }

    public interface IDeviceContext
    {
        string UserAgent { get; }
        int Width { get; }
        int Height { get; }
    }

    public interface IContext: ILocalizationContext, IDeviceContext
    {
        Guid Id { get; }
    }

    public interface IContextProvider
    {
        IContext ResolveContext(HttpRequest request);
    }

    public class DefaultContext : IContext
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }
        public string CountryCode { get; set; }
        public string UserAgent { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class DefaultContextProvider : IContextProvider
    {
        public IContext ResolveContext(HttpRequest request)
        {
            return new DefaultContext()
            {
                Id = Guid.NewGuid(),
                LanguageCode = "en",
                CountryCode = "US",
                UserAgent = string.Empty,
                Width = 800,
                Height = 600
            };
        }
    }
}
