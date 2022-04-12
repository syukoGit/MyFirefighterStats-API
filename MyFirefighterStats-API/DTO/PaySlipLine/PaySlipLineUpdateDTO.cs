// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipLineUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlipLine;

using System.ComponentModel.DataAnnotations;

public class PaySlipLineUpdateDTO : IValidatableObject
{
    [Required, DataType(DataType.DateTime)]
    public DateTime EndDateTime { get; set; }

    [Required]
    public int Id { get; set; }

    [Required, DataType(DataType.DateTime)]
    public DateTime StartDateTime { get; set; }

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.EndDateTime <= this.StartDateTime)
        {
            yield return new ValidationResult("EndDateTime must be after StartDateTime", new[]
            {
                "EndDateTime",
            });
        }
    }
}
