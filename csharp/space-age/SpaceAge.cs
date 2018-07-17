using System;

public class SpaceAge
{
    private const long EarthYear = 31557600;
    private const double MercuryYear = EarthYear * 0.2408467;
    private const double VenusYear = EarthYear * 0.61519726;
    private const double MarsYear = EarthYear * 1.8808158;
    private const double JupiterYear = EarthYear * 11.862615;
    private const double SaturnYear = EarthYear * 29.447498;
    private const double UranusYear = EarthYear * 84.016846;
    private const double NeptuneYear = EarthYear * 164.79132;

    private readonly long seconds;

    public SpaceAge(long seconds) => this.seconds = seconds;

    private double calculateAge(double orbitalPeriod) =>
        Math.Round((double)seconds / orbitalPeriod, 2);

    public double OnEarth() => calculateAge(EarthYear);

    public double OnMercury() => calculateAge(MercuryYear);

    public double OnVenus() => calculateAge(VenusYear);

    public double OnMars() => calculateAge(MarsYear);

    public double OnJupiter() => calculateAge(JupiterYear);

    public double OnSaturn() => calculateAge(SaturnYear);

    public double OnUranus() => calculateAge(UranusYear);

    public double OnNeptune() => calculateAge(NeptuneYear);
}