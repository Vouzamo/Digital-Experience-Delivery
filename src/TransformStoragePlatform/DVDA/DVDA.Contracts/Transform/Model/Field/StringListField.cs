using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class StringListField: IField<List<string>>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.StringList;
        public string FieldReference { get; set; }
        public List<string> FieldValue { get; set; }
    }
}
