// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipCreationDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlip;

using System.ComponentModel.DataAnnotations;
using MyFirefighterStats.API.DTO.PaySlipLine;
using MyFirefighterStats.API.Utils;

public class PaySlipCreationDTO
{
    [Required]
    public EMonth Month { get; set; }

    public ICollection<PaySlipLineCreationDTO> PaySlipLines { get; set; }
}
