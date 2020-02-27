

## Module for OrchardCore 

The purpose of this module is to extend the field validation in workflows. </br>
The main difference is now you can validate a field using **lambda expression**  or **Regular expression**

For this we need to specify the :


## ExpressionType (Enum)

-     Lambda
-     Regex 

## FieldType 

 - String
 - Boolean
 - GUID
 - Integer
 - Long
 - DateTime
 - Char

## Expression
Based on the selected **ExpressionType**, write either lambda expression or RegEx. 

Based on the selected **FieldType** you can use different methods in your expression. <br> 

*Example*: *Let's say you want to validate that DateTime Input field is the same day as today.

Create new **Expression Validate Form Field** Task, set the **ExpressionType** to lambda, set **FieldType** to DateTime. </br>
In the Expression field type: **dt => dt.Date == DateTime.Today**


## How does lambda expression evaluation work ?

Lambda expressions are evaluated by the ***Microsoft.CodeAnalysis.CSharp.Scripting*** API.  ([Scripting-API-Samples](https://github.com/dotnet/roslyn/wiki/Scripting-API-Samples))
