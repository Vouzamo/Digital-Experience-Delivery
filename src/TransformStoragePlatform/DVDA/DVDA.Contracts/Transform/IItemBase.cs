using System;
using System.Collections.Generic;

namespace DVDA.Data.Contracts.Transform
{
    public interface IItemBase
    {
        string Identifier { get; set; }
        Dictionary<string, Object> ExtendedProperties { get; set; }
        Dictionary<string, string> Tagging { get; set; }
    }
}
