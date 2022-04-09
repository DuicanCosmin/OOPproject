using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class VerticalLineClass : ShapeClass 
    {
        #region Properties
        public override int? ShapeCode { get; set; }

        public PointClass TopPoint { get; set; }

        public PointClass BottomPoint { get; set; }

        #endregion


        #region Constructor
        public VerticalLineClass(int y_topCoordinate,int y_bottomCoordinate,int x_coord)
        {
            ShapeCode = 2;

            TopPoint = new PointClass(x_coord, Math.Max(y_topCoordinate,y_bottomCoordinate));
            BottomPoint = new PointClass(x_coord, Math.Min(y_topCoordinate, y_bottomCoordinate)); 

        }

        

        public VerticalLineClass(PointClass InputTopPoint, PointClass InputBottomPoint)
        {
            ShapeCode = 2;

            if(InputTopPoint.y_coord >= InputBottomPoint.y_coord)
            {
                TopPoint = InputTopPoint.CloneShape();
                BottomPoint = InputBottomPoint.CloneShape();
            }
            else
            {

                TopPoint = InputBottomPoint.CloneShape(); 
                BottomPoint = InputTopPoint.CloneShape();
            }

        }


        public override VerticalLineClass CloneShape()
        {
            return new VerticalLineClass(TopPoint.y_coord, BottomPoint.y_coord, TopPoint.x_coord);
        }

        #endregion

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
            double height = Math.Abs(TopPoint.y_coord - BottomPoint.y_coord);

            height = height * (ScalingVector.Y_factor - 1);

            int Scaled_y_topCoordinate = (int)(TopPoint.y_coord+ height);

            int Scaled_y_bottomCoordinate = BottomPoint.y_coord;
            
            int Scaled_x_coord = TopPoint.x_coord;

            return new VerticalLineClass(Scaled_y_topCoordinate,Scaled_y_bottomCoordinate,Scaled_x_coord);
        }

        public static VerticalLineClass operator *(VerticalLineClass shape, ScalingVectorClass ScalingVector)
        {
            return shape.Scale(ScalingVector);
        }

        #endregion


        public override List<CoordinatePair> Display()
        {
            List<CoordinatePair> returnList = new List<CoordinatePair>();

            returnList.Add(new CoordinatePair(TopPoint.x_coord, TopPoint.y_coord));
            returnList.Add(new CoordinatePair(BottomPoint.x_coord, BottomPoint.y_coord));


            return returnList;
        }
    }
}
