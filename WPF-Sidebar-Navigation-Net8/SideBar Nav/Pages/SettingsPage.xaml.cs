using System.Windows.Controls;

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            cboInputDevice.ItemsSource = RecordingHelper.GetInputAudioDevices();
            cboInputDevice.SelectedIndex = 0;
            cboOutputDevice.ItemsSource = RecordingHelper.GetOutputAudioDevices();
            cboOutputDevice.SelectedIndex = 0;
        }
    }
}