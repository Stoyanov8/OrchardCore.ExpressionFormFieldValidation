using System.Collections.Generic;

namespace OrchardCore.ExpressionFormFieldValidation.Helpers
{
    public static class ImportsHelper
    {
        // TODO remove hardcoded "System" Import in LambdaExpressionValidationService.
        // For each type declare dependent Imports.
        public static Dictionary<string, IEnumerable<string>> GetImportsByFieldType
            => new Dictionary<string, IEnumerable<string>>();
    }
}