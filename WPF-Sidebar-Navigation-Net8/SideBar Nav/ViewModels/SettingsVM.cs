using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideBar_Nav.ViewModels
{
    public class SettingsVM : INotifyPropertyChanged
    {
        #region Fields
        private List<string> _inputDevices;
        private List<string> _outputDevices;
        private string _selectedInputDevice;
        private string _selectedOutputDevice;
        #endregion

        #region Properties
        public List<string> InputDevices
        {
            get { return _inputDevices; }
            set 
            { 
                _inputDevices = value;
                OnPropertyChanged(nameof(InputDevices));
            }
        }

        public List<string> OutputDevices
        {
            get { return _outputDevices; }
            set
            {
                _outputDevices = value;
                OnPropertyChanged(nameof(OutputDevices));
            }
        }

        public string SelectedInputDevice
        {
            get { return _selectedInputDevice; }
            set
            {
                _selectedInputDevice = value;
                OnPropertyChanged(nameof(SelectedInputDevice));
            }
        }

        public string SelectedOutputDevice
        {
            get { return _selectedOutputDevice; }
            set
            {  _selectedOutputDevice = value;
                OnPropertyChanged(nameof(SelectedOutputDevice));
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
