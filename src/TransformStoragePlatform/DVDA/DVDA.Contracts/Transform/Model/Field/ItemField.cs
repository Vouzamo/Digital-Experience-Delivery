using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class ItemField : IField<Item.Item>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.Item;
        public string FieldReference { get; set; }
        public Item.Item FieldValue { get; set; }
    }
}
