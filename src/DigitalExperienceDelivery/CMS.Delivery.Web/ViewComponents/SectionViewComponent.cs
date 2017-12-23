using CMS.Delivery.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Delivery.Web.ViewComponents
{
    public class SectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEmbeddedRendering rendering)
        {
            var model = rendering.Content.Data<SectionModel>(rendering);

            return View(model);
        }
    }
}
