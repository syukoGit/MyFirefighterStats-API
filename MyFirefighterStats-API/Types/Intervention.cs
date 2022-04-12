// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="Intervention.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Types;

using MyFirefighterStats.API.Utils;

public sealed class Intervention : Activity
{
    private static readonly Percentage DAY_RATE = 100;

    private static readonly Percentage NIGHT_RATE = 200;

    private static readonly Percentage SUNDAY_RATE = 150;

    private DateTime endDateTime;

    private EActivity firefighterActivity;

    private DateTime startDateTime;

    /// <inheritdoc />
    public override EActivity ActivityType
    {
        get => this.firefighterActivity;

        set => this.firefighterActivity = value switch
        {
            EActivity.Sap or EActivity.Fire or EActivity.Apr or EActivity.AprAndFire or EActivity.Other => value,
            EActivity.FirefighterActivity or _ => throw new ArgumentException($"ActivityType cannot be set to {value}", nameof(value)),
        };
    }

    /// <inheritdoc />
    public override double Amount
    {
        get
        {
            double totalHours = this.DayDuration * DAY_RATE + this.SundayDuration * SUNDAY_RATE + this.NightDuration * NIGHT_RATE;

            return Math.Round(totalHours * this.UnitAmount, 2);
        }
    }

    public double DayDuration { get; private set; }

    /// <inheritdoc />
    public override DateTime EndDateTime
    {
        get => this.endDateTime;

        set
        {
            this.endDateTime = value;
            this.CalculateDurations();
        }
    }

    public double NightDuration { get; private set; }

    /// <inheritdoc />
    public override DateTime StartDateTime
    {
        get => this.startDateTime;

        set
        {
            this.startDateTime = value;
            this.CalculateDurations();
        }
    }

    public double SundayDuration { get; private set; }

    private void CalculateDurations()
    {
        DateTime dtTemp = this.startDateTime;

        var day = new TimeSpan(0, 0, 0, 0);
        var night = new TimeSpan(0, 0, 0, 0);
        var sunday = new TimeSpan(0, 0, 0, 0);

        double dayDuration = 0;
        double nightDuration = 0;
        double sundayDuration = 0;

        var bonusGiven = false;

        double bonus = this.startDateTime.Date < new DateTime(2020, 3, 1)
                           ? 0.5
                           : 0;

        while (dtTemp < this.endDateTime)
        {
            int minutes = dtTemp.Date == this.endDateTime.Date && dtTemp.Hour == this.endDateTime.Hour
                              ? this.endDateTime.Minute - dtTemp.Minute
                              : 60 - dtTemp.Minute;

            if (dtTemp.Hour is < 7 or >= 22)
            {
                night = night.Add(new TimeSpan(0, 0, minutes, 0, 0));

                if (!bonusGiven)
                {
                    nightDuration += bonus;
                    bonusGiven = true;
                }
            }
            else if (dtTemp.DayOfWeek == DayOfWeek.Sunday)
            {
                sunday = sunday.Add(new TimeSpan(0, 0, minutes, 0, 0));

                if (!bonusGiven)
                {
                    sundayDuration += bonus;
                    bonusGiven = true;
                }
            }
            else
            {
                day = day.Add(new TimeSpan(0, 0, minutes, 0, 0));

                if (!bonusGiven)
                {
                    dayDuration += bonus;
                    bonusGiven = true;
                }
            }

            dtTemp = dtTemp.AddMinutes(minutes);

            if (dtTemp.Hour != 0)
            {
                continue;
            }

            nightDuration += Math.Round(night.TotalHours, 2);
            dayDuration += Math.Round(day.TotalHours, 2);
            sundayDuration += Math.Round(sunday.TotalHours, 2);

            night = TimeSpan.Zero;
            day = TimeSpan.Zero;
            sunday = TimeSpan.Zero;
        }

        dayDuration += Math.Round(day.TotalHours, 2);
        nightDuration += Math.Round(night.TotalHours, 2);
        sundayDuration += Math.Round(sunday.TotalHours, 2);

        this.DayDuration = Math.Round(dayDuration, 2);
        this.NightDuration = Math.Round(nightDuration, 2);
        this.SundayDuration = Math.Round(sundayDuration, 2);
    }
}