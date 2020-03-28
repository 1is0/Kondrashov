using System;
using System.Threading;
using System.Globalization;

namespace BaseClasses
{
    class Functions
    {
        CultureInfo ci = new CultureInfo("en-US");

        public bool ValidateInfo()
        {
            Console.WriteLine("Введите язык в формате: en-английский,es-испанский,fr-французский,ru-русский ");
            string language = Console.ReadLine();


            try
            {
                ci = new CultureInfo(language);
            }
            catch (Exception ex)//обработка исключений всех типов
            {
                return false;
            }

            return true;
        }

        public void Translate()
        {
            DateTime now = new DateTime(2020, 1, 1);


            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine(now.ToString("MMMM",ci));
                now = now.AddMonths(1);
            }

        }
    }
}

