using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class ScalingVectorClass
    {   

        // factorul de scalare este default unu deoarece 1 este element neutru pentru inmultire.
        // astfel daca nu se dau parametrii corecti , operatia nu va modifica nimic
        public double X_factor{ get; set; } = 1;
        public double Y_factor { get; set; } = 1;


        // constructor pentru scalare diferita pe axa x si pe axa y
        public ScalingVectorClass(double input_x_factor=1, double Input_y_factor=1)
        {
            X_factor = input_x_factor;
            Y_factor = Input_y_factor;
        }


        // constructor pentru scalare egala
        public ScalingVectorClass(double ScalingFactor=1)
        {
            X_factor = ScalingFactor;
            Y_factor = ScalingFactor;
        }

    }
}
