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
using OOPproject.Models;
using OOPproject.ViewModels;


namespace OOPproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        MainViewModel VM = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = VM;

        }

        private void AddAction(object sender, RoutedEventArgs e)
        {
            VM.ShowAddMenu();
        }

        private void RemoveAction(object sender, RoutedEventArgs e)
        {
            VM.RemoveShape();
        }

        private void TranslateAction(object sender, RoutedEventArgs e)
        {
            VM.ShowTranslateMenu();
        }


        private void ScaleAction(object sender, RoutedEventArgs e)
        {
            VM.ShowScaleMenu();
        }

    }
}
