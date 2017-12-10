using Microsoft.AspNetCore.Mvc;
using CMS.Delivery.Web.Models;
using System;

namespace CMS.Delivery.Web.Controllers
{
    public class HomeController : Controller
    {
        protected IContextProvider ContextProvider { get; set; }
        protected ICompositionProvider CompositionProvider { get; set; }
        protected ICompositionResolver CompositionResolver { get; set; }

        public HomeController(IContextProvider contextProvider, ICompositionProvider compositionProvider, ICompositionResolver compositionResolver)
        {
            ContextProvider = contextProvider;
            CompositionProvider = compositionProvider;
            CompositionResolver = compositionResolver;
        }

        public IActionResult Index(string uri)
        {
            var context = ContextProvider.ResolveContext(Request);

            if(CompositionResolver.TryResolveCompositionId(uri, context, out Guid compositionId))
            {
                if (CompositionProvider.TryGetComposition(compositionId, context, out IComposition composition))
                {
                    var template = composition.Template.Data<CompositionTemplateModel>();

                    return View(template.View, composition);
                }
            }

            return new NotFoundResult();
        }
    }
}
