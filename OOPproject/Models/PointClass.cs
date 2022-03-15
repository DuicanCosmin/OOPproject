﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class PointClass : ShapeClass
    {
        public int x_coord { get; set; }
        public int y_coord { get; set; }
        public override int? ShapeCode { get; set; }

        public PointClass(int x_coord, int y_coord)
        {
            ShapeCode = 0;

            this.x_coord = x_coord;
            this.y_coord = y_coord;
        }

        

        public override void Display()
        {
            // de modificat
            System.Windows.MessageBox.Show(string.Concat("x=", x_coord.ToString()," ", "y=" , y_coord.ToString()));
        }

        #region Translation region

        internal override PointClass Translate(TranslationVectorClass TranslateVector)
        {
            int TranslatedX = TranslateVector.X_distance + x_coord;
            int TranslatedY = TranslateVector.Y_distance + y_coord;

            return new PointClass(TranslatedX, TranslatedY);

        }

        public static PointClass operator +(PointClass shape, TranslationVectorClass TranslationVectror)
        {
            return shape.Translate(TranslationVectror);
        }

        #endregion

        #region Scaling action

        internal override PointClass Scale(ScalingVectorClass ScalingVector)
        {
            return this;
        }


        public static PointClass operator *(PointClass shape, ScalingVectorClass ScalingVector)
        {
            return shape.Scale(ScalingVector);
        }

        #endregion



    }


}
