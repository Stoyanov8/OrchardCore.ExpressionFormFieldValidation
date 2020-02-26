using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using OrchardCore.ExpressionFormFieldValidation.Abstractions;
using OrchardCore.ExpressionFormFieldValidation.Enums;
using System;
using System.ComponentModel;

namespace OrchardCore.ExpressionFormFieldValidation.Services
{
    public class LambdaValidationService : IFieldValidationService
    {
        public ExpressionType Type { get; } = ExpressionType.Lambda;

        public bool IsValid(string fieldType, string fieldValue, string expression)
        {
            // Creates Type from fieldType
            var type = System.Type.GetType(fieldType);

            // Creates scripting options for Roslyn API.
            var scriptingOptions = ScriptOptions.Default.WithImports("System");

            // By using reflection, the generic method is created with dynamic T
            // Using this approach, the expression can be evaluated against strongly-typed value
            // Example: fieldType -> System.DateTime, expression -> x=> x == DateTime.Now
            var evaluationMethod = this.GetType().GetMethod(nameof(EvaluateAsync));
            var evaluationMethodInstance = evaluationMethod?.MakeGenericMethod(type);
            var result = evaluationMethodInstance?.Invoke(this, new object[] { expression, scriptingOptions });

            var value = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(fieldValue);

            var isValid = (result as Delegate)?.DynamicInvoke(value);

            return (bool?)isValid ?? false;
        }

        public Func<T, bool> EvaluateAsync<T>(string expressionAsString, ScriptOptions options)
            => CSharpScript.EvaluateAsync<Func<T, bool>>(expressionAsString, options).GetAwaiter().GetResult();
    }
}