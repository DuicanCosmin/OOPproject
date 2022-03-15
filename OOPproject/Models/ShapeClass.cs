using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public abstract class ShapeClass
    {
        //public ShapeClass()
        //{

        //}

        abstract public int? ShapeCode { get;  set; }

        public abstract void Display();

        internal abstract ShapeClass Translate(TranslationVectorClass TranslateVector);

        internal abstract ShapeClass Scale(ScalingVectorClass ScalingVector);
   


    }


}
