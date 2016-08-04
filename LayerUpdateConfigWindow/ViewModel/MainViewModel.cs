using GalaSoft.MvvmLight;
using System.Windows;

namespace LayerUpdateConfigWindow.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_viewModelBase;

        public ViewModelBase CurrentViewModel { get { return m_viewModelBase; } set { m_viewModelBase = value; RaisePropertyChanged("CurrentViewModel"); } }

        public MainViewModel()
        {
            CurrentViewModel = new LayerViewModel();
        }

        
    }
}