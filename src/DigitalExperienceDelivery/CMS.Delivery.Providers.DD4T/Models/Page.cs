using System.Collections.Generic;

namespace CMS.Delivery.Providers.DD4T.Models
{
    public class Page
    {
        public List<ComponentPresentation> ComponentPresentations { get; set; }

        public Page()
        {
            ComponentPresentations = new List<ComponentPresentation>();
        }
    }

    public class ComponentPresentation
    {
        public List<TargetGroupCondition> TargetGroupConditions { get; set; }

        public ComponentPresentation()
        {
            TargetGroupConditions = new List<TargetGroupCondition>();
        }
    }

    public class TargetGroupCondition
    {
        public TargetGroup TargetGroup { get; set; }
        public bool Negate { get; set; }
    }

    public class TargetGroup
    {
        public List<CustomerCharacteristicCondition> Conditions { get; set; }

        public TargetGroup()
        {
            Conditions = new List<CustomerCharacteristicCondition>();
        }
    }

    public class CustomerCharacteristicCondition
    {
        public string Name { get; set; }
        public Operators Operator { get; set; }
        public string Value { get; set; }
        public bool Negate { get; set; }
    }

    public enum Operators
    {
        Equals,
        GreaterThan,
        LessThan,
        NotEqual,
        StringEquals,
        Contains,
        StartsWith,
        EndsWith,
        UnknownByClient = int.MinValue
    }
}
