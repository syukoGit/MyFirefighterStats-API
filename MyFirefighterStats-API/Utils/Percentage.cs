// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="Percentage.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Utils;

public readonly struct Percentage
{
    private readonly double value;

    private Percentage(double value) => this.value = value;

    public static implicit operator Percentage(double value) => new (value);

    public static implicit operator double(Percentage percentage) => percentage.value;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Percentage other && this.Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => this.value.GetHashCode();

    public static bool operator ==(Percentage left, Percentage right) => left.Equals(right);

    public static bool operator !=(Percentage left, Percentage right) => !(left == right);

    public static double operator *(Percentage left, double right) => right * left.value / 100;

    public static double operator *(double left, Percentage right) => left * right.value / 100;

    private bool Equals(Percentage other) => this.value.Equals(other.value);
}