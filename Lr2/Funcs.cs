using System;
using System.Threading;
using System.Globalization;

namespace BaseClasses
{
    class Funcs
    {
        public bool ValidateInfo()
        {
            Console.WriteLine("Введите язык в формате: es-английский,fr-французский,ru-русский и т.д.");
            string languange = Console.ReadLine();


            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(languange);//локально меняем язык windows на выбранный пользователем,так же здесь создаем объект CurrentCulture типа CultureInfo,передавая в конструктор languange строкового типа
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
                Console.WriteLine(now.ToString("MMMM"));
                now = now.AddMonths(1);
            }

        }
    }
}

