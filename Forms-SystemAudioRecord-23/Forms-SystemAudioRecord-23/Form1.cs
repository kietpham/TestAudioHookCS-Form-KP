using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public static string labelVoskTranscriptSystemAudio;
        public static string labelVoskTranscriptMicIn;
        public static string labelMSTranscriptSystemAudio;
        public static string labelMSTranscriptMicIn;
        private string outputMicRecordFileName = "";
        private string outputSystemRecordFileName = "";
        private WasapiLoopbackCapture capture;
        private WaveInEvent waveIn;
        private Thread micRecordThread;
        private Thread systemAudioRecordThread;
        private int threadMicRecordControl; // 1 start, 2 stop
        private int threadSystemAudioRecordControl; // 1 start, 2 stop
        public int micSampleRate = 44100;
        public int systemAudioSampleRate = 16000;

        public Model voskModel = new Model("C:\\GitHub\\vosk-model-small-en-us-0.15");

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
            this.label_MSTranscript_Mic.Text = labelMSTranscriptMicIn;
            this.label_MSTranscript_System.Text = labelMSTranscriptSystemAudio;
            this.label_VoskTranscript_Mic.Text = labelVoskTranscriptMicIn;
            this.label_VoskTranscript_System.Text = labelVoskTranscriptSystemAudio;
        }

        void RecordMicIn()
        {
            Console.WriteLine("RecordMicIn");
            int i = 0;
            var recVosk = new VoskRecognizer(this.voskModel, this.micSampleRate);
            while (threadMicRecordControl == 1 && i < 200)
            {
                var waveFormat = new WaveFormat(this.micSampleRate, 1);
                var byteBuffer = new List<byte>();
                using (this.waveIn = new WaveInEvent())
                {
                    waveIn.WaveFormat = waveFormat;
                    waveIn.DataAvailable += (s, e_wi) =>
                    {
                        // mic 0 => default , có thể chọn tùy thích
                        var audioByteArray = new byte[e_wi.BytesRecorded];
                        Array.Copy(e_wi.Buffer, audioByteArray, e_wi.BytesRecorded);
                        byteBuffer.AddRange(audioByteArray);
                    };
                    waveIn.StartRecording();
                    Thread.Sleep(5000);
                    this.waveIn.StopRecording();

                    // save File
                    var soundByteArray = byteBuffer.ToArray();
                    if (checkBox_RecordFile_System.Checked == true)
                    {
                        string fileOutputName = this.outputMicRecordFileName + i.ToString() + ".wav";
                        var waveFile = new WaveFileWriter(fileOutputName, waveFormat);
                        waveFile.Write(soundByteArray, 0, soundByteArray.Length);
                        waveFile.Flush();
                    }

                    // Transcript Mic using Vosk
                    if (recVosk.AcceptWaveform(soundByteArray, soundByteArray.Length))
                    {
                        var voskResult = recVosk.Result();
                        Console.WriteLine("recVosk: " + soundByteArray.Length.ToString() + voskResult);
                        var voskResultValue = JObject.Parse(voskResult)["text"];
                        labelVoskTranscriptMicIn += voskResultValue + "|";
                        Console.WriteLine(voskResultValue);
                        ThreadHelperClass.SetText(this, label_VoskTranscript_Mic, labelVoskTranscriptMicIn);
                    }

                    if (this.threadMicRecordControl == 2) return;
                    i++;
                }
            }
        }

        void RecordSystemAudio()
        {
            int i = 0;
            var recVosk = new VoskRecognizer(this.voskModel, this.systemAudioSampleRate);
            while (threadSystemAudioRecordControl == 1 && i < 200)
            {
                capture = new WasapiLoopbackCapture();
                capture.WaveFormat = new WaveFormat(this.systemAudioSampleRate, 1);
                var byteBuffer = new List<byte>();
                // Capture Async dùng được, nhưng khó khăn khi làm transcript
                //string fileOutputName = this.outputSystemRecordFileName + i.ToString() + ".wav";
                //Console.WriteLine(fileOutputName);
                //var writer = new WaveFileWriter(fileOutputName, capture.WaveFormat);
                //capture.DataAvailable += async (s, e_a) =>
                //{
                //    if (writer != null) {
                //        Console.WriteLine("WasapiLoopbackCapture Buffer BytesRecorded: " + e_a.BytesRecorded);
                //        if (checkBox_RecordFile_System.Checked == true) {
                //            await writer.WriteAsync(e_a.Buffer, 0, e_a.BytesRecorded);
                //            await writer.FlushAsync();
                //        }
                //    }
                //};
                // Capture không Async, dùng byte làm transcript tốt hơn
                capture.DataAvailable += (s, e_a) =>
                {
                    var audioByteArray = new byte[e_a.BytesRecorded];
                    Array.Copy(e_a.Buffer, audioByteArray, e_a.BytesRecorded);
                    byteBuffer.AddRange(audioByteArray);
                };
                capture.RecordingStopped += (s, e) => { Console.WriteLine("Capture Recording Stopped"); };

                capture.StartRecording();
                Thread.Sleep(5000);
                this.capture.StopRecording();

                var soundByteArray = byteBuffer.ToArray();

                // Save file
                if (checkBox_RecordFile_System.Checked == true)
                {
                    string fileOutputName = this.outputSystemRecordFileName + i.ToString() + ".wav";
                    Console.WriteLine(fileOutputName);
                    var writer = new WaveFileWriter(fileOutputName, capture.WaveFormat);
                    writer.Write(soundByteArray, 0, soundByteArray.Length);
                    writer.Flush();
                }
                // Transcript System Audio using Vosk
                if (recVosk.AcceptWaveform(soundByteArray, soundByteArray.Length))
                {
                    var voskResult = recVosk.Result();
                    Console.WriteLine("recVosk: " + soundByteArray.Length.ToString() + voskResult);
                    var voskResultValue = JObject.Parse(voskResult)["text"];
                    labelVoskTranscriptSystemAudio += voskResult + "|";
                    Console.WriteLine(voskResultValue);
                    ThreadHelperClass.SetText(this, label_VoskTranscript_System, labelVoskTranscriptSystemAudio);
                }

                if (this.threadSystemAudioRecordControl == 2)
                {
                    Console.WriteLine("RecordSystemAudio End");
                    this.capture.Dispose();
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
            if (this.checkBox_RecordFile_System.Checked == true)
            {
                dialog.Filter = "Wave files | *.part.";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                outputSystemRecordFileName = dialog.FileName;
            }
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
            if (checkBox_RecordFile_Mic.Checked == true)
            {
                dialog.Filter = "Wave files | *.part.";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                this.outputMicRecordFileName = dialog.FileName;
            }
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

    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
    }
}
