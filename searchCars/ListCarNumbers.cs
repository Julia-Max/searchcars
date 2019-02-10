using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchCars
{
    class ListCarNumbers
    {
        private List<CarNumber> listCarNumbers;

        public ListCarNumbers()
        {
            listCarNumbers = new List<CarNumber>();
        }

        public void addCarNumber(CarNumber _carNumber)
        {
            this.listCarNumbers.Add(_carNumber);
        }

        public List<CarNumber> findCarNumbers(string _number)
        {
            List<CarNumber> result = new List<CarNumber>();

            foreach (CarNumber number in listCarNumbers)
            {
                if (number.getCarNumber().Contains(_number))
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
