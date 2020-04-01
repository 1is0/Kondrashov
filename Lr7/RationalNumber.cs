using System;

namespace Laboratory7
{
    class RationalNumber : IComparable, IEquatable<RationalNumber>
    {
        public int Nint { get; set; }
        public uint Mnat { get; set; }
        double rnumber;

        public RationalNumber()
        {
            Nint = 0;
            Mnat = 1;
            rnumber = 0;
        }

        public static RationalNumber operator +(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Nint = (int)(tmp1.Mnat * tmp2.Mnat + tmp2.Nint * tmp1.Mnat);
            num.Mnat = tmp1.Mnat * tmp2.Mnat;
            num.rnumber = tmp1.rnumber + tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator -(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Nint = (int)(tmp1.Nint * tmp2.Mnat - tmp2.Nint * tmp1.Mnat);
            num.Mnat = tmp1.Mnat * tmp2.Mnat;
            num.rnumber = tmp1.rnumber - tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator *(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Nint = tmp1.Nint * tmp2.Nint;
            num.Mnat = tmp1.Mnat * tmp2.Mnat;
            num.rnumber = tmp1.rnumber * tmp2.rnumber;
            return num;
        }

        public static RationalNumber operator /(RationalNumber tmp1, RationalNumber tmp2)
        {
            RationalNumber num = new RationalNumber();
            num.Nint = (int)(tmp1.Nint * tmp2.Mnat);
            num.Mnat = (uint)(tmp1.Mnat * tmp2.Nint);
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
            return this.rnumber == num.rnumber;
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
            return $"{Nint}/{Mnat}";
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
                obj.Nint = (int)a;
                obj.Mnat = 1;
            }
            else
            {
                for (int i = 0; (float)a % 10 != 0 || Math.Abs(a) < 1; i++)
                {
                    a *= 10;
                    count++;
                }
                a /= 10;
                obj.Nint = (int)a;
                obj.Mnat = (uint)Math.Pow(10, count);

            }
            return obj;
        }

        public static RationalNumber GetFractionObjectFromString(string str)
        {
            RationalNumber obj = new RationalNumber();

            try
            {
                string[] arr = str.Split('/');

                obj.Nint = int.Parse(arr[0]);
                obj.Mnat = uint.Parse(arr[1]);
                obj.rnumber = obj.Nint / obj.Mnat;
            }

            catch
            {
                obj.Nint = int.Parse(str);
                obj.Mnat = 1;
                obj.rnumber = obj.Nint / obj.Mnat;
            }

            return obj;
        }
    }
}
