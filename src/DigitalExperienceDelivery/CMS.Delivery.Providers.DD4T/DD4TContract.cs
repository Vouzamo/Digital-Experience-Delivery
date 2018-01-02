using DD4T.ContentModel;
using Refit;
using System.Threading.Tasks;

namespace CMS.Delivery.Providers.DD4T
{
    public interface IDD4TContract
    {
        [Post("/getPage")]
        Task<string> GetPage([Body] IContext context);
    }
}
