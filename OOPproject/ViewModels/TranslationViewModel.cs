using OOPproject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPproject.ViewModels
{
    public class TranslationViewModel : BaseActionViewModel
    {
        private string _inputXstring = "0";

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

        private string _inputYstring = "0";
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

        public TranslationViewModel(MainViewModel parentViewModel) : base(parentViewModel)
        {

            ActionHeader = "Scaling shape " + Parent.SelectedShape.Name;

        }

        public void CancelTranslation()
        {
            Parent.Reset();
        }

        public void OkTranslation()
        {
            int x = 0;

            int y = 0;




            InputXstring = InputXstring.Replace(',', '.');
            InputYstring = InputYstring.Replace(',', '.');

            if (!int.TryParse(InputXstring, NumberStyles.Any, CultureInfo.InvariantCulture, out x))
            {


                InputXstring = "";
                ErrorMessage = "Coordonata X nu este corecta";
                return;
            }
            //else
            //{
            //    if (x <= 0)
            //    {
            //        InputXstring = "";
            //        ErrorMessage = "Coordonata X este 0 sau mai mica";
            //        return;
            //    }
            //}

            if (!int.TryParse(InputYstring, NumberStyles.Any, CultureInfo.InvariantCulture, out y))
            {
                InputYstring = "";
                ErrorMessage = "Coordonata y nu este corecta";
                return;
            }
            //else
            //{
            //    if (y <= 0)
            //    {
            //        InputYstring = "";
            //        ErrorMessage = "Coordonata Y este 0 sau mai mica";
            //        return;
            //    }
            //}




            TranslationVectorClass TranslationVector = new TranslationVectorClass(x, y);


            Parent.OkTranslate(TranslationVector);

            Parent.Reset();

        }

    }
}
