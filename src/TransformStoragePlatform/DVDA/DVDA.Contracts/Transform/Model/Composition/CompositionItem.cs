using System;
using System.Collections.Generic;
using System.Text;

namespace DVDA.Data.Contracts.Transform.Model.Composition
{
    public class CompositionItem : ICompositionItem
    {
        public string Identifier { get; set; }
        public Dictionary<string, object> ExtendedProperties { get; set; }
        public Dictionary<string, string> Tagging { get; set; }
        public IItem Content { get; set; }
        public IRenderingItem Presentation { get; set; }
    }
}
