// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlip.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Entities;

using System.ComponentModel.DataAnnotations;
using MyFirefighterStats.API.Utils;

public sealed class PaySlip
{
    [Key]
    public int Id { get; set; }

    [Required]
    public EMonth Month { get; set; }

    public ICollection<PaySlipLine> PaySlipLines { get; set; } = new List<PaySlipLine>();

    [Required]
    [Range(1900, 2100)]
    public int Year { get; set; }
}