using System.Collections.Generic;

namespace DVDA.Data.Contracts.Transform
{
    public interface IItem : IItemBase
    {
        IList<IFieldBase> Fields { get; set; }
        IList<IFieldBase> MetadataFields { get; set; }
    }
}
