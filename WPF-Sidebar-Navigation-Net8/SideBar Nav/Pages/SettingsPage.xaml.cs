using SideBar_Nav.ViewModels;
using System.Windows.Controls;

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        private SettingsVM settingsVM;
        public SettingsPage()
        {
            InitializeComponent();
            settingsVM = new SettingsVM();
            settingsVM.InputDevices = RecordingHelper.GetInputAudioDevices();
            settingsVM.OutputDevices = RecordingHelper.GetOutputAudioDevices();
            settingsVM.SelectedInputDevice = settingsVM.InputDevices[0];
            settingsVM.SelectedOutputDevice = settingsVM.OutputDevices[0];
            this.DataContext = settingsVM;
        }
    }
}