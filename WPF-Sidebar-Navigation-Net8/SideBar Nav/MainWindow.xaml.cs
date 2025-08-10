using NAudio.Wave;
using SideBar_Nav.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SideBar_Nav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize with the Record page
            ccPageContent.Content = new RecordPage();

            // Attach navigation button handlers
            btnRecord.Click += (s, e) => { ccPageContent.Content = new RecordPage(); };
            btnMeetingSummary.Click += (s, e) => { ccPageContent.Content = new MeetingSummaryPage(); };
            btnSettings.Click += (s, e) => { ccPageContent.Content = new SettingsPage(); };

            ConversationHelper.conversationContent = string.Empty;
            ConversationHelper.textUpdate = null;

            var directSoundOutList = DirectSoundOut.Devices.ToList();
            for (int i = 1; i < directSoundOutList.Count(); i++)
            {
                Trace.WriteLine(directSoundOutList[i].Description.ToString());
            }

            //RecordingHelper.voskModel = new Model(ConfigurationManager.AppSettings.Get("voskModelPath"));
            RecordingHelper.sleepTime = int.Parse(ConfigurationManager.AppSettings.Get("sleepTime"));
            RecordingHelper.micSampleRate = int.Parse(ConfigurationManager.AppSettings.Get("micSampleRate"));
            RecordingHelper.systemAudioSampleRate = int.Parse(ConfigurationManager.AppSettings.Get("systemAudioSampleRate"));
            RecordingHelper.currentProcessID = Process.GetCurrentProcess().Id;
            RecordingHelper.currentProcessName = Process.GetCurrentProcess().ProcessName;
            RecordingHelper.outputMicRecordFileName = "";
            RecordingHelper.outputSystemRecordFileName = "";
            RecordingHelper.threadMicRecordControl = 2; // 1 start, 2 stop
            RecordingHelper.threadSystemAudioRecordControl = 2; // 1 start, 2 stop
            RecordingHelper.checkBox_RecordFile_System = true;
            RecordingHelper.checkBox_RecordFile_Mic = true;
            RecordingHelper.checkBox_SystemAudio_Use_Vosk = false;
            RecordingHelper.checkBox_SystemAudio_Use_MS = true;
            RecordingHelper.checkBox_Mic_Use_Vosk = false;
            RecordingHelper.checkBox_Mic_Use_MS = true;
            RecordingHelper.serverPath = ConfigurationManager.AppSettings.Get("serverPath");
            RecordingHelper.serverURL = ConfigurationManager.AppSettings.Get("serverURL");

            var inputAudioDevices = RecordingHelper.GetInputAudioDevices();
            var outputAudioDevices = RecordingHelper.GetOutputAudioDevices();
            Trace.WriteLine("inputAudioDevices: " + inputAudioDevices.Count);
            foreach (var device in inputAudioDevices) {
                Trace.WriteLine(device);
            }
            Trace.WriteLine("outputAudioDevices: " + outputAudioDevices.Count);
            foreach (var device in outputAudioDevices)
            {
                Trace.WriteLine(device);
            }
        }
    }
}
  