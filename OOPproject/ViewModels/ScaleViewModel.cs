using OOPproject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.ViewModels
{
    public class ScaleViewModel : BaseActionViewModel
    {


        private string _inputXstring = "1";

        public string InputXstring
        {
            get { return _inputXstring; }
            set
            {
                if (value != _inputXstring)
                {
                    _inputXstring = value;
                    RaisePropertyChanged("InputXstring");
                }
            }
        }

        private string _inputYstring = "1";
        public string InputYstring
        {
            get { return _inputYstring; }
            set
            {
                if (value != _inputYstring)
                {
                    _inputYstring = value;
                    RaisePropertyChanged("InputYstring");
                }
            }
        }

        

        public ScaleViewModel(MainViewModel parentViewModel) : base(parentViewModel)
        {

            ActionHeader = "Scaling shape " + Parent.SelectedShape.Name;

        }

        public void CancelScale()
        {
            Parent.Reset();
        }


        public void OKScale()
        {
            double x = 1;

            double y = 1;




            InputXstring = InputXstring.Replace(',', '.');
            InputYstring = InputYstring.Replace(',', '.');

            if (!double.TryParse(InputXstring, NumberStyles.Any, CultureInfo.InvariantCulture, out x))
            {


                InputXstring = "";
                ErrorMessage = "Coordonata X nu este corecta";
                return;
            }
            else
            {
                if (x <= 0)
                {
                    InputXstring = "";
                    ErrorMessage = "Coordonata X este 0 sau mai mica";
                    return;
                }
            }

            if (!double.TryParse(InputYstring, NumberStyles.Any, CultureInfo.InvariantCulture, out y))
            {
                InputYstring = "";
                ErrorMessage = "Coordonata y nu este corecta";
                return;
            }
            else
            {
                if (y <= 0)
                {
                    InputYstring = "";
                    ErrorMessage = "Coordonata Y este 0 sau mai mica";
                    return;
                }
            }




            ScalingVectorClass ScalingVector = new ScalingVectorClass(x, y);


            Parent.OkScale(ScalingVector);

            Parent.Reset();

            
        }
    }
}
