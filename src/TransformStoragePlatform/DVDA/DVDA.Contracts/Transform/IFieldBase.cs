using System;
using System.Collections.Generic;

namespace DVDA.Data.Contracts.Transform
{
    public interface IFieldBase
    {
        string FieldIdentifier { get; set; }
        Dictionary<string, Object> ExtendedProperties { get; set; }
        //TODO: add a validation method to base. Need to create flexible validation objects
    }
}
