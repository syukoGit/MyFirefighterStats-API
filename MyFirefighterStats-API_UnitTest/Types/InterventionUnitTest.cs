// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API_UnitTest" file="InterventionUnitTest.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Types;

using System;
using MyFirefighterStats.API.Attributes;
using Xunit;

public sealed class InterventionUnitTest
{
    [Theory]
    [CsvData(@"Types/TestData/Interventions.csv")]
    public void CalculateDurations(string strStartDateTime, string strEndDateTime, double dayDuration, double nightDuration, double sundayDuration)
    {
        DateTime starDateTime = DateTime.Parse(strStartDateTime);
        DateTime endDateTime = DateTime.Parse(strEndDateTime);

        Intervention intervention = new ()
        {
            StartDateTime = starDateTime,
            EndDateTime = endDateTime,
        };

        Assert.Equal(dayDuration, intervention.DayDuration);
        Assert.Equal(nightDuration, intervention.NightDuration);
        Assert.Equal(sundayDuration, intervention.SundayDuration);
    }
}