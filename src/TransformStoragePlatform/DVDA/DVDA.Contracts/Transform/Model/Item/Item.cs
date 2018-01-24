﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Item
{
    public class Item : IItem
    {
        public string Identifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public Dictionary<string, string> Tagging { get; set; }
        public IList<IFieldBase> Fields { get; set; }
        public IList<IFieldBase> MetadataFields { get; set; }
    }
}
