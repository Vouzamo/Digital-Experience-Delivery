using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Rendering
{
    public class RenderingItem : IRenderingItem
    {
        public string Identifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public Dictionary<string, string> Tagging { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IRenderingItem> ChildRenderings { get; set; }
        public IList<IFieldBase> Fields { get; set; }
        public IList<IFieldBase> MetadataFields { get; set; }
    }
}
