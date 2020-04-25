using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Auto
{
    class Car
    {
        public string mark = "";
        public string model = "";
        public int price = 0;
    }

    static class Autos
    {

        static public int Size;
        static public List<Car> CarShop = new List<Car>();
        static public void Cars()
        {
            Console.Write("Размер массива = ");
            Size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Size; i++)
            {
                Car TempCar = new Car();
                Console.Write("Марка машины №" + i + " = ");
                TempCar.mark = Console.ReadLine().ToString();
                Console.Write("Модель машины №" + i + " = ");
                TempCar.model = Console.ReadLine().ToString();
                bool hasLetters;
                do
                {
                    Console.Write("Цена машины №" + i + " = ");
                    string t = Console.ReadLine();
                    hasLetters = t.AsEnumerable().Any(ch => char.IsLetter(ch));
                    if (!hasLetters)
                        TempCar.price = Convert.ToInt32(t);
                    else
                    {
                        Console.Write("Цена не должна содержать буквы. Только цифры. Повторите ввод цены для машины №" + i + " = ");
                    }
                }
                while (hasLetters);
                CarShop.Add(TempCar);
            }
        }
        static public void Sort()
        {
            CarShop.OrderBy(r => r.price).ThenBy(r => r.model).ToArray();
        }
        static public void SaveInFile()
        {
            using (StreamWriter sw = new StreamWriter("CarShelf.txt"))
            {
                foreach (Car C in CarShop)
                    sw.WriteLine(C.model + ", " + C.mark + ", " + C.price.ToString());
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Autos.Cars();
            Autos.Sort();
            Autos.SaveInFile();
        }
    }
}
