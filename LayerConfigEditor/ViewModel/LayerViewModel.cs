using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        public RelayCommand testCommand { get; private set; }

        public LayerViewModel()
        {
            testCommand = new RelayCommand(testMethod);
        }

        private void testMethod()
        {
            MessageBox.Show("YEAH");
        }
    }


}
