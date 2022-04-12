// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlip;

using MyFirefighterStats.API.DTO.PaySlipLine;
using MyFirefighterStats.API.Utils;

public sealed class PaySlipUpdateDTO
{
    public EMonth Month { get; set; }

    public ICollection<PaySlipLineUpdateDTO>? PaySlipLines { get; set; }
}
