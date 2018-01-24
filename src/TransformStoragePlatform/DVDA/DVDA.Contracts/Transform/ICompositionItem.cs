using System;
using System.Collections.Generic;
using System.Text;
using DVDA.Data.Contracts.Transform.Model.Item;

namespace DVDA.Data.Contracts.Transform
{
    public interface ICompositionItem : IItemBase
    {
        IItem Content { get; set; }
        IRenderingItem Presentation { get; set; }
    }
}
