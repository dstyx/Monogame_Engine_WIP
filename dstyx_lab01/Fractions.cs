using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dstyx_lab01
{
    public struct Fractions
    {
        // variables

        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; Simplify(); }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; Simplify(); }
        }
        // constructor

        public Fractions(int n = 0, int d = 1)
        {
            numerator = n;
            if (d == 0)
                d = 1;
            denominator = d;
            Simplify();
        }



        //methods


        public override string ToString()
        {





            return numerator + "/" + denominator;
        }

        private void Simplify()
        {
            int smaller, larger;

            if(denominator < 0)
            {
                denominator *= -1;
                numerator *= -1;
            }

            smaller = numerator;
            larger = denominator;
            if(numerator> denominator)
            {
                smaller = denominator;
                larger = numerator;
            }


            int gcd = GCD(larger, smaller);
            numerator /= gcd;
            denominator /= gcd;
        }


        private static int GCD(int larger, int smaller)
        {
            if (smaller == 0)
                return larger;
            else
            {
                return GCD(smaller, larger%smaller);
            }
            
            
        }



        /*
        public static Fractions Multiply(Fractions lhs, Fractions rhs)
        {
            return new Fractions(lhs.numerator * rhs.numerator, lhs.denominator*rhs.numerator);
        }
        */

        public static Fractions operator * (Fractions lhs, Fractions rhs)
        {
            return new Fractions(lhs.numerator * rhs.numerator, lhs.denominator * rhs.denominator);
        }

        public static Fractions operator / (Fractions lhs, Fractions rhs)
        {
            return new Fractions(lhs.numerator * rhs.denominator, lhs.denominator * lhs.numerator);
        }

        public static Fractions operator +  (Fractions lhs, Fractions rhs)
        {

            int num = lhs.numerator * rhs.denominator + rhs.numerator * lhs.denominator; //adds the numerators after multiplying by the opposite denominator

            int den = lhs.denominator * rhs.denominator;//finds the denominator

            return new Fractions(num, den);
        }


        public static Fractions operator - (Fractions lhs, Fractions rhs)
        {
            int num = lhs.numerator * rhs.denominator - rhs.numerator * lhs.denominator;
            int den = lhs.denominator * rhs.denominator;


            return new Fractions(num, den);
        }
    }


}
