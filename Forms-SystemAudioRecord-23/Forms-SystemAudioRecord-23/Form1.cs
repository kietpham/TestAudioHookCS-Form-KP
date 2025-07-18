using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;


namespace Forms_SystemAudioRecord_23
{
    public partial class FormRecordSpeaker : Form
    {
        private string outputMicRecordFileName;
        private string outputSystemRecordFileName;
        private WasapiLoopbackCapture capture;
        private WaveInEvent waveIn;
        private Thread micRecordThread;
        private Thread systemAudioRecordThread;
        private int threadMicRecordControl; // 1 start, 2 stop
        private int threadSystemAudioRecordControl; // 1 start, 2 stop

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
        }

        void RecordMicIn()
        {
            int i = 0;
            while (threadMicRecordControl == 1 && i < 200)
            {
                string fileOutputName = this.outputMicRecordFileName + i.ToString() + ".wav";
                var waveFormat = new WaveFormat(44100, 1);
                using (var waveFile = new WaveFileWriter(fileOutputName, waveFormat))
                {
                    using (this.waveIn = new WaveInEvent())
                    {
                        waveIn.WaveFormat = waveFormat;

                        waveIn.DataAvailable += (s, e_wi) =>
                        {
                            // mic 0 => default , có thể chọn tùy thích
                            waveFile.Write(e_wi.Buffer, 0, e_wi.BytesRecorded);
                        };

                        waveIn.StartRecording();
                        Thread.Sleep(5000);
                        this.waveIn.StopRecording();
                        if (this.threadMicRecordControl == 2) return;
                        i++;
                    }
                }
            }
        }

        void RecordSystemAudio()
        {
            int i = 0;
            while (threadSystemAudioRecordControl == 1 && i < 200)
            {
                string fileOutputName = this.outputSystemRecordFileName + i.ToString() + ".wav";
                Console.WriteLine(fileOutputName);
                this.capture = new WasapiLoopbackCapture();
                var writer = new WaveFileWriter(fileOutputName, capture.WaveFormat);
                capture.DataAvailable += (s, e_a) =>
                {
                    if (writer != null)
                    {
                        writer.WriteAsync(e_a.Buffer, 0, e_a.BytesRecorded);
                        writer.FlushAsync();
                    }
                };
                this.capture.StartRecording();
                Thread.Sleep(5000);
                this.capture.StopRecording();
                if (this.threadSystemAudioRecordControl == 2)
                {
                    Console.WriteLine("RecordSystemAudio End");
                    writer.Dispose();
                    capture.Dispose();
                    return;
                }
                i++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Record_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Wave files | *.part.";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            outputSystemRecordFileName = dialog.FileName;
            button_Record.Enabled = false;
            buttonStop.Enabled = true;
            this.threadSystemAudioRecordControl = 1;
            this.systemAudioRecordThread = new Thread(new ThreadStart(RecordSystemAudio));
            this.systemAudioRecordThread.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            button_Record.Enabled = true;
            this.threadSystemAudioRecordControl = 2;
            if (outputSystemRecordFileName == null) return;
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.GetDirectoryName(outputSystemRecordFileName),
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        private void button_RecordMic_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Wave files | *.part.";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            this.outputMicRecordFileName = dialog.FileName;
            button_RecordMic.Enabled = false;
            button_StopRecordMic.Enabled = true;
            this.micRecordThread = new Thread(new ThreadStart(RecordMicIn));
            this.threadMicRecordControl = 1;
            this.micRecordThread.Start();
        }

        private void button_StopRecordMic_Click(object sender, EventArgs e)
        {
            button_StopRecordMic.Enabled = false;
            button_RecordMic.Enabled = true;
            this.threadMicRecordControl = 2;
        }

        private void listBox_Micro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
