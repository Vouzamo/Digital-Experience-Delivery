﻿using System.Collections.Generic;

namespace DVDA.Data.Contracts.Transform
{
    public interface IItem : IItemBase
    {
        IEnumerable<IFieldBase> Fields { get; set; }
        IEnumerable<IFieldBase> MetadataFields { get; set; }
    }
}
