using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerConfigWindow.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_viewModelBase;

        public ViewModelBase CurrentViewModel { get { return m_viewModelBase; } set { m_viewModelBase = value; OnPropertyChanged("CurrentViewModel"); } }

        public MainViewModel()
        {
            CurrentViewModel = new LayerViewModel();
        }
    }
}
