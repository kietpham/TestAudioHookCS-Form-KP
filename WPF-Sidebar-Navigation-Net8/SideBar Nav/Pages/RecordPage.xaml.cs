using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for RecordPage.xaml
    /// </summary>
    public partial class RecordPage : UserControl
    {
        public RecordPage()
        {
            InitializeComponent();

            btnStop.IsEnabled = false;

            ConversationHelper.textUpdate = new Thread(new ThreadStart(UpdateText));
            ConversationHelper.textUpdate.IsBackground = true;
            ConversationHelper.textUpdate.Start();
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
       
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "Wave files | *.part.";
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;

            RecordingHelper.outputSystemRecordFileName = dialog.FileName + "_system_audio_";
            RecordingHelper.outputMicRecordFileName = dialog.FileName + "_mic_in_";

            RecordingHelper.StartRecordSystemAudio();
            RecordingHelper.StartRecordMicIn();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;

            RecordingHelper.threadSystemAudioRecordControl = 2;
            RecordingHelper.threadMicRecordControl = 2;
            RecordingHelper.StoptRecordSystemAudio();
            RecordingHelper.StopRecordMicIn();

            if (RecordingHelper.outputSystemRecordFileName == null) return;
            Thread.Sleep(RecordingHelper.sleepTime + 500);
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.GetDirectoryName(RecordingHelper.outputSystemRecordFileName),
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        private void UpdateText()
        {
            Trace.WriteLine("Update Text Started!");
            while (true)
            {
                string s_MSTranscriptSystemAudio = RecordingHelper.GetMSTranscriptSystemAudio();
                string s_MSTranscriptMicIn = RecordingHelper.GetMSTranscriptMicIn();

                Dispatcher.InvokeAsync(new Action(() => {
                    rtbxSystemAudio.Document.Blocks.Clear();
                    rtbxMicIn.Document.Blocks.Clear();
                    rtbxSystemAudio.AppendText(s_MSTranscriptSystemAudio);
                    rtbxMicIn.AppendText(s_MSTranscriptMicIn);
                }));

                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings.Get("sleepTime")) + 500);

                if (s_MSTranscriptSystemAudio.Length > 1200000) RecordingHelper.SetMSTranscriptSystemAudio("");
                if (s_MSTranscriptMicIn.Length > 1200000) RecordingHelper.SetMSTranscriptMicIn("");
            }
        }
    }
}