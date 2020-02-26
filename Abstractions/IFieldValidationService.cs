using OrchardCore.ExpressionFormFieldValidation.Enums;

namespace OrchardCore.ExpressionFormFieldValidation.Abstractions
{
    public interface IFieldValidationService
    {
        ExpressionType Type { get; }

        bool IsValid(string fieldType, string fieldValue, string expression);
    }
}