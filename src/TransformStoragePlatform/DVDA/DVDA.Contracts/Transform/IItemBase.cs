using System;
using System.Collections.Generic;

namespace DVDA.Data.Contracts.Transform
{
    public interface IItemBase
    {
        string FieldIdentifier { get; set; }
        Dictionary<string, Object> ExtendedProperties { get; set; }
    }
}
