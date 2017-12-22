using System;
using System.Collections.Generic;
using System.Linq;
using DD4T.ViewModels.Attributes;
using DD4T.ViewModels.Base;

namespace Core.Models
{
    [ContentModel("labelSet", true)]
    public class LabelSet : ViewModelBase
    {
        [ComponentTitle]
        public string ComponentTitle { get; set; }

        [EmbeddedSchemaField(FieldName = "labels", EmbeddedModelType = typeof(Label))]
        public List<Label> Labels { get; set; }

        public bool TryGetValue(string key, out string value)
        {
            var label = Labels?.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

            value = label?.Value;

            return label != null;
        }
    }
}