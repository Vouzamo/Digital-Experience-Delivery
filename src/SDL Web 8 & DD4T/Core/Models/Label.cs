using DD4T.ViewModels.Attributes;
using DD4T.ViewModels.Base;

namespace Core.Models
{
    [ContentModel("label", true)]
    public class Label : ViewModelBase
    {
        [TextField(FieldName = "key")]
        public string Key { get; set; }

        [TextField(FieldName = "value")]
        public string Value { get; set; }
    }
}