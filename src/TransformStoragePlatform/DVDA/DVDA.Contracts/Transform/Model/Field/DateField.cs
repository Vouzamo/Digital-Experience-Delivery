using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class DateField : IField<DateTime>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.Date;
        public string FieldReference { get; set; }
        public DateTime FieldValue { get; set; }
    }
}
