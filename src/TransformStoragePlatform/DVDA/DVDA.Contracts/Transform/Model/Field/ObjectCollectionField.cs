using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class ObjectCollectionField<T> : IField<List<T>>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.ObjectCollection;
        public string FieldReference { get; set; }
        public List<T> FieldValue { get; set; }
    }
}
