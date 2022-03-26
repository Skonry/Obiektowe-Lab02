using System;
using System.Collections.Generic;

namespace Lab02
{
    class Compare : IComparer<Fraction>
    {
        int IComparer<Fraction>.Compare(Fraction fraction1, Fraction fraction2)
        {
            int commonDenominator = fraction1.Denominator * fraction2.Denominator;
            int thisNumerator = commonDenominator / fraction1.Denominator * fraction1.Numerator;
            int oterNumerator = commonDenominator / fraction2.Denominator * fraction2.Numerator;

            return thisNumerator - oterNumerator;
        }
    }

    class Fraction: IComparable<Fraction>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("denominator shouldn't be equal 0");
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public override String ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(Fraction otherFraction)
        {
            int commonDenominator = this.Denominator * otherFraction.Denominator;
            int thisNumerator = commonDenominator / this.Denominator * this.Numerator;
            int oterNumerator = commonDenominator / otherFraction.Denominator * otherFraction.Numerator;

            return thisNumerator - oterNumerator;

        }

        public Fraction Add(Fraction otherFraction)
        {
            int commonDenominator = this.Denominator * otherFraction.Denominator;
            int numerator1 = commonDenominator / this.Denominator * this.Numerator;
            int numerator2 = commonDenominator / otherFraction.Denominator * otherFraction.Numerator;

            return new Fraction(numerator1 + numerator2, commonDenominator);
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Add(fraction2);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int commonDenominator = fraction1.Denominator * fraction2.Denominator;
            int numerator1 = commonDenominator / fraction1.Denominator * fraction1.Numerator;
            int numerator2 = commonDenominator / fraction2.Denominator * fraction2.Numerator;

            return new Fraction(numerator1 - numerator2, commonDenominator);
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return fraction1 * fraction2.Inverse();
        }

        public Fraction Inverse()
        {
            return new Fraction(this.Denominator, this.Numerator);
        }

    }
}
