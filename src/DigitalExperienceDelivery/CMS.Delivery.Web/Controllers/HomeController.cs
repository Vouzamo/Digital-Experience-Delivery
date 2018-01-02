using Microsoft.AspNetCore.Mvc;
using CMS.Delivery.Web.Models;
using System;
using CMS.Delivery.Providers;

namespace CMS.Delivery.Web.Controllers
{
    public class HomeController : Controller
    {
        protected IContextProvider ContextProvider { get; set; }
        protected ICompositionProvider CompositionProvider { get; set; }

        public HomeController(IContextProvider contextProvider, ICompositionProvider compositionProvider)
        {
            ContextProvider = contextProvider;
            CompositionProvider = compositionProvider;
        }

        public IActionResult Index(string uri)
        {
            var context = ContextProvider.ResolveContext(Request);

            if (CompositionProvider.TryGetComposition(context, out IComposition composition))
            {
                var template = composition.Template.Data<CompositionTemplateModel>();

                return View(template.View, composition);
            }

            return new NotFoundResult();
        }
    }
}
