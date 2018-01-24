using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform
{
    public interface IComposition : IItemBase
    {
        List<ICompositionItem> CompositionItems { get; set; }
    }
}
