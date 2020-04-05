using System;

namespace Laboratory7
{
    class RationalNumber : IComparable, IEquatable<RationalNumber>
    {
        public int Numerator { get; set; }
        public uint Denominator { get; set; }
        

        public RationalNumber()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public static RationalNumber operator +(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Denominator * tmp2.Denominator + tmp2.Numerator * tmp1.Denominator);
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            return num;
        }

        public static RationalNumber operator -(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Numerator * tmp2.Denominator - tmp2.Numerator * tmp1.Denominator);
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            return num;
        }

        public static RationalNumber operator *(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = tmp1.Numerator * tmp2.Numerator;
            num.Denominator = tmp1.Denominator * tmp2.Denominator;
            return num;
        }

        public static RationalNumber operator /(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Numerator = (int)(tmp1.Numerator * tmp2.Denominator);
            num.Denominator = (uint)(tmp1.Denominator * tmp2.Numerator);
            return num;
        }

        public static bool operator >(RationalNumber tmp1, RationalNumber tmp2)
        {
            if (tmp1.Numerator/tmp1.Denominator > tmp2.Numerator/tmp2.Denominator)
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
            if (tmp1.Numerator / tmp1.Denominator < tmp2.Numerator / tmp2.Denominator)
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
            if (tmp1.Numerator / tmp1.Denominator >= tmp2.Numerator / tmp2.Denominator)
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
            if (tmp1.Numerator / tmp1.Denominator <= tmp2.Numerator / tmp2.Denominator)
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
            if (tmp1.Numerator / tmp1.Denominator == tmp2.Numerator / tmp2.Denominator)
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
            if (tmp1.Numerator / tmp1.Denominator != tmp2.Numerator / tmp2.Denominator)
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
            return (Numerator/Denominator).GetHashCode();
        }

        public static implicit operator int(RationalNumber num)
        {
            return (int)(num.Numerator/num.Denominator);
        }

        public static implicit operator double(RationalNumber num)
        {
            return (num.Numerator/num.Denominator);
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
            if ((this.Numerator/this.Denominator) > 
                (((RationalNumber)obj).Numerator/((RationalNumber)obj).Denominator))
            {
                return 1;
            }
            if ((this.Numerator / this.Denominator) <
                (((RationalNumber)obj).Numerator / ((RationalNumber)obj).Denominator))
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
            return $"{Numerator/Denominator}";
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
            }

            catch
            {
                obj.Numerator = int.Parse(str);
                obj.Denominator = 1;
            }

            return obj;
        }
    }
}
