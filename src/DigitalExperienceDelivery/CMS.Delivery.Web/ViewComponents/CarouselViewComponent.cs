using CMS.Delivery.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Delivery.Web.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEmbeddedRendering rendering)
        {
            var model = rendering.Content.Data<CarouselModel>(rendering);

            return View(model);
        }
    }
}
