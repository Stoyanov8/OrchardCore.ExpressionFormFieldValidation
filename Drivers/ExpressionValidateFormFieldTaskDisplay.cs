using OrchardCore.ExpressionFormFieldValidation.Activities;
using OrchardCore.ExpressionFormFieldValidation.Models;
using OrchardCore.Workflows.Display;

namespace OrchardCore.ExpressionFormFieldValidation.Drivers
{
    public class ExpressionValidateFormFieldTaskDisplay : ActivityDisplayDriver<ExpressionValidateFormFieldTask, ValidateFormFieldTaskViewModel>
    {
        protected override void EditActivity(ExpressionValidateFormFieldTask activity, ValidateFormFieldTaskViewModel model)
        {
            model.FieldName = activity.FieldName;
            model.ErrorMessage = activity.ErrorMessage;
            model.FieldType = activity.FieldType;
            model.ExpressionType = activity.ExpressionType;
            model.Expression = activity.Expression;
        }

        protected override void UpdateActivity(ValidateFormFieldTaskViewModel model, ExpressionValidateFormFieldTask activity)
        {
            activity.FieldName = model.FieldName;
            activity.ErrorMessage = model.ErrorMessage;
            activity.FieldType = model.FieldType;
            activity.ExpressionType = model.ExpressionType;
            activity.Expression = model.Expression;
        }
    }
}