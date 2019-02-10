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
            string fileName = "carNumbers.txt";
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\" + fileName;
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
                    Console.WriteLine("2. Run test cases");
                    Console.WriteLine("3. Exit");
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
                            startTests();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "3":
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

            void startTests()
            {
                bool testPassed = true;

                // test case 1
                string carNumber = "xxxxx";
                int expectedCount = 0;
                List<CarNumber> result = cars.findCarNumbers(carNumber);
                
                if (result.Count != expectedCount)
                {
                    testPassed = false;
                }


                // test case 2
                carNumber = "s129mk154";
                expectedCount = 1;
                result = cars.findCarNumbers(carNumber);
                if (result.Count != expectedCount)
                {
                    testPassed = false;
                }


                // test case 3
                carNumber = "154";
                expectedCount = 8;
                result = cars.findCarNumbers(carNumber);
                if (result.Count != expectedCount)
                {
                    testPassed = false;
                }

                if (testPassed) {
                    Console.WriteLine("Tests passed");
                } else
                {
                    Console.WriteLine("Tests failed");
                }
            }
        }
    }
}
