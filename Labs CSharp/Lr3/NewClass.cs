using System;

namespace People

{
    class NewClass
    {
        static void Main()
        {
            //работа со статическим элементом
            Man.id = 8976543;
            Man.Show();
            Console.WriteLine();

            
            
            //перегрузка стандартного метода ToString
            Man person = new Man();
            Console.WriteLine(person);
            //использование метода
            person.MassIndex();
            Console.WriteLine();

            Console.WriteLine("Example of properties using: \n");
            person.Name = "Vasya";
            person.Age = 20;
            person.CityBorn = "Minsk";
            person.HeightMeters = 1.901;
            person.WeightKilos = 90.2;
            Console.WriteLine(person);
            person.MassIndex();
            Console.WriteLine();

            //использование индексатора
            Man personHobbie = new Man(3);
            personHobbie[0] = "Football";
            personHobbie[1] = "Assembly of Rubik's Cube";
            personHobbie[2] = "Table tennis";
            Console.WriteLine("Hobbies: " + personHobbie[0] + "," + personHobbie[1] + "," + personHobbie[2]);
            Console.WriteLine();            

            Console.ReadKey();
        }
    }

}
