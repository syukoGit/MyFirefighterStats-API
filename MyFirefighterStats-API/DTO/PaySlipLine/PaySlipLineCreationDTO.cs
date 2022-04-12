// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipLineCreationDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlipLine;

using System.ComponentModel.DataAnnotations;
using MyFirefighterStats.API.Types;

public class PaySlipLineCreationDTO : IValidatableObject
{
    [Required]
    public EActivity ActivityType { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDateTime { get; set; }

    [Range(0, 200)]
    public int? Rate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDateTime { get; set; }

    [Required]
    public double UnitAmount { get; set; }

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.EndDateTime <= this.StartDateTime)
        {
            yield return new ValidationResult($"{nameof(this.EndDateTime)} must be after {nameof(this.StartDateTime)}", new[]
            {
                nameof(this.EndDateTime),
            });
        }

        if (this.ActivityType == EActivity.FirefighterActivity && this.Rate == null)
        {
            yield return new ValidationResult($"{nameof(this.Rate)} must be defined for a firefighter activity", new[]
            {
                nameof(this.Rate),
            });
        }

        if (this.UnitAmount < 0)
        {
            yield return new ValidationResult($"{nameof(this.UnitAmount)} must be better than zero", new[]
            {
                nameof(this.UnitAmount),
            });
        }
    }
}