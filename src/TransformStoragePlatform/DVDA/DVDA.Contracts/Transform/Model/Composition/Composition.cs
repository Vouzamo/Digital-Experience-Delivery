using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Composition
{
    public class Composition : IComposition
    {
        public string Identifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public Dictionary<string, string> Tagging { get; set; }
        public List<ICompositionItem> CompositionItems { get; set; }
    }
}
