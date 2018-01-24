using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform
{
    public interface IRenderingItem : IItemBase
    {
        IList<IItem> Items { get; set; }
        IList<IRenderingItem> ChildRenderings { get; set; }
        IList<IFieldBase> Fields { get; set; }
        IList<IFieldBase> MetadataFields { get; set; }
    }
}
