using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class VerticalLineClass : ShapeClass 
    {
        public override int? ShapeCode { get; set; }

        public PointClass TopPoint { get; set; }

        public PointClass BottomPoint { get; set; }

        public VerticalLineClass(int y_topCoordinate,int y_bottomCoordinate,int x_coord)
        {
            ShapeCode = 2;

            TopPoint = new PointClass(x_coord, y_topCoordinate);
            BottomPoint = new PointClass(x_coord, y_bottomCoordinate); 

        }

        public VerticalLineClass(PointClass InputTopPoint, PointClass InputBottomPoint)
        {
            ShapeCode = 2;
            TopPoint = InputTopPoint;
            BottomPoint = InputBottomPoint;
        }

        public override void Display()
        {
            System.Windows.MessageBox.Show(string.Concat("y Top=", TopPoint.y_coord.ToString(), " ", "y Bot=", BottomPoint.y_coord.ToString()," " , "x=",TopPoint.x_coord.ToString()));
        }

        #region Translation action

        internal override VerticalLineClass Translate(TranslationVectorClass TranslateVector)
        {
            int Translated_y_topCoordinate = TranslateVector.Y_distance+TopPoint.y_coord;
            int Translated_y_bottomCoordinate = TranslateVector.Y_distance+BottomPoint.y_coord;
            int Translated_x_coord = TranslateVector.X_distance+TopPoint.x_coord;

            return new VerticalLineClass(Translated_y_topCoordinate,Translated_y_bottomCoordinate,Translated_x_coord);
        }

        public static VerticalLineClass operator +(VerticalLineClass shape, TranslationVectorClass TranslationVectror)
        {
            return shape.Translate(TranslationVectror);
        }

        #endregion

        #region Scaling action

        internal override VerticalLineClass Scale(ScalingVectorClass ScalingVector)
        {
            int Scaled_y_topCoordinate = (int)(ScalingVector.Y_factor * TopPoint.y_coord);
            int Scaled_y_bottomCoordinate = BottomPoint.y_coord;
            
            int Scaled_x_coord = TopPoint.x_coord;

            return new VerticalLineClass(Scaled_y_topCoordinate,Scaled_y_bottomCoordinate,Scaled_x_coord);
        }

        public static VerticalLineClass operator *(VerticalLineClass shape, ScalingVectorClass ScalingVector)
        {
            return shape.Scale(ScalingVector);
        }

        #endregion

    }
}
