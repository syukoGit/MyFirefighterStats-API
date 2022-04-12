// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="Activity.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Types;

public abstract class Activity
{
    public abstract EActivity ActivityType { get; set; }

    public abstract double Amount { get; }

    public virtual DateTime EndDateTime { get; set; }

    public virtual DateTime StartDateTime { get; set; }

    public double UnitAmount { get; set; }
}