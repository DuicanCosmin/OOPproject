using OOPproject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static OOPproject.ViewModels.MainViewModel;

namespace OOPproject.ViewModels
{
    public class AddViewModel : BaseActionViewModel
    {
        public ObservableCollection<string> ShapeTypesList { get; set; } = new ObservableCollection<string>();

        public List<ValueFieldsClass> FieldList { get; set; } = new List<ValueFieldsClass>();

        private string _selectedShapeType = "";

        public string SelectedShapeType
        {
            get { return _selectedShapeType; }
            set
            {
                if (value != _selectedShapeType)
                {
                    _selectedShapeType = value;
                    RaisePropertyChanged("SelectedShapeType");
                    ResetSelection();
                }
            }
        }
        






        public AddViewModel(MainViewModel parentViewModel) : base(parentViewModel)
        {
            ShapeTypesList.Add("Point");
            ShapeTypesList.Add("Vertical Line");
            ShapeTypesList.Add("Horizontal Line");
            ShapeTypesList.Add("Rectangle");

            for (int i = 0; i < 4; i++)
            {
                ValueFieldsClass valueField = new ValueFieldsClass();

                FieldList.Add(valueField);
            }

            ResetSelection();

        }




        private string _shapeName="";

        public string ShapeName
        {
            get { return _shapeName; }
            set
            {
                if (_shapeName != value)
                {
                    _shapeName = value;
                    RaisePropertyChanged("ShapeName");
                }
            }
        }




        public void ResetSelection()
        {   

            ErrorMessage = "";

            ActionHeader = "Add a new shape";

            if (SelectedShapeType == "Point")
            {
                FieldList[0].FieldValue = "0";
                FieldList[0].FieldName = "Coord X=";
                FieldList[0].FieldVisibility = Visibility.Visible;

                FieldList[1].FieldValue = "0";
                FieldList[1].FieldName = "Coord Y=";
                FieldList[1].FieldVisibility = Visibility.Visible;


                FieldList[2].FieldValue = "";
                FieldList[2].FieldName = "";
                FieldList[2].FieldVisibility = Visibility.Hidden;

                FieldList[3].FieldValue = "";
                FieldList[3].FieldName = "";
                FieldList[3].FieldVisibility = Visibility.Hidden;

            }
            else if (SelectedShapeType == "Vertical Line")
            {
                FieldList[0].FieldValue = "0";
                FieldList[0].FieldName = "Coord X=";
                FieldList[0].FieldVisibility = Visibility.Visible;

                FieldList[1].FieldValue = "0";
                FieldList[1].FieldName = "Coord Y1=";
                FieldList[1].FieldVisibility = Visibility.Visible;

                FieldList[2].FieldValue = "0";
                FieldList[2].FieldName = "Coord Y2=";
                FieldList[2].FieldVisibility = Visibility.Visible;

                FieldList[3].FieldValue = "";
                FieldList[3].FieldName = "";
                FieldList[3].FieldVisibility = Visibility.Hidden;


            }
            else if (SelectedShapeType == "Horizontal Line")
            {
                FieldList[0].FieldValue = "0";
                FieldList[0].FieldName = "Coord X1=";
                FieldList[0].FieldVisibility = Visibility.Visible;

                FieldList[1].FieldValue = "0";
                FieldList[1].FieldName = "Coord X2=";
                FieldList[1].FieldVisibility = Visibility.Visible;

                FieldList[2].FieldValue = "0";
                FieldList[2].FieldName = "Coord Y=";
                FieldList[2].FieldVisibility = Visibility.Visible;

                FieldList[3].FieldValue = "";
                FieldList[3].FieldName = "";
                FieldList[3].FieldVisibility = Visibility.Hidden;

            }
            else if (SelectedShapeType == "Rectangle")
            {
                FieldList[0].FieldValue = "0";
                FieldList[0].FieldName = "Top Coord X=";
                FieldList[0].FieldVisibility = Visibility.Visible;

                FieldList[1].FieldValue = "0";
                FieldList[1].FieldName = "Top Coord Y=";
                FieldList[1].FieldVisibility = Visibility.Visible;

                FieldList[2].FieldValue = "0";
                FieldList[2].FieldName = "Length=";
                FieldList[2].FieldVisibility = Visibility.Visible;

                FieldList[3].FieldValue = "0";
                FieldList[3].FieldName = "Height=";
                FieldList[3].FieldVisibility = Visibility.Visible;

            }
            else
            {
                ShapeName="";

                foreach (ValueFieldsClass item in FieldList)
                {
                    item.FieldValue = "";
                    item.FieldVisibility = Visibility.Hidden;
                    item.FieldName = "";
                }
            }




      
            
        }



