using OOPproject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged

    {
        public string TestString { get; set; } = "abc";


        public MainViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                DisplayShape ns = new();

                ns.Name = i.ToString();

                if (i % 5 == 0)
                {
                    ns.Shape = new RectangleClass(new PointClass(i, i), i * 10, i * 5);
                }
                else if (i % 2 == 0)
                {
                    ns.Shape = new HorizontalLineClass(new PointClass(i, i), new PointClass(i, i + 10));
                }
                else
                {
                    ns.Shape = new PointClass(i, i);
                }
                

                ShapeCollection.Add (ns);
            }
        }
        
        


        public ObservableCollection<DisplayShape> ShapeCollection { get; set; }=new();




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


        public void ChangeTextValue()
        {
            TestString = "AltCeva aici!";
        }


        public class DisplayShape
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
                                return "Line";
                                break;
                            case 2:
                                return "OtherLine";
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
                set { _shape = value; }
            }


        }

    }
}
