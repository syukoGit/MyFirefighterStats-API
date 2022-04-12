// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipLine.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFirefighterStats.API.Types;

public sealed class PaySlipLine
{
    public EActivity ActivityType { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(PaySlip.Id))]
    public int PaySlipId { get; set; }

    public int? Rate { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public double UnitAmount { get; set; }
}