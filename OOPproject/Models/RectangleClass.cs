using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.Models
{
    public class RectangleClass : ShapeClass
    {
        public override int? ShapeCode { get; set; }

        public HorizontalLineClass TopLine { get; set; }

        public HorizontalLineClass BottomLine { get; set; }

        public VerticalLineClass LeftLine { get; set; }

        public VerticalLineClass RightLine { get; set; }

        private int _length;

        private int _height;

        public RectangleClass(PointClass TopPoint,int length, int height)
        {
            ShapeCode = 3;

            TopLine = new HorizontalLineClass(TopPoint,new PointClass(TopPoint.x_coord+length,TopPoint.y_coord));

            BottomLine = new HorizontalLineClass(new PointClass(TopPoint.x_coord, TopPoint.y_coord - height), new PointClass(TopPoint.x_coord + length, TopPoint.y_coord - height));

            LeftLine = new VerticalLineClass(TopLine.LeftPoint, BottomLine.LeftPoint);

            RightLine = new VerticalLineClass(TopLine.RightPoint, BottomLine.RightPoint);

            _height = height;

            _length = length;

            //BottomLine = new HorizontalLineClass(TopPoint.x_coord, TopPoint.x_coord + length, TopPoint.y_coord - height);
            

        }

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




        public override void Display()
        {
            string outputstring = "";

            outputstring += "Top left point x=" + TopLine.LeftPoint.x_coord.ToString() + " y=" + TopLine.LeftPoint.y_coord.ToString();
            outputstring += "Top right point x=" + TopLine.RightPoint.x_coord.ToString() + " y=" + TopLine.RightPoint.y_coord.ToString();
            outputstring += "Bottom left point x=" + BottomLine.LeftPoint.x_coord.ToString() + " y=" + BottomLine.LeftPoint.y_coord.ToString();
            outputstring += "Bottom right point x=" + BottomLine.RightPoint.x_coord.ToString() + " y=" + TopLine.RightPoint.y_coord.ToString();

            System.Windows.MessageBox.Show("");
        }

        public string DisplayString()
        {
            string outputstring = "";

            outputstring += "Top left point x=" + TopLine.LeftPoint.x_coord.ToString() + " y=" + TopLine.LeftPoint.y_coord.ToString() +Environment.NewLine;
            outputstring += "Top right point x=" + TopLine.RightPoint.x_coord.ToString() + " y=" + TopLine.RightPoint.y_coord.ToString() + Environment.NewLine;
            outputstring += "Bottom left point x=" + BottomLine.LeftPoint.x_coord.ToString() + " y=" + BottomLine.LeftPoint.y_coord.ToString() + Environment.NewLine;
            outputstring += "Bottom right point x=" + BottomLine.RightPoint.x_coord.ToString() + " y=" + BottomLine.RightPoint.y_coord.ToString();

            return outputstring;
        }
    }
}
