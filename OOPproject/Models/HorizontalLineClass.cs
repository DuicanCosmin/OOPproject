using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class HorizontalLineClass : ShapeClass
    {
        public override int? ShapeCode { get; set; }

        public PointClass LeftPoint { get; set; }

        public PointClass RightPoint { get; set; }


        public HorizontalLineClass(int x_leftCoordinate, int x_rightCoordinate, int y_coord)
        {
            ShapeCode = 1;

            LeftPoint = new PointClass(x_leftCoordinate, y_coord);
            RightPoint = new PointClass(x_rightCoordinate, y_coord);

        }

        public HorizontalLineClass(PointClass InputLeftPoint, PointClass InputRightPoint)
        {
            ShapeCode = 1;
            LeftPoint = InputLeftPoint;
            RightPoint = InputRightPoint;
        }


        #region Scaling

        internal override HorizontalLineClass Scale(ScalingVectorClass ScalingVector)
        {

            int Scaled_x_RightCoordinate = (int)(ScalingVector.X_factor * RightPoint.x_coord);
            int Scaled_x_LeftCoordinate = LeftPoint.x_coord;

            int Scaled_y_coord = LeftPoint.y_coord;

            return new HorizontalLineClass(Scaled_x_LeftCoordinate,Scaled_x_RightCoordinate,Scaled_y_coord);
        }

        public static HorizontalLineClass operator * (HorizontalLineClass shape,ScalingVectorClass ScalingVector)
        {

            return shape.Scale(ScalingVector);
        }

        #endregion

        #region Translation

        internal override HorizontalLineClass Translate(TranslationVectorClass TranslateVector)
        {
            int Translated_x_leftCoordinate = TranslateVector.X_distance + LeftPoint.x_coord;
            int Translated_x_rightCoordinate = TranslateVector.X_distance + RightPoint.x_coord;
            int Translated_y_coord = TranslateVector.Y_distance + LeftPoint.y_coord;

            return new HorizontalLineClass(Translated_x_leftCoordinate, Translated_x_rightCoordinate, Translated_y_coord);
        }

        public static HorizontalLineClass operator +(HorizontalLineClass shape, TranslationVectorClass TranslationVectror)
        {
            return shape.Translate(TranslationVectror);
        }

        #endregion  

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
