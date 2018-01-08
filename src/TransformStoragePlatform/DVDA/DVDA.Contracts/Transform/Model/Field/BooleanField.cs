using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class BooleanField : IField<Boolean>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.Boolean;
        public string FieldReference { get; set; }
        public bool FieldValue { get; set; }
    }
}
