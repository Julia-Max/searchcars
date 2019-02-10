using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchCars
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\User\source\repos\searchCars\searchCars\carNumbers.txt";
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            ListCarNumbers cars = initialzeCars();

            startMenu();

            void startMenu()
            {
                bool repeat = true;
                do
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Search number.");
                    Console.WriteLine("2. Exit");
                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine("Enter car number");
                            string carNumberForSearch = Console.ReadLine();

                            // find car number
                            showResults(cars.findCarNumbers(carNumberForSearch));
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "2":
                            repeat = false;
                            break;
                    }
                } while (repeat == true);
            }

            void showResults(List<CarNumber> result)
            {
                if (result.Count() == 0)
                {
                    Console.WriteLine("Nothing has found");
                }
                else
                {
                    Console.WriteLine("{0} result's founded:", result.Count());
                    foreach (CarNumber number in result)
                    {
                        Console.WriteLine(number.getCarNumber());
                    }
                }
            }

            ListCarNumbers initialzeCars()
            {
                ListCarNumbers carList = new ListCarNumbers();

                foreach (var line in lines)
                {
                    CarNumber carNumber = new CarNumber();
                    carNumber.setCarNumber(line);
                    carList.addCarNumber(carNumber);
                }

                return carList;
            }
        }
    }
}
