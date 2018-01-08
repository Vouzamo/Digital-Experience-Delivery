﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Field
{
    public class RichTextFIeld : IField<string>
    {
        public string FieldIdentifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public FieldTypes FieldType => FieldTypes.RichText;
        public string FieldReference { get; set; }
        public string FieldValue { get; set; }
    }
}
