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
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {



        public AddViewModel VM;

        public AddView(MainViewModel ParentVM)
        {
            VM = new AddViewModel(ParentVM);

            this.DataContext = VM;

            InitializeComponent();

        }

        private void AddOk(object sender, RoutedEventArgs e)
        {
            VM.OkAddShape();
        }

        private void AddCancel(object sender, RoutedEventArgs e)
        {
            VM.CancelAddShape();
        }

    }
}
