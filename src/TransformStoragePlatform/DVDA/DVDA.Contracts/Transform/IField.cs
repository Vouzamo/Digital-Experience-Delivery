namespace DVDA.Data.Contracts.Transform
{
    public interface IField<T> : IFieldBase
    {
        FieldTypes FieldType { get; }
        string FieldReference { get; set; }
        T FieldValue { get; set; }
        
    }
}