using CMS.Delivery.Models;
using CMS.Delivery.Providers.DD4T.Models;
using DD4T.ContentModel;
using IComponent = DD4T.ContentModel.IComponent;
using Refit;
using System;
using System.Collections.Generic;

namespace CMS.Delivery.Providers.DD4T
{
    public class DD4TCompositionResolverProvider : ICompositionResolver, ICompositionProvider
    {
        public Guid Id => new Guid("3253b2df-9b21-4a08-b4a3-969f257694a0");

        private IIdentityManager IdentityManager { get; set; }
        private IDD4TContract Client { get; set; }

        public DD4TCompositionResolverProvider(IIdentityManager identityManager)
        {
            IdentityManager = identityManager;
            Client = RestService.For<IDD4TContract>("https://api.dd4t.com");
        }

        public bool TryResolveCompositionId(string uri, IContext context, out Guid id)
        {
            try
            {
                id = Client.ResolveCompositionId(uri, context).Result;

                return id != Guid.Empty;
            }
            catch(Exception ex)
            {
                id = Guid.Empty;
                return false;
            }
        }

        public IComposition GetCompositionById(Guid id, IContext context)
        {
            var pageId = IdentityManager.FromFrameworkId(this, id);

            var page = Client.GetPageById(pageId, context).Result;

            return ConvertPageToComposition(page);

            throw new KeyNotFoundException("Couldn't find the requested composition");
        }

        private IComposition ConvertPageToComposition(IPage page)
        {
            var pageId = IdentityManager.ToFrameworkId(this, page.Id.ToString());

            var pageTemplate = ConvertPageTemplate(page.PageTemplate);

            var composition = new Composition(pageId, pageTemplate);

            foreach(var cp in page.ComponentPresentations)
            {
                var content = ConvertComponent(cp.Component);
                var template = ConvertComponentTemplate(cp.ComponentTemplate);

                composition.AddRendering(new Rendering(content, template));
            }

            return composition;
        }

        private IContent ConvertComponent(IComponent component)
        {
            var id = IdentityManager.ToFrameworkId(this, component.Id.ToString());

            // Component fields
            var data = string.Empty;

            return new Content(id, data);
        }

        private Delivery.Models.ITemplate ConvertComponentTemplate(IComponentTemplate componentTemplate)
        {
            var id = IdentityManager.ToFrameworkId(this, componentTemplate.Id.ToString());

            // Component Template Metadata fields
            var data = string.Empty;

            return new Template(id, data);
        }

        private Delivery.Models.ITemplate ConvertPageTemplate(IPageTemplate pageTemplate)
        {
            var id = IdentityManager.ToFrameworkId(this, pageTemplate.Id.ToString());

            // Page Template Metadata fields
            var data = string.Empty;

            return new Template(id, data);
        }
    }
}
