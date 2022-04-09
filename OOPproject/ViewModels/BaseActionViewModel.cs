using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOPproject.ViewModels
{   


    public class BaseActionViewModel : INotifyPropertyChanged
    {

        public BaseActionViewModel(MainViewModel parentVM)
        {
            Parent=parentVM;
        }


        public string ActionHeader { get; set; }

        public MainViewModel Parent;


        public event PropertyChangedEventHandler? PropertyChanged;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if(_errorMessage != value)
                {
                    _errorMessage = value;
                    RaisePropertyChanged("ErrorMessage");
                }
            }
        }

        internal void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }




        public class ValueFieldsClass : INotifyPropertyChanged
        {

            private string _fieldName = "";

            public string FieldName
            {
                get { return _fieldName; }
                set
                {
                    if (value != _fieldName)
                    {
                        _fieldName = value;
                        RaisePropertyChanged("FieldName");
                    }
                }
            }


            private string _fieldValue = "";

            public string FieldValue
            {
                get { return _fieldValue; }
                set
                {
                    if (_fieldValue != value)
                    {
                        _fieldValue = value;
                        RaisePropertyChanged("FieldValue");
                    }
                }
            }

            private Visibility _fieldVisibility = Visibility.Hidden;

            public Visibility FieldVisibility
            {
                get { return _fieldVisibility; }
                set
                {
                    if (_fieldVisibility != value)
                    {
                        _fieldVisibility = value;
                        RaisePropertyChanged("FieldVisibility");
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            internal void RaisePropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }


        }
    }
}
