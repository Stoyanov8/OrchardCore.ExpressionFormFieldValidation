using OrchardCore.ExpressionFormFieldValidation.Abstractions;
using OrchardCore.ExpressionFormFieldValidation.Enums;
using System.Text.RegularExpressions;

namespace OrchardCore.ExpressionFormFieldValidation.Services
{
    public class RegexValidationService : IFieldValidationService
    {
        public ExpressionType Type { get; } = ExpressionType.Regex;

        public bool IsValid(string fieldType, string fieldValue, string expression)
            => new Regex(expression).IsMatch(fieldValue);
    }
}