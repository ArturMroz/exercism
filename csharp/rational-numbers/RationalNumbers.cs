using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private int num;
    private int den;

    public RationalNumber(int numerator, int denominator) : this()
    {
        if (denominator == 0) throw new DivideByZeroException();

        var gcd = GCD(numerator, denominator);
        this.num = numerator / gcd;
        this.den = denominator / gcd;
    }

    public RationalNumber Add(RationalNumber r) =>
        new RationalNumber(num * r.den + r.num * den, den * r.den);

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => r1.Add(r2);

    public RationalNumber Sub(RationalNumber r) =>
        new RationalNumber(num * r.den - r.num * den, den * r.den);

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1.Sub(r2);

    public RationalNumber Mul(RationalNumber r) =>
        new RationalNumber(num * r.num, den * r.den);

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => r1.Mul(r2);

    public RationalNumber Div(RationalNumber r) =>
        new RationalNumber(num * r.den, den * r.num);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => r1.Div(r2);
    
    public RationalNumber Abs() => new RationalNumber(Math.Abs(num), Math.Abs(den));

    public RationalNumber Reduce()
    {
        var gcd = this.GCD(num, den);
        return new RationalNumber(num / gcd, den / gcd);
    }

    public RationalNumber Exprational(int power)
    {
        if (power >= 0)
        {
            return new RationalNumber((int)Math.Pow(num, power), (int)Math.Pow(den, power));
        }
        else
        {
            power = Math.Abs(power);
            return new RationalNumber((int)Math.Pow(den, power), (int)Math.Pow(num, power));
        }
    }

    public double Expreal(int baseNumber) => Math.Pow(Math.Pow(baseNumber, num), 1.0 / den);

    private int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}