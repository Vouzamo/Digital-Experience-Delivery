using CMS.Delivery.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Delivery.Web.ViewComponents
{
    public class SectionViewComponent : ViewComponent
    {
        protected IContextProvider ContextProvider { get; set; }
        protected IComponentProvider ComponentProvider { get; set; }

        public SectionViewComponent(IContextProvider contextProvider, IComponentProvider componentProvider)
        {
            ContextProvider = contextProvider;
            ComponentProvider = componentProvider;
        }

        public IViewComponentResult Invoke(IRendering rendering)
        {
            var context = ContextProvider.ResolveContext(Request);

            if (ComponentProvider.TryGetComponent(rendering.ComponentId, context, out IComponent component))
            {
                var model = component.Data<SectionModel>(rendering);

                return View(model);
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
