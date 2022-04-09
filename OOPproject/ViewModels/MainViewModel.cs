using OOPproject.Models;
using OOPproject.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPproject.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {

        public ObservableCollection<DisplayShape> ShapeCollection { get; set; } = new();


        private DisplayShape _selectedShape;

        public DisplayShape SelectedShape
        {
            get { return _selectedShape; }
            set
            {
                if (_selectedShape != value)
                {
                    _selectedShape = value;


                    if (_selectedShape != null)
                    {
                        ShouldButtonBeEnabled = true;
                        DisplayShapeOnCanvas();
                        Reset();
                    }
                    else
                    {
                        ShouldButtonBeEnabled = false;
                        Reset();
                    }

                    RaisePropertyChanged("ShouldButtonBeEnabled");
                    RaisePropertyChanged("SelectedShape");
                }
            }
        }



        private UserControl _selectedActionView;

        public UserControl SelectedActionView
        {
            get { return _selectedActionView; }
            set
            {
                if (value != _selectedActionView)
                {
                    _selectedActionView = value;
                    RaisePropertyChanged("SelectedActionView");
                }
            }
        }


        
        public MainViewModel()
        {
          
            BuildDrawCanvas();
            BuildGridCanvas();

            SelectedShape = null;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }



        #region Add Shape
        public void ShowAddMenu()
        {

            SelectedActionView = new AddView(this);

        }


        public void AddShape (DisplayShape ShapeToAdd)
        {
            ShapeCollection.Add(ShapeToAdd);

            SelectedShape=ShapeToAdd;

            SelectedActionView = null;

        }

        #endregion

        #region Remove Shape

        public void RemoveShape()
        {
            if (SelectedShape != null)
            {
                ShapeCollection.Remove(SelectedShape);

                SelectedShape = null;
            }

            DrawCanvas.Children.Clear();

        }
        #endregion

        #region Scale Shape

        public void ShowScaleMenu()
        {

            SelectedActionView = new ScaleView(this);

        }

        

        public void OkScale(ScalingVectorClass scalingVector)
        {   
            if (SelectedShape != null)
            {
                SelectedShape.ScaleShape(scalingVector);
                DisplayShapeOnCanvas();
            }

            
        }

        public void OkTranslate(TranslationVectorClass translationVector)
        {
            if (SelectedShape != null)
            {
                SelectedShape.TranslateShape(translationVector);
                DisplayShapeOnCanvas();
            }
        }



        #endregion

        public void ShowTranslateMenu()
        {
            SelectedActionView=new TranslateView(this);
        }

        //public void OkTranslation()
        //{
        //    int x = 0;

        //    int y = 0;


        //    //InputXstring = InputXstring.Replace(',', '.');
        //    //InputYstring = InputYstring.Replace(',', '.');

        //    //if (!int.TryParse(InputXstring, NumberStyles.Any, CultureInfo.InvariantCulture, out x))
        //    //{


        //    //    InputXstring = "";
        //    //    ErrorMessage = "Coordonata X nu este corecta";
        //    //    return;
        //    //}


        //    //if (!int.TryParse(InputYstring, NumberStyles.Any, CultureInfo.InvariantCulture, out y))
        //    //{
        //    //    InputYstring = "";
        //    //    ErrorMessage = "Coordonata y nu este corecta";
        //    //    return;
        //    //}



        //    //TranslationVector = new TranslationVectorClass(x, y);




        //    //SelectedShape.TranslateShape(TranslationVector);

        //    //DisplayShapeOnCanvas();

        //    //ScaleMenuVisibility = Visibility.Collapsed;

        //    //Reset();
        //}





        public void Reset()
        {
            SelectedActionView = null;

            if ( SelectedShape != null)
            {
                DisplayShapeOnCanvas();
            }

        }

    





        #region Display

        public void DisplayShapeOnCanvas()
        {   
            DrawCanvas.Children.Clear();

            if (SelectedShape != null)
            {
                DrawCanvas.Children.Add(SelectedShape.GetPolygon());
            }
            

        }


        private void BuildDrawCanvas()
        {
            DrawCanvas.Height = 600;
            DrawCanvas.Width = 800;
            DrawCanvas.Background = Brushes.Transparent;

        }

        private void BuildGridCanvas()
        {
            GridCanvas.Height = 600;
            GridCanvas.Width = 800;
            GridCanvas.Background = Brushes.DodgerBlue;

            for (int i = 0; i <= GridCanvas.Width; i += 25)
            {
                Polygon line = new Polygon();

                line.Stroke = Brushes.White;
                line.Fill = Brushes.White;

                if (i % 100 == 0)
                {
                    line.StrokeThickness = 2;
                }
                else
                {
                    line.StrokeThickness = 1;
                }


                Point p1 = new Point(i, 0);
                Point p2 = new Point(i, GridCanvas.Height);

                line.Points.Add(p1);
                line.Points.Add(p2);

                GridCanvas.Children.Add(line);

            }

            for (int i = 0; i <= GridCanvas.Height; i += 25)
            {
                Polygon line = new Polygon();

                line.Stroke = Brushes.White;
                line.Fill = Brushes.White;

                if (i % 100 == 0)
                {
                    line.StrokeThickness = 2;
                }
                else
                {
                    line.StrokeThickness = 1;
                }


                Point p1 = new Point(0, i);
                Point p2 = new Point(GridCanvas.Width, i);

                line.Points.Add(p1);
                line.Points.Add(p2);

                GridCanvas.Children.Add(line);
            }



        }


        #endregion





        public Canvas DrawCanvas { get; set; } = new Canvas();

        public Canvas GridCanvas { get; set; } = new Canvas();
        


        public bool ShouldButtonBeEnabled { get; set; } = false;

        
        // clasa pentru display
        public class DisplayShape : INotifyPropertyChanged
        {
            public string Name { get; set; } = string.Empty;

            public string TypeOfShape
            {
                get

                {
                    if (Shape == null)
                    {
                        return "Something Went Bad";
                    }
                    else
                    {
                        switch (Shape.ShapeCode)
                        {
                            case 0:
                                return "Point";
                                break;
                            case 1:
                                return "Horizontal Line";
                                break;
                            case 2:
                                return "Vertical Line";
                                break;
                            case 3:
                                return "Rectangle";
                                break;
                            default:
                                return "Undefined";
                                break;
                        }
                    }
                }

            }


            private ShapeClass _shape;

            public ShapeClass Shape
            {
                get { return _shape; }
                set
                {
                    if (_shape != value)
                    {
                        _shape = value;
                        RaisePropertyChanged("Shape");

                    }
                }
            }


            // shape este o clasa a .net-ului nu ShapeClass
            // am folosit-o pentru a acomoda si return de tip Polygon si de tip Line fiindca mostenesc amandoua din ea.
            public Shape GetPolygon()
            {
                Shape ReturnShape = null;

                if (Shape != null)
                {

                    if (Shape.ShapeCode == 0)
                    {
                        Polygon poly = new Polygon();

                        foreach (ShapeClass.CoordinatePair p in Shape.Display())
                        {
                            Point point = new Point(p.x_coord, p.y_coord);

                            poly.Points.Add(point);
                        }
                        poly.Stroke = Brushes.Black;
                        poly.Fill = Brushes.White;
                        poly.StrokeThickness = 5;



                        ReturnShape = poly;

                    }
                    else if (Shape.ShapeCode == 1)
                    {
                        Line l = new Line();

                        l.X1 = Shape.Display()[0].x_coord;
                        l.Y1 = Shape.Display()[0].y_coord;
                        l.X2 = Shape.Display()[1].x_coord;
                        l.Y2 = Shape.Display()[1].y_coord;


                        l.StrokeThickness = 3;
                        l.Stroke = Brushes.Black;

                        ReturnShape = l;
                    }
                    else if(Shape.ShapeCode == 2)
                    {
                        Line l = new Line();

                        l.X1 = Shape.Display()[0].x_coord;
                        l.Y1 = Shape.Display()[0].y_coord;
                        l.X2 = Shape.Display()[1].x_coord;
                        l.Y2 = Shape.Display()[1].y_coord;


                        l.StrokeThickness = 3;
                        l.Stroke = Brushes.Black;
                        

                        ReturnShape = l;
                    }
                    else if(Shape.ShapeCode == 3)
                    {
                        Polygon poly = new Polygon();

                        foreach (ShapeClass.CoordinatePair p in Shape.Display())
                        {
                            Point point = new Point(p.x_coord, p.y_coord);

                            poly.Points.Add(point);
                        }
                        poly.Stroke = Brushes.Black;
                        poly.Fill = Brushes.White;
                        poly.StrokeThickness = 2;



                        ReturnShape = poly;

                    }
                    else
                    {
                        return null;
                    }

                }

                

                return ReturnShape;
            }


            public void ScaleShape(ScalingVectorClass scalingVector)
            {
                switch (Shape.ShapeCode)
                {
                    case 0:

                        Shape = (PointClass)Shape * scalingVector;
                        break;
                    case 1:
                        Shape = (HorizontalLineClass)Shape * scalingVector;
                        break;
                    case 2:
                        Shape = (VerticalLineClass)Shape * scalingVector;
                        break;
                    case 3:
                        Shape = (RectangleClass)Shape * scalingVector;
                        break;
                    default:
                        break;
                }
            }

            public void TranslateShape(TranslationVectorClass translationVector)
            {
                switch (Shape.ShapeCode)
                {
                    case 0:

                        Shape = (PointClass)Shape + translationVector;
                        break;
                    case 1:
                        Shape = (HorizontalLineClass)Shape + translationVector;
                        break;
                    case 2:
                        Shape = (VerticalLineClass)Shape + translationVector;
                        break;
                    case 3:
                        Shape = (RectangleClass)Shape + translationVector;
                        break;
                    default:
                        break;
                }
            }



            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }

        }

    }
}
