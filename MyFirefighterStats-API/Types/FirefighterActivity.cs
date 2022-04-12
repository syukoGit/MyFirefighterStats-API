// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="FirefighterActivity.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Types;

using MyFirefighterStats.API.Utils;

public sealed class FirefighterActivity : Activity
{
    /// <inheritdoc />
    public override EActivity ActivityType { get; set; }

    public override double Amount => Math.Round(this.UnitAmount * this.Duration * this.Rate, 2);

    public double Duration => Math.Round((this.EndDateTime - this.StartDateTime).TotalHours, 2);

    public Percentage Rate { get; set; } = 100;
}