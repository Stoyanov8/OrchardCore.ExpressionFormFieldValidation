using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OrchardCore.ExpressionFormFieldValidation.Helpers
{
    public static class FieldTypes
    {
        public static IEnumerable<SelectListItem> BuildInTypes => new List<SelectListItem>
        {
            new SelectListItem("String", "System.String"),
            new SelectListItem("Boolean", "System.Boolean"),
            new SelectListItem("GUID", "System.Guid"),
            new SelectListItem("Integer", "System.Int32"),
            new SelectListItem("Long", "System.Int64"),
            new SelectListItem("Date Time", "System.DateTime"),
            new SelectListItem("Character", "System.Char")
        };
    }
}