        public void OkAddShape()
        {
            ErrorMessage = "";

            DisplayShape ShapeToAdd = null;

            int x;

            int y;

            int z;

            int w;


            if (ShapeName.Length == 0)
            {
                ErrorMessage = "Please name the shape";
                return;
            }


            if (SelectedShapeType == "Point")
            {
                if ( !int.TryParse(FieldList[0].FieldValue,out x))
                {
                    ErrorMessage = "X coordinate is not valid";
                    FieldList[0].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[1].FieldValue, out y))
                {
                    ErrorMessage = "Y coordinate is not valid";
                    FieldList[1].FieldValue = "";
                    return;
                }

                ShapeToAdd = new DisplayShape();

                ShapeToAdd.Shape= new PointClass(x, y);

                ShapeToAdd.Name=ShapeName;

            }
            else if(SelectedShapeType == "Vertical Line")
            {
                if (!int.TryParse(FieldList[0].FieldValue, out x))
                {
                    ErrorMessage = "X coordinate is not valid";
                    FieldList[0].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[1].FieldValue, out y))
                {
                    ErrorMessage = "Y1 coordinate is not valid";
                    FieldList[1].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[2].FieldValue, out z))
                {
                    ErrorMessage = "Y2 coordinate is not valid";
                    FieldList[2].FieldValue = "";
                    return;
                }


                ShapeToAdd = new DisplayShape();

                ShapeToAdd.Shape = new VerticalLineClass(y,z,x);

                ShapeToAdd.Name = ShapeName;
            }
            else if (SelectedShapeType == "Horizontal Line")
            {
                if (!int.TryParse(FieldList[0].FieldValue, out x))
                {
                    ErrorMessage = "X1 coordinate is not valid";
                    FieldList[0].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[1].FieldValue, out y))
                {
                    ErrorMessage = "X2 coordinate is not valid";
                    FieldList[1].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[2].FieldValue, out z))
                {
                    ErrorMessage = "Y coordinate is not valid";
                    FieldList[2].FieldValue = "";
                    return;
                }


                ShapeToAdd = new DisplayShape();

                ShapeToAdd.Shape = new HorizontalLineClass(x, y, z);

                ShapeToAdd.Name = ShapeName;
            }
            else if(SelectedShapeType == "Rectangle")
            {

                if (!int.TryParse(FieldList[0].FieldValue, out x))
                {
                    ErrorMessage = "X1 coordinate is not valid";
                    FieldList[0].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[1].FieldValue, out y))
                {
                    ErrorMessage = "X2 coordinate is not valid";
                    FieldList[1].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[2].FieldValue, out z))
                {
                    ErrorMessage = "Y coordinate is not valid";
                    FieldList[2].FieldValue = "";
                    return;
                }

                if (!int.TryParse(FieldList[3].FieldValue, out w))
                {
                    ErrorMessage = "Y coordinate is not valid";
                    FieldList[3].FieldValue = "";
                    return;
                }


                ShapeToAdd = new DisplayShape();

                ShapeToAdd.Shape = new RectangleClass( new PointClass(x, y),z,w );

                ShapeToAdd.Name = ShapeName;
            }



            if (ShapeToAdd != null)
            {
                Parent.AddShape(ShapeToAdd);
            }
            else
            {
                ErrorMessage = "Something went wrong";
            }

        }
        
        public void CancelAddShape()
        {
            Parent.Reset();
        }


    }
}
