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
        private string outputFileName;
        private WasapiLoopbackCapture capture;
        private WaveInEvent waveIn;
        private Thread micRecordThread;
        private int threadControl; // 1 start, 2 stop
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
            while (true && threadControl == 1)
            {
                string fileOutputName = this.outputFileName + i.ToString() + ".wav";
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
                        if (this.threadControl == 2) return;
                        i++;
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Record_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Wave files | *.wav";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            outputFileName = dialog.FileName;
            button_Record.Enabled = false;
            buttonStop.Enabled = true;
            capture = new WasapiLoopbackCapture();
            var writer = new WaveFileWriter(outputFileName, capture.WaveFormat);
            capture.DataAvailable += async (s, e_a) =>
            {
                if (writer != null)
                {
                    await writer.WriteAsync(e_a.Buffer, 0, e_a.BytesRecorded);
                    await writer.FlushAsync();
                }
            };
            capture.RecordingStopped += (s, e_s) =>
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }
                button_Record.Enabled = true;
                capture.Dispose();
            };
            capture.StartRecording();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            capture.StopRecording();
            if (outputFileName == null) return;
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.GetDirectoryName(outputFileName),
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        private void button_RecordMic_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            //dialog.Filter = "Wave files | *.wav";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            this.outputFileName = dialog.FileName;
            button_RecordMic.Enabled = false;
            button_StopRecordMic.Enabled = true;
            this.micRecordThread = new Thread(new ThreadStart(RecordMicIn));
            this.threadControl = 1;
            this.micRecordThread.Start();
        }

        private void button_StopRecordMic_Click(object sender, EventArgs e)
        {
            button_StopRecordMic.Enabled = false;
            button_RecordMic.Enabled = true;
            this.threadControl = 2;
        }

        private void listBox_Micro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
