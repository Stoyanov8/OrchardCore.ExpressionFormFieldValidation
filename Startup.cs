using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ExpressionFormFieldValidation.Abstractions;
using OrchardCore.ExpressionFormFieldValidation.Activities;
using OrchardCore.ExpressionFormFieldValidation.Drivers;
using OrchardCore.ExpressionFormFieldValidation.Services;
using OrchardCore.Modules;
using OrchardCore.Workflows.Helpers;
using System;

namespace OrchardCore.ExpressionValidator
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFieldValidationService, LambdaValidationService>();
            services.AddTransient<IFieldValidationService, RegexValidationService>();

            services.AddActivity<ExpressionValidateFormFieldTask, ExpressionValidateFormFieldTaskDisplay>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}