using Microsoft.VisualBasic;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SideBar_Nav
{
    public static class RecordingHelper
    {
        //public static Model voskModel;    // Obsoleted
        public static int sleepTime;
        public static int micSampleRate;
        public static int systemAudioSampleRate;
        public static int currentProcessID = 0;
        public static string currentProcessName;
        public static string serverURL;
        public static string serverPath;
        public static string outputMicRecordFileName = "";
        public static string outputSystemRecordFileName = "";
        public static string text_LabelVoskTranscriptSystemAudio = "";   // Transcript text add in during run
        public static string text_LabelVoskTranscriptMicIn = "";         // Transcript text add in during run
        public static string text_LabelMSTranscriptSystemAudio = "";     // Transcript text add in during run
        public static string text_LabelMSTranscriptMicIn = "";           // Transcript text add in during run
        public static string text_TranscriptAll = "";           // Transcript text add in during run
        public static string text_SummaryAll = "";           // Transcript text add in during run
        public static WasapiLoopbackCapture capture;
        public static WaveInEvent waveIn;
        public static int threadMicRecordControl;   // 1 start, 2 stop
        public static int threadSystemAudioRecordControl;   // 1 start, 2 stop
        public static bool checkBox_RecordFile_System;
        public static bool checkBox_RecordFile_Mic;
        public static bool checkBox_SystemAudio_Use_Vosk;
        public static bool checkBox_SystemAudio_Use_MS;
        public static bool checkBox_Mic_Use_Vosk;
        public static bool checkBox_Mic_Use_MS;
        public static Thread static_systemAudioRecordThread;
        public static Thread static_micRecordThread;

        public static int i_RecordSystemAudio;
        public static int i_RecordMicIn;
        public static void RecordSystemAudio()
        {
            Trace.WriteLine("RecordSystemAudio");
            i_RecordSystemAudio = 0;
            //var recVosk = new VoskRecognizer(voskModel, systemAudioSampleRate);   // Obsoleted
            while (threadSystemAudioRecordControl == 1)
            {
                capture = new WasapiLoopbackCapture();
                capture.WaveFormat = new WaveFormat(systemAudioSampleRate, 1);
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
                capture.RecordingStopped += (s, e) => { Trace.WriteLine("Capture Recording Stopped"); };

                capture.StartRecording();
                Thread.Sleep(sleepTime);
                capture.StopRecording();

                var soundByteArray = byteBuffer.ToArray();

                // Save file
                string fileOutputName = outputSystemRecordFileName + i_RecordSystemAudio.ToString() + ".wav";
                try
                {
                    if (checkBox_RecordFile_System == true)
                    {
                        var writer = new WaveFileWriter(fileOutputName, capture.WaveFormat);
                        writer.Write(soundByteArray, 0, soundByteArray.Length);
                        writer.Flush();
                        writer.Close();
                    }
                }
                catch (Exception ex) { Trace.WriteLine(ex.ToString()); }
                // Transcript System Audio using Vosk - Obsoleted
                //if (checkBox_SystemAudio_Use_Vosk == true && recVosk.AcceptWaveform(soundByteArray, soundByteArray.Length))
                //{
                //    var voskResult = recVosk.Result();
                //    Console.WriteLine("recVosk: " + soundByteArray.Length.ToString() + voskResult);
                //    var voskResultValue = JObject.Parse(voskResult)["text"];
                //    text_LabelVoskTranscriptSystemAudio += voskResultValue + " | ";
                //    Console.WriteLine(voskResultValue);
                //    //ThreadHelper.SetText(this, richTextBox_SAudio_Vosk_Transcript, text_LabelVoskTranscriptSystemAudio);  // Move out to main Form
                //}
                // Transcript System Audio using MS
                if (checkBox_SystemAudio_Use_MS == true)
                {
                    var options = new RestClientOptions(serverURL)
                    {
                        Timeout = new TimeSpan(0, 15, 0)
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest(serverPath, Method.Post);
                    request.AlwaysMultipartFormData = true;
                    request.AddFile("file", fileOutputName);
                    RestResponse response = client.Execute(request);
                    Trace.WriteLine("API result: " + response.Content);
                    try
                    {
                        var jsonResult = JObject.Parse(response.Content);
                        var result = jsonResult["candidates"][0]["content"]["parts"][0]["text"];
                        text_LabelMSTranscriptSystemAudio += result + " | ";
                    }
                    catch (Exception ex) {
                        Trace.WriteLine("Exception: " + ex.ToString());
                    }
                }

                if (threadSystemAudioRecordControl == 2)
                {
                    capture.Dispose();
                    return;
                }
                i_RecordSystemAudio++;
            }
        }
        public static void RecordMicIn()
        {
            Trace.WriteLine("RecordMicIn");
            i_RecordMicIn = 0;
            //var recVosk = new VoskRecognizer(voskModel, micSampleRate);   // Obsoleted
            while (threadMicRecordControl == 1)
            {
                var waveFormat = new WaveFormat(micSampleRate, 1);
                var byteBuffer = new List<byte>();
                using (waveIn = new WaveInEvent())
                {
                    waveIn.WaveFormat = waveFormat;
                    // mic 0 => default , có thể chọn tùy thích
                    waveIn.DeviceNumber = 0;
                    waveIn.DataAvailable += (s, e_wi) =>
                    {
                        var audioByteArray = new byte[e_wi.BytesRecorded];
                        Array.Copy(e_wi.Buffer, audioByteArray, e_wi.BytesRecorded);
                        byteBuffer.AddRange(audioByteArray);
                    };
                    waveIn.StartRecording();
                    Thread.Sleep(sleepTime);
                    waveIn.StopRecording();

                    // save File
                    var soundByteArray = byteBuffer.ToArray();
                    string fileOutputName = outputMicRecordFileName + i_RecordMicIn.ToString() + ".wav";
                    try
                    {
                        if (checkBox_RecordFile_Mic == true)
                        {
                            var waveFile = new WaveFileWriter(fileOutputName, waveFormat);
                            waveFile.Write(soundByteArray, 0, soundByteArray.Length);
                            waveFile.Flush();
                            waveFile.Close();
                        }
                    }
                    catch (Exception ex) { Trace.WriteLine(ex.ToString()); }
                    // Transcript Mic using Vosk - Obsoleted
                    //if (checkBox_Mic_Use_Vosk == true & recVosk.AcceptWaveform(soundByteArray, soundByteArray.Length))
                    //{
                    //    var voskResult = recVosk.Result();
                    //    Console.WriteLine("recVosk: " + soundByteArray.Length.ToString() + voskResult);
                    //    var voskResultValue = JObject.Parse(voskResult)["text"];
                    //    text_LabelVoskTranscriptMicIn += voskResultValue + " | ";
                    //    Console.WriteLine(voskResultValue);
                    //}
                    // Transcript Mic using MS / API
                    if (checkBox_Mic_Use_MS == true)
                    {
                        var options = new RestClientOptions(serverURL)
                        {
                            Timeout = new TimeSpan(0, 15, 0)
                        };
                        var client = new RestClient(options);
                        var request = new RestRequest(serverPath, Method.Post);
                        request.AlwaysMultipartFormData = true;
                        request.AddFile("file", fileOutputName);
                        RestResponse response = client.Execute(request);
                        Trace.WriteLine("API Result Mic In: " + response.Content);
                        try
                        {
                            var jsonResult = JObject.Parse(response.Content);
                            var result = jsonResult["candidates"][0]["content"]["parts"][0]["text"];
                            text_LabelMSTranscriptMicIn += result + " | ";
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine("Exception: " + ex.ToString());
                        }
                    }

                    if (threadMicRecordControl == 2) return;
                    i_RecordMicIn++;
                }
            }
        }
        public static void StartRecordSystemAudio()
        {
            static_systemAudioRecordThread = new Thread(new ThreadStart(RecordingHelper.RecordSystemAudio));
            RecordingHelper.threadSystemAudioRecordControl = 1;
            static_systemAudioRecordThread.IsBackground = true;
            static_systemAudioRecordThread.Start();
        }
        public static void StoptRecordSystemAudio()
        {
            RecordingHelper.threadSystemAudioRecordControl = 2;
            Thread.Sleep(RecordingHelper.sleepTime + 500);
            static_systemAudioRecordThread.Interrupt();
        }
        public static void StartRecordMicIn()
        {
            static_micRecordThread = new Thread(new ThreadStart(RecordingHelper.RecordMicIn));
            RecordingHelper.threadMicRecordControl = 1;
            static_micRecordThread.IsBackground = true;
            static_micRecordThread.Start();
        }
        public static void StopRecordMicIn()
        {
            RecordingHelper.threadMicRecordControl = 2;
            Thread.Sleep(RecordingHelper.sleepTime + 500);
            static_micRecordThread.Interrupt();
        }
        public static string GetMSTranscriptSystemAudio()
        {
            return text_LabelMSTranscriptSystemAudio;
        }
        public static void SetMSTranscriptSystemAudio(string value)
        {
            text_LabelMSTranscriptSystemAudio = value;
        }
        public static string GetMSTranscriptMicIn()
        {
            return text_LabelMSTranscriptMicIn;
        }
        public static void SetMSTranscriptMicIn(string value)
        {
            text_LabelMSTranscriptMicIn = value;
        }
        public static List<string> GetInputAudioDevices()
        {
            List<string> deviceNames = new List<string>();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();

            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                deviceNames.Add(device.FriendlyName);
            }

            return deviceNames;
        }
        public static List<string> GetOutputAudioDevices()
        {
            List<string> deviceNames = new List<string>();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();

            // Enumerate active audio rendering (output) devices
            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                deviceNames.Add(device.FriendlyName);
            }

            return deviceNames;
        }
        public static void FullConversationTranscript() {
            // Append all SystemAudio File & Append all MicIn File
            try
            {
                var providersSystemAudio = new List<ISampleProvider> { };
                for (int i = 0; i < i_RecordSystemAudio - 1; i++)
                {
                    var file = new AudioFileReader(outputSystemRecordFileName + i.ToString() + ".wav");
                    providersSystemAudio.Add(file);
                }
                var concatenatedProviderSystemAudio = new ConcatenatingSampleProvider(providersSystemAudio);
                WaveFileWriter.CreateWaveFile(outputSystemRecordFileName + "All.wav", concatenatedProviderSystemAudio.ToWaveProvider());

                var providersMicIn = new List<ISampleProvider> { };
                for (int i = 0; i < i_RecordMicIn - 1; i++)
                {
                    var file = new AudioFileReader(outputMicRecordFileName + i.ToString() + ".wav");
                    providersMicIn.Add(file);
                }
                var concatenatedProviderMicIn = new ConcatenatingSampleProvider(providersMicIn);
                WaveFileWriter.CreateWaveFile(outputMicRecordFileName + "All.wav", concatenatedProviderMicIn.ToWaveProvider());
            }
            catch (Exception ex) {
                Trace.WriteLine("FullConversationTranscript - Append all SystemAudio File");
            }

            // Mix SystemAudio and MicIn
            try
            {
                var systemRecordAll = new AudioFileReader(outputSystemRecordFileName + "All.wav");
                var micInAll = new AudioFileReader(outputMicRecordFileName + "All.wav");

                #region use delayed
                // use delayed if needed (MicIn Record started after System Audio Record), the handling for delay time is not yet done
                //double delayInSeconds = 0.1;
                //var delayInSamples = (int)(micSampleRate * delayInSeconds);
                //var delayedMicInAll = new OffsetSampleProvider(micInAll.ToSampleProvider())
                //{
                //    DelayBySamples = delayInSamples
                //};
                //var mixer = new MixingSampleProvider(micInAll.WaveFormat); // Ensure all inputs have the same format
                //mixer.AddMixerInput(systemRecordAll);
                //mixer.AddMixerInput(delayedMicInAll);
                #endregion

                #region DO NOT use delayed
                // Do NOT use delayed
                //Obsoleted
                //var mixer = new MixingSampleProvider(new ISampleProvider[] { systemRecordAll, micInAll.ToSampleProvider() });
                //WaveFileWriter.CreateWaveFile16(outputSystemRecordFileName + "All_Mixed.wav", mixer);

                var mixer = new MixingWaveProvider32();
                mixer.AddInputStream(systemRecordAll.ToWaveProvider());
                mixer.AddInputStream(micInAll.ToWaveProvider());
                #endregion

                WaveFileWriter.CreateWaveFile(outputSystemRecordFileName + "All_Mixed.wav", mixer);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("FullConversationTranscript - Mix SystemAudio and MicIn");
            }

            // Transcript all
            try
            {
                var options = new RestClientOptions(serverURL)
                {
                    Timeout = new TimeSpan(0, 15, 0)
                };
                var client = new RestClient(options);
                var request = new RestRequest(serverPath, Method.Post);
                request.AlwaysMultipartFormData = true;
                request.AddFile("file", outputSystemRecordFileName + "All_Mixed.wav");
                RestResponse response = client.Execute(request);
                Trace.WriteLine("API Result Mix SystemAudio and MicIn: " + response.Content);
                try
                {
                    var jsonResult = JObject.Parse(response.Content);
                    var result = jsonResult["candidates"][0]["content"]["parts"][0]["text"].ToString();
                    text_TranscriptAll = result;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Exception: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("FullConversationTranscript - Transcript all");
            }
        }
        public static void FullConversationSummary() {
            // Summary all
            try
            {
                var summaryPath = ConfigurationManager.AppSettings.Get("serverPathSummary");
                // Generate Summary
                var options = new RestClientOptions(RecordingHelper.serverURL)
                {
                    Timeout = new TimeSpan(0, 15, 0)
                };
                var client = new RestClient(options);
                var requestSystemAudio = new RestRequest(summaryPath, Method.Post);
                requestSystemAudio.AlwaysMultipartFormData = true;
                requestSystemAudio.AddParameter("text", text_TranscriptAll);
                RestResponse responseSystemAudio = client.Execute(requestSystemAudio);
                Trace.WriteLine("API result: " + responseSystemAudio.Content);
                try
                {
                    var jsonResult = JObject.Parse(responseSystemAudio.Content);
                    text_SummaryAll = jsonResult["candidates"][0]["content"]["parts"][0]["text"].ToString();
                    Trace.WriteLine("API parsed result: " + text_SummaryAll);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Exception: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("FullConversationSummary - Summary all");
            }
        }
    }
}
