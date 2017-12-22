using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Factories;
using DD4T.Mvc.Controllers;

namespace WebApp.Controllers
{
    public class HomeController : TridionControllerBase
    {
        public HomeController(IPageFactory pageFactory, IComponentPresentationFactory componentPresentationFactory, ILogger logger, IDD4TConfiguration configuration) : base(pageFactory, componentPresentationFactory, logger, configuration)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult FindPageId(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                uri = "index.html";
            }
            else if (uri.EndsWith("/"))
            {
                uri += "index.html";
            }
            else if (!uri.EndsWith(".html"))
            {
                uri += "/index.html";
            }

            try
            {
                //var client = new SDLWeb8CILv4.ContentDeliveryService(new Uri("http://sdl.cms.services:8083/client/v4/content.svc"));

                var client = new SDLWeb8CIL.ContentDeliveryService(new Uri("http://sdl.cms.services:8083/client/v2/content.svc"));

                var pages = client.Pages.Where(x => x.Url == $"/{uri}");

                var page = pages.SingleOrDefault();

                var id = $"tcm:{page.PublicationId}-{page.ItemId}-64";

                return Json(id);
            }
            catch (Exception ex)
            {
                LoggerService.Error(ex.Message);
                throw;
            }
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult GetPageById(string pageId)
        {
            try
            {
                var pageTcmUri = new TcmUri(pageId);

                //var client = new SDLWeb8CILv4.ContentDeliveryService(new Uri("http://sdl.cms.services:8083/client/v4/content.svc"));

                var client = new SDLWeb8CIL.ContentDeliveryService(new Uri("http://sdl.cms.services:8083/client/v2/content.svc"));

                var pages = client.PageContents.Where(x => x.PublicationId == pageTcmUri.PublicationId && x.PageId == pageTcmUri.ItemId);

                var page = pages.SingleOrDefault();

                return Json(page.Content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}