// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlip
{
    using MyFirefighterStats.API.DTO.PaySlipLine;
    using MyFirefighterStats.API.Utils;

    public class PaySlipDTO
    {
        public int Id { get; set; }

        public EMonth Month { get; set; }

        public ICollection<PaySlipLineDTO>? PaySlipLines { get; set; }
    }
}
