using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public abstract class ShapeClass
    {


        abstract public int? ShapeCode { get;  set; }

        public abstract List<CoordinatePair> Display();

        internal abstract ShapeClass Translate(TranslationVectorClass TranslateVector);

        internal abstract ShapeClass Scale(ScalingVectorClass ScalingVector);


        public struct CoordinatePair
        {

            public CoordinatePair(int X, int Y)
            {
                x_coord = X;
                y_coord = Y;
            }

            public int x_coord { get; set; }
            public int y_coord { get; set; }
        }

        public abstract ShapeClass CloneShape();

        ~ShapeClass ()
        {
            // aici este destructorul, el este apelat de catre garbage collector-ul din C# in mod automat
            
        }

    }


}
