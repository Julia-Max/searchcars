using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchCars
{
    class CarNumber
    {
        private string carNumber;
        public void setCarNumber(string _carNumber)
        {
            this.carNumber = _carNumber;
        }

        public string getCarNumber()
        {
            return this.carNumber;
        }
    }
}
