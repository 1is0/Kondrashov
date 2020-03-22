﻿using System;

namespace BaseClasses
{
    class WorkWithClasses
    {
        static void Main()
        {
            Funcs func=new Funcs();

            Console.WriteLine("Выполнение 2 пункта: ");

            Console.Write("Введите строку :");
            string f = Console.ReadLine();

            string[] slova = f.Split(' ', ',', '.', '!');//разбиваем строку на слова
            string inverse = "";
            for (int i = slova.Length - 1; i >= 0; i--)//у каждого массива в c# есть метод .Length(этот метод возвращает кол-во элементов с отсчетом от 1,здесь же нужно от 0,т.к массив)
            {
                inverse = inverse + " " + slova[i];
            }
            Console.WriteLine(inverse);
            Console.Write("\n\n\n");

            Console.WriteLine("Выполнение 7 пункта: ");

            Console.Write("Введите строку :");
            string str = Console.ReadLine();
            int a = str.Length;
            Console.WriteLine("Вывод номеров символов в строке по порядку: ");
            for (int i = 1; i <= a; i++)
            {
                Console.Write("{0:X4} ", i);
            }
            Console.WriteLine();

            Console.WriteLine("Вывод кодов символов в шестнадцатеричной системе: ");
            foreach (var ch in str)
            {
                Console.Write("'{0}' ", Convert.ToUInt16(ch).ToString("X4"));
            }

            Console.WriteLine("\n\n");

            Console.WriteLine("Выполнение 8 пункта: ");

            while (!func.ValidateInfo())
            {
                Console.WriteLine("Язык введен не в верном формате");
            }

            func.Translate();


            Console.ReadKey();
        }


    }
}
