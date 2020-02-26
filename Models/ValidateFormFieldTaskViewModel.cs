using OrchardCore.ExpressionFormFieldValidation.Enums;

namespace OrchardCore.ExpressionFormFieldValidation.Models
{
    public class ValidateFormFieldTaskViewModel
    {
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public ExpressionType ExpressionType { get; set; }

        public string Expression { get; set; }

        public string ErrorMessage { get; set; }
    }
}