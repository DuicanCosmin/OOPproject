using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class TranslationVectorClass
    {


        // factorul de scalare este default unu deoarece 0 este element neutru pentru adunare.
        // astfel daca nu se dau parametrii corecti , operatia nu va modifica nimic

        public int X_distance { get; set; } = 0;
        public int Y_distance { get; set; } = 0;

        public TranslationVectorClass(int Input_x_distance=0,int Input_y_distance=0)
        {
            X_distance = Input_x_distance;
            Y_distance = Input_y_distance;
        }



        

    }
}
