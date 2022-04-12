// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="AutoMapperProfiles.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Helpers;

using AutoMapper;
using MyFirefighterStats.API.DTO.PaySlip;
using MyFirefighterStats.API.DTO.PaySlipLine;
using MyFirefighterStats.API.Entities;
using MyFirefighterStats.API.Types;

// ReSharper disable once UnusedType.Global
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        _ = this.CreateMap<PaySlip, PaySlipDTO>();
        _ = this.CreateMap<PaySlipCreationDTO, PaySlip>();
        _ = this.CreateMap<PaySlipUpdateDTO, PaySlip>();

        _ = this.CreateMap<PaySlipLine, PaySlipLineDTO>();
        _ = this.CreateMap<PaySlipLineCreationDTO, PaySlipLine>();
        _ = this.CreateMap<PaySlipLineUpdateDTO, PaySlipLine>();

        _ = this.CreateMap<PaySlipLine, Activity>()
                .ConstructUsing(static c => c.ActivityType == EActivity.FirefighterActivity
                                                ? new FirefighterActivity()
                                                : new Intervention());
    }
}