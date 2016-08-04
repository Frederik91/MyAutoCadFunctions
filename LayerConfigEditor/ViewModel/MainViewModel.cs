using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Input;

namespace LayerConfigEditor.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_currentViewModel;
        
        public ViewModelBase CurrentViewModel { get { return m_currentViewModel; } set { m_currentViewModel = value; RaisePropertyChanged(); } }

        public MainViewModel()
        {
            CurrentViewModel = new LayerViewModel();
        }
    }
}