using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class RectangleClass : ShapeClass
    {
        #region Proprieries

        public override int? ShapeCode { get; set; }

        public HorizontalLineClass TopLine { get; set; }

        public HorizontalLineClass BottomLine { get; set; }

        public VerticalLineClass LeftLine { get; set; }

        public VerticalLineClass RightLine { get; set; }

        private int _length
        { get
            {
                return Convert.ToInt32( Math.Abs(TopLine.LeftPoint.x_coord - TopLine.RightPoint.x_coord));
            } 
        }

        private int _height
        {
            get
            {
                return Convert.ToInt32(Math.Abs(LeftLine.TopPoint.y_coord - LeftLine.BottomPoint.y_coord));
            }
        }
        #endregion

        #region Constructor
        public RectangleClass(PointClass TopPoint,int length, int height)
        {
            ShapeCode = 3;

            TopLine = new HorizontalLineClass(TopPoint,new PointClass(TopPoint.x_coord+length,TopPoint.y_coord));

            BottomLine = new HorizontalLineClass(new PointClass(TopPoint.x_coord, TopPoint.y_coord + height), new PointClass(TopPoint.x_coord + length, TopPoint.y_coord + height));

            LeftLine = new VerticalLineClass(TopLine.LeftPoint, BottomLine.LeftPoint);

            RightLine = new VerticalLineClass(TopLine.RightPoint, BottomLine.RightPoint);

        }

        public override RectangleClass CloneShape()
        {
            return new RectangleClass(TopLine.LeftPoint.CloneShape(), _length, _height);
        }


        #endregion

        #region Translation

        public static RectangleClass operator +(RectangleClass shape,TranslationVectorClass TranslationVector)
        {

            return shape.Translate(TranslationVector);
        }

        internal override RectangleClass Translate(TranslationVectorClass TranslateVector)
        {

            PointClass TranslatedTopPoint = new PointClass(TopLine.LeftPoint.x_coord+ TranslateVector.X_distance, TopLine.LeftPoint.y_coord + TranslateVector.Y_distance);

            RectangleClass TranslatedRectangle=new RectangleClass(TranslatedTopPoint,_length,_height);

            return TranslatedRectangle;
        }


        #endregion


        #region Scaling 


        internal override RectangleClass Scale(ScalingVectorClass ScalingVector)
        {
            int ScaledLength = Convert.ToInt32(_length * ScalingVector.X_factor);
            int ScaledHeight = Convert.ToInt32(_height * ScalingVector.Y_factor);



            return new RectangleClass(this.TopLine.LeftPoint, ScaledLength, ScaledHeight);
        }



        public static RectangleClass operator * (RectangleClass shape,ScalingVectorClass ScalingVector)
        {

            return shape.Scale(ScalingVector);
        }


        #endregion




        public override List<CoordinatePair> Display()
        {
            List<CoordinatePair> returnList = new List<CoordinatePair>();

            returnList.Add(new CoordinatePair(TopLine.LeftPoint.x_coord,TopLine.LeftPoint.y_coord));
            returnList.Add(new CoordinatePair(TopLine.RightPoint.x_coord,TopLine.RightPoint.y_coord));
            returnList.Add(new CoordinatePair(BottomLine.RightPoint.x_coord, BottomLine.RightPoint.y_coord));
            returnList.Add(new CoordinatePair(BottomLine.LeftPoint.x_coord, BottomLine.LeftPoint.y_coord));

            return returnList;
        }

    }
}
