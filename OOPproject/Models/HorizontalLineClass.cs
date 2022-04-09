using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class HorizontalLineClass : ShapeClass
    {

        #region Properties

        public override int? ShapeCode { get; set; }

        public PointClass LeftPoint { get; set; }

        public PointClass RightPoint { get; set; }

        #endregion

        #region Constructors 
        // constructor 1 ( coordonate)
        public HorizontalLineClass(int x_leftCoordinate, int x_rightCoordinate, int y_coord)
        {
            ShapeCode = 1;

            LeftPoint = new PointClass(Math.Min(x_leftCoordinate,x_rightCoordinate), y_coord);
            RightPoint = new PointClass(Math.Max(x_leftCoordinate, x_rightCoordinate), y_coord);

        }

        // constructor 2 ( puncte )
        public HorizontalLineClass(PointClass InputLeftPoint, PointClass InputRightPoint)
        {
            ShapeCode = 1;

            if (InputLeftPoint.x_coord <= InputRightPoint.x_coord)
            {
                LeftPoint = InputLeftPoint.CloneShape();
                RightPoint = InputRightPoint.CloneShape(); ;
            }
            else
            {
                LeftPoint = InputRightPoint.CloneShape();
                RightPoint = InputLeftPoint.CloneShape(); 
            }


        }

        // Clonare
        public override HorizontalLineClass CloneShape()
        {
            return new HorizontalLineClass(LeftPoint.x_coord,RightPoint.x_coord,LeftPoint.y_coord);
        }

        #endregion

        #region Scaling

        internal override HorizontalLineClass Scale(ScalingVectorClass ScalingVector)
        {

            double length = Math.Abs(RightPoint.x_coord - LeftPoint.x_coord);

            length = length * (ScalingVector.X_factor - 1);

            int Scaled_x_RightCoordinate = (int)(RightPoint.x_coord +length);
            int Scaled_x_LeftCoordinate = LeftPoint.x_coord;

            int Scaled_y_coord = LeftPoint.y_coord;

            return new HorizontalLineClass(Scaled_x_LeftCoordinate,Scaled_x_RightCoordinate,Scaled_y_coord);
        }

        //operator overloading scalare
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

        //operator overloading translatie
        public static HorizontalLineClass operator +(HorizontalLineClass shape, TranslationVectorClass TranslationVectror)
        {
            return shape.Translate(TranslationVectror);
        }

        #endregion

        public override List<CoordinatePair> Display()
        {
            List<CoordinatePair> returnList = new List<CoordinatePair>();

            

            returnList.Add(new CoordinatePair(this.LeftPoint.x_coord,this.LeftPoint.y_coord));
            returnList.Add(new CoordinatePair(this.RightPoint.x_coord,this.RightPoint.y_coord));
            

            return returnList;
        }
    }
}
