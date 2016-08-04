using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LayerConfigEditor.ViewModel
{
    public class LayerViewModel : ViewModelBase
    {
        public List<LayerFilter> LayerFilterList { get { return m_mainViewModel.LayerFilterList; } set { m_mainViewModel.LayerFilterList = value; RaisePropertyChanged(); } }

        private MainViewModel m_mainViewModel;


        public LayerViewModel(MainViewModel _mainViewModel)
        {
            m_mainViewModel = _mainViewModel;
        }


    }


}
