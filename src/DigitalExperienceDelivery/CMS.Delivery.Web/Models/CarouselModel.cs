using System.Collections.Generic;

namespace CMS.Delivery.Web.Models
{
    public class CarouselModel : ComponentModel
    {
        public string Title { get; set; }
        public IEnumerable<SlideModel> Slides { get; set; }

    }

    public class SlideModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class SectionModel : ComponentModel
    {
        public string Title { get; set; }
    }
}
