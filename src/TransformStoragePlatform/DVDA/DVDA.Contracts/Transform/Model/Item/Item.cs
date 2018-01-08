using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Item
{
    public class Item : IItem
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public IEnumerable<IFieldBase> Fields { get; set; }
        public IEnumerable<IFieldBase> MetadataFields { get; set; }
    }
}
