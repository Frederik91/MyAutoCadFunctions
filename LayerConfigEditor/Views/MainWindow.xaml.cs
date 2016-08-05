using LayerConfigEditor.ViewModel;
using System.Windows;

namespace LayerConfigEditor
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
