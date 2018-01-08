using DVDA.Data.Contracts.Transform;

namespace DVDA.Data.Contracts.Plugins
{
    public interface ITransformPlugin<T>
    {
        string Id { get; }
        string Name { get; }
        IItem Transform(T sourceData);

    }
}
