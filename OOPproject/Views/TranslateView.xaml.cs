using OOPproject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPproject.Views
{
    /// <summary>
    /// Interaction logic for TranslateView.xaml
    /// </summary>
    public partial class TranslateView : UserControl
    {

        public TranslationViewModel VM;

        public TranslateView(MainViewModel ParentVM)
        {
            VM = new TranslationViewModel(ParentVM);
            this.DataContext=VM;
            InitializeComponent();
        }

        public void OKTranslation(object sender, RoutedEventArgs e)
        {
            VM.OkTranslation();
        }

        public void CancelTranslation(object sender, RoutedEventArgs e)
        {
            VM.CancelTranslation();
        }

    }
}
