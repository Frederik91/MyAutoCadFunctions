using LayerFilterFromSelectedObjectWindow.ViewModel;
using System.Windows;

namespace LayerFilterFromSelectedObjectWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel = new MainViewModel(this);
        }
    }
}
