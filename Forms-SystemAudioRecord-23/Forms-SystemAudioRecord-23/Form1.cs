using ClassLibrary_RecordingHelper_Net4._8;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using Vosk;


namespace Forms_SystemAudioRecord_23
{
    public partial class FormRecordSpeaker : Form
    {
        private Thread micRecordThread;
        private Thread systemAudioRecordThread;
        private Thread textUpdate;

        public FormRecordSpeaker()
        {
            InitializeComponent();
            button_StopRecordMic.Enabled = false;
            buttonStop.Enabled = false;
            var directSoundOutList = DirectSoundOut.Devices.ToList();
            for (int i = 1; i < directSoundOutList.Count(); i++)
            {
                Console.WriteLine(directSoundOutList[i].Description.ToString());
                listBox_Speakers.Items.Add(directSoundOutList[i].Description);
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
            RecordingHelper.checkBox_RecordFile_System = checkBox_RecordFile_System.Checked;
            RecordingHelper.checkBox_RecordFile_Mic = checkBox_RecordFile_Mic.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_Vosk = checkBox_SystemAudio_Use_Vosk.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_MS = checkBox_SystemAudio_Use_MS.Checked;
            RecordingHelper.checkBox_Mic_Use_Vosk = checkBox_Mic_Use_Vosk.Checked;
            RecordingHelper.checkBox_Mic_Use_MS = checkBox_Mic_Use_MS.Checked;
            RecordingHelper.serverPath = ConfigurationManager.AppSettings.Get("serverPath");
            RecordingHelper.serverURL = ConfigurationManager.AppSettings.Get("serverURL");

            label_MSTranscript_Mic.Text = RecordingHelper.text_LabelVoskTranscriptSystemAudio;
            label_MSTranscript_System.Text = RecordingHelper.text_LabelVoskTranscriptMicIn;
            label_VoskTranscript_Mic.Text = RecordingHelper.text_LabelMSTranscriptSystemAudio;
            label_VoskTranscript_System.Text = RecordingHelper.text_LabelMSTranscriptMicIn;

            textUpdate = new Thread(new ThreadStart(UpdateText));
            textUpdate.IsBackground = true;
            textUpdate.Start();
        }

        private void button_Record_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (checkBox_RecordFile_System.Checked == true)
            {
                dialog.Filter = "Wave files | *.part.";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                RecordingHelper.outputSystemRecordFileName = dialog.FileName;
            }
            button_Record.Enabled = false;
            buttonStop.Enabled = true;
            systemAudioRecordThread = new Thread(new ThreadStart(RecordingHelper.RecordSystemAudio));
            RecordingHelper.threadSystemAudioRecordControl = 1;
            systemAudioRecordThread.IsBackground = true;
            systemAudioRecordThread.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            button_Record.Enabled = true;
            RecordingHelper.threadSystemAudioRecordControl = 2;
            if (RecordingHelper.outputSystemRecordFileName == null) return;
            if (checkBox_RecordFile_System.Checked == true)
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.GetDirectoryName(RecordingHelper.outputSystemRecordFileName),
                    UseShellExecute = true
                };
                Process.Start(processStartInfo);
            }
        }

        private void button_RecordMic_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (checkBox_RecordFile_Mic.Checked == true)
            {
                dialog.Filter = "Wave files | *.part.";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                RecordingHelper.outputMicRecordFileName = dialog.FileName;
            }
            button_RecordMic.Enabled = false;
            button_StopRecordMic.Enabled = true;
            micRecordThread = new Thread(new ThreadStart(RecordingHelper.RecordMicIn));
            RecordingHelper.threadMicRecordControl = 1;
            micRecordThread.IsBackground = true;
            micRecordThread.Start();
        }

        private void button_StopRecordMic_Click(object sender, EventArgs e)
        {
            button_StopRecordMic.Enabled = false;
            button_RecordMic.Enabled = true;
            RecordingHelper.threadMicRecordControl = 2;
        }

        private void checkBox_SystemAudio_Use_Vosk_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_SystemAudio_Use_MS.Checked == true)
                checkBox_SystemAudio_Use_MS.Checked = !checkBox_SystemAudio_Use_Vosk.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_MS = checkBox_SystemAudio_Use_MS.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_Vosk = checkBox_SystemAudio_Use_Vosk.Checked;
        }

        private void checkBox_SystemAudio_Use_MS_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_SystemAudio_Use_Vosk.Checked == true)
                checkBox_SystemAudio_Use_Vosk.Checked = !checkBox_SystemAudio_Use_MS.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_Vosk = checkBox_SystemAudio_Use_Vosk.Checked;
            RecordingHelper.checkBox_SystemAudio_Use_MS = checkBox_SystemAudio_Use_MS.Checked;
        }

        private void checkBox_Mic_Use_Vosk_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Mic_Use_MS.Checked == true)
                checkBox_Mic_Use_MS.Checked = !checkBox_Mic_Use_Vosk.Checked;
            RecordingHelper.checkBox_Mic_Use_MS = checkBox_Mic_Use_MS.Checked;
            RecordingHelper.checkBox_Mic_Use_Vosk = checkBox_Mic_Use_Vosk.Checked;
        }

        private void checkBox_Mic_Use_MS_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Mic_Use_Vosk.Checked == true)
                checkBox_Mic_Use_Vosk.Checked = !checkBox_Mic_Use_MS.Checked;
            RecordingHelper.checkBox_Mic_Use_Vosk = checkBox_Mic_Use_Vosk.Checked;
            RecordingHelper.checkBox_Mic_Use_MS = checkBox_Mic_Use_MS.Checked;
        }

        private void UpdateText()
        {
            while (true)
            {
                ThreadHelper.SetText(this, richTextBox_SAudio_Vosk_Transcript, RecordingHelper.text_LabelVoskTranscriptSystemAudio);
                ThreadHelper.SetText(this, richTextBox_SAudio_MS_Transcript, RecordingHelper.text_LabelMSTranscriptSystemAudio);
                ThreadHelper.SetText(this, richTextBox_MicIn_Vosk_Transcript, RecordingHelper.text_LabelVoskTranscriptMicIn);
                ThreadHelper.SetText(this, richTextBox_MicIn_MS_Transcript, RecordingHelper.text_LabelMSTranscriptMicIn);
                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings.Get("sleepTime")) + 500);
            }
        }
    }
}
