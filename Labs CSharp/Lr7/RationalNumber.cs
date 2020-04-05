using System;

namespace Laboratory7
{
    class RationalNumber : IComparable, IEquatable<RationalNumber>
    {
        public int Numerator { get; set; }
        public uint Denominator { get; set; }
        double rnumber;

        public RationalNumber()
        {
            Numerator = 0;
            Denominator = 1;
            rnumber = 0;
        }

        public static RationalNumber operator +(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Denominator * tmp2.Denominator + tmp2.Numerator * tmp1.Denominator);
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            num.rnumber = tmp1.rnumber + tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator -(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Numerator * tmp2.Denominator - tmp2.Numerator * tmp1.Denominator);
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            num.rnumber = tmp1.rnumber - tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator *(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = tmp1.Numerator * tmp2.Numerator;
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            num.rnumber = tmp1.rnumber * tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator /(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Numerator * tmp2.Denominator);
            num.Denominator = (uint)(tmp1.Denominator * tmp2.Numerator);
            num.rnumber = tmp1.rnumber / tmp2.rnumber;
            return num;
        }

        public static bool operator >(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber > tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber < tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber >= tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber <= tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber == tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.rnumber != tmp2.rnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return rnumber.GetHashCode();
        }

        public static implicit operator int(RationalNumber num)
        {
            return (int)num.rnumber;
        }

        public static implicit operator double(RationalNumber num)
        {
            return num.rnumber;
        }

        bool IEquatable<RationalNumber>.Equals(RationalNumber num)
        {
            if(this.Numerator==num.Numerator && this.Denominator==num.Denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            if (this.rnumber > ((RationalNumber)obj).rnumber)
            {
                return 1;
            }
            if (this.rnumber < ((RationalNumber)obj).rnumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public string NumberString()
        {
            return $"{rnumber}";
        }

        public string FractionString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public string ShowFull()
        {
            return "Number: " + NumberString() + "\nFraction: " + FractionString() + "\n";
        }

        public static RationalNumber GetNumberObjectFromString(string str)
        {
            RationalNumber obj = new RationalNumber();

            double a;
            double.TryParse(str, out a);
            obj.rnumber = a;


            int count = -1;
            if (a % 10 == 0)
            {
                obj.Numerator = (int)a;
                obj.Denominator = 1;
            }
            else
            {
                for (int i = 0; (float)a % 10 != 0 || Math.Abs(a) < 1; i++)
                {
                    a *= 10;
                    count++;
                }
                a /= 10;
                obj.Numerator = (int)a;
                obj.Denominator = (uint)Math.Pow(10, count);

            }
            return obj;
        }

        public static RationalNumber GetFractionObjectFromString(string str)
        {
            RationalNumber obj = new RationalNumber();

            try
            {
                string[] arr = str.Split('/');

                obj.Numerator = int.Parse(arr[0]);
                obj.Denominator = uint.Parse(arr[1]);
                obj.rnumber = obj.Numerator / obj.Denominator;
            }

            catch
            {
                obj.Numerator = int.Parse(str);
                obj.Denominator = 1;
                obj.rnumber = obj.Numerator / obj.Denominator;
            }

            return obj;
        }
    }
}
