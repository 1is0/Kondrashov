﻿using System;

namespace People
{
    class Man
    {
        protected int age;

        public static int id;

        public string Name  { get; set; }
        public double WeightKilos { get; set; }
        public double HeightMeters { get; set; }
        public string CityBorn { get; set; }

        protected string[] hobbies;
        
        //Свойства для полей классов:

         //сделать автосвойства

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
        }

        public Man()
        {
            Name = "Vova";
            age = 19;
            WeightKilos = 81.7;
            HeightMeters = 1.874;
            CityBorn = "Grodno";
        }

        //конструктор для массива hobbies
        public Man(int n)
        {
            hobbies = new string[n];
        }

        public static void Show()
        {
            Console.WriteLine("id: " + id);
        }

        public override string ToString()
        {
            string info = "Name: " + Name + ";" + " Age: " + age + ";" + " Height: " + HeightMeters + ";" + " Weight: " + WeightKilos + ";" + " Hometown: " + CityBorn;
            return info;

        }

        public string this[int m]
        {
            get
            {
                return hobbies[m];
            }

            set
            {
                hobbies[m] = value;
            }
        }

        public void MassIndex()
        {
            double mass = WeightKilos / (Math.Pow(HeightMeters, 2));
            if (mass < 18.5)
            {
                Console.WriteLine("Your mass index testifies that you have lack of weight\n");
            }
            else
            {
                if (mass >= 18.5 && mass <= 24.9)
                {
                    Console.WriteLine("Your mass index testifies that your weight is normal\n");
                }
                else
                {
                    if (mass >= 24.9 && mass <= 29.9)
                    {
                        Console.WriteLine("Your mass index testifies that you are overweight\n");
                    }
                    else
                    {
                        Console.WriteLine("Yoy have an obesity\n");
                    }
                }
            }
        }
    }


}
