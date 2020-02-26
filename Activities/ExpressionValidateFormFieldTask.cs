using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ExpressionFormFieldValidation.Abstractions;
using OrchardCore.ExpressionFormFieldValidation.Enums;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Activities;
using OrchardCore.Workflows.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.ExpressionFormFieldValidation.Activities
{
    public class ExpressionValidateFormFieldTask : TaskActivity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        private readonly IStringLocalizer<ExpressionValidateFormFieldTask> S;
        private readonly IEnumerable<IFieldValidationService> _validationServices;

        public ExpressionValidateFormFieldTask(
            IHttpContextAccessor httpContextAccessor,
            IUpdateModelAccessor updateModelAccessor,
            IStringLocalizer<ExpressionValidateFormFieldTask> localizer,
            IEnumerable<IFieldValidationService> validationServices
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _updateModelAccessor = updateModelAccessor;
            S = localizer;
            _validationServices = validationServices;
        }

        public override string Name => nameof(ExpressionValidateFormFieldTask);

        public override LocalizedString DisplayText => S["Validate form field with expression"];

        public override LocalizedString Category => S["Validation"];

        public string FieldName
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public string ErrorMessage
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public string FieldType
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public ExpressionType ExpressionType
        {
            get => GetProperty<ExpressionType>();
            set => SetProperty(value);
        }

        public string Expression
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            return Outcomes(S["Done"], S["Valid"], S["Invalid"]);
        }

        public override ActivityExecutionResult Execute(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            var form = _httpContextAccessor.HttpContext.Request.Form;
            var fieldValue = form[FieldName];

            var validationService = _validationServices.SingleOrDefault(s => s.Type == this.ExpressionType);

            var isValid = validationService.IsValid(this.FieldType, fieldValue, this.Expression);

            var outcome = isValid ? "Valid" : "Invalid";

            if (!isValid)
            {
                var updater = _updateModelAccessor.ModelUpdater;

                updater?.ModelState.TryAddModelError(FieldName, ErrorMessage);
            }

            return Outcomes("Done", outcome);
        }
    }
}