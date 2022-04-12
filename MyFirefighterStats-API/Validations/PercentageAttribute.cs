// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PercentageAttribute.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Validations;

using System.ComponentModel.DataAnnotations;

public class PercentageAttribute : ValidationAttribute
{
    /// <inheritdoc />
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) => value switch
    {
        null or not int and not decimal => new ValidationResult("The percentage must be a number."),
        < 0 or > 100 => new ValidationResult("The percentage must be between 0 and 100."),
        _ => ValidationResult.Success,
    };
}