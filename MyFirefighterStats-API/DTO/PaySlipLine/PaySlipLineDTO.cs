// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="PaySlipLineDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.DTO.PaySlipLine
{
    public sealed class PaySlipLineDTO
    {
        public DateTime EndDateTime { get; set; }

        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }
    }
}
