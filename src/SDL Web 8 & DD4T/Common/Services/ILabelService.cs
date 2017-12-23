namespace Common.Services
{
    public interface ILabelService
    {
        bool TryGetLabel(string key, out string value);
    }
}
