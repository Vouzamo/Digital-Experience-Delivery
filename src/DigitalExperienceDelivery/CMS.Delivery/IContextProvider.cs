using Microsoft.AspNetCore.Http;
using System;

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

    public interface IRequestContext
    {
        string Uri { get; }
    }

    public interface IContext: ILocalizationContext, IDeviceContext, IRequestContext
    {
        Guid Id { get; }
    }

    public interface IContextProvider : IProvider
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
        public string Uri { get; set; }
    }

    public class DefaultContextProvider : IContextProvider
    {
        public Guid Id => new Guid("02325b0e-4fbc-4a83-bb4b-89a4d9739141");

        public IContext ResolveContext(HttpRequest request)
        {
            return new DefaultContext()
            {
                Id = Guid.NewGuid(),
                LanguageCode = "en",
                CountryCode = "GB",
                UserAgent = string.Empty,
                Width = 800,
                Height = 600,
                Uri = request.Path
            };
        }
    }
}
