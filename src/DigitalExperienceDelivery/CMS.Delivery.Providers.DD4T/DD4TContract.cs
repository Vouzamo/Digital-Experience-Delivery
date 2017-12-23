using DD4T.ContentModel;
using Refit;
using System.Threading.Tasks;

namespace CMS.Delivery.Providers.DD4T
{
    public interface IDD4TContract
    {
        [Post("/findPageId/{uri}")]
        Task<string> FindPageId(string uri, [Body] IContext context);

        [Post("/getPageById/{pageId}")]
        Task<string> GetPageById(string pageId, [Body] IContext context);
    }
}
