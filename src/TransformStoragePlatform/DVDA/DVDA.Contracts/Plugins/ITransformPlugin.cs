using System;
using System.Collections.Generic;
using System.Text;
using DVDA.Contracts.Transform;

namespace DVDA.Contracts.Plugins
{
    public interface ITransformPlugin<T>
    {
        string Id { get; }
        string Name { get; }
        IItem Transform(T sourceData);

    }
}
