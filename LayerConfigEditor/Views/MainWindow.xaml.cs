using LayerConfigEditor.ViewModel;
using System.Windows;
using System.Windows.Input;

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

        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainViewModel.setColor(LayerFilter_DataGrid.SelectedIndex);

            var x = LayerFilter_DataGrid.SelectedIndex;
            LayerFilter_DataGrid.SelectedIndex = 0;
            LayerFilter_DataGrid.SelectedIndex = x;
        }
    }
}
