using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class DictionaryField : IField<Dictionary<string, Object>>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.Dictionary;
        public string FieldReference { get; set; }
        public Dictionary<string, object> FieldValue { get; set; }
    }
}
