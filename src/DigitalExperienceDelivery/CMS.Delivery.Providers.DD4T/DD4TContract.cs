using DD4T.ContentModel;
using Refit;
using System;
using System.Threading.Tasks;

namespace CMS.Delivery.Providers.DD4T
{
    public interface IDD4TContract
    {
        [Post("/findPage/{uri}")]
        Task<Guid> ResolveCompositionId(string uri, [Body] IContext context);

        [Post("/getPageById/{pageId}")]
        Task<IPage> GetPageById(string pageId, [Body] IContext context);
    }
}
