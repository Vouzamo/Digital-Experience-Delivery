using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform
{
    public interface IRenderingItem : IItemBase
    {
        IEnumerable<IFieldBase> Fields { get; set; }
        IEnumerable<IFieldBase> MetadataFields { get; set; }
    }
}
