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
    /// Interaction logic for ScaleView.xaml
    /// </summary>
    public partial class ScaleView : UserControl
    {
        ScaleViewModel VM;

        public ScaleView(MainViewModel ParentVM)
        {
            VM = new ScaleViewModel (ParentVM);

            this.DataContext = VM;
            InitializeComponent();
        }

        public void OKScale(object sender, RoutedEventArgs e)
        {
            VM.OKScale();
        }

        public void CancelScale(object sender, RoutedEventArgs e)
        {
            VM.CancelScale();
        }

        
    }
}
