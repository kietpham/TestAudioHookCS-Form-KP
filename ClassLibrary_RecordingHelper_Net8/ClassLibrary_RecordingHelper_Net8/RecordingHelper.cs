using NAudio.Wave;
using Newtonsoft.Json.Linq;
using RestSharp;
//using Vosk;

namespace ClassLibrary_RecordingHelper_Net8
{
    public static class RecordingHelper
    {
        //public static Model voskModel;
        public static int sleepTime;
        public static int micSampleRate;
        public static int systemAudioSampleRate;
        public static int currentProcessID = 0;
        public static string currentProcessName;
        public static string serverURL;
        public static string serverPath;
        public static string text_LabelVoskTranscriptSystemAudio;   // Transcript text add in during run
        public static string text_LabelVoskTranscriptMicIn;         // Transcript text add in during run
        public static string text_LabelMSTranscriptSystemAudio;     // Transcript text add in during run
        public static string text_LabelMSTranscriptMicIn;           // Transcript text add in during run
        public static string outputMicRecordFileName = "";
        public static string outputSystemRecordFileName = "";
        public static WasapiLoopbackCapture capture;
        public static WaveInEvent waveIn;
        public static int threadMicRecordControl; // 1 start, 2 stop
        public static int threadSystemAudioRecordControl; // 1 start, 2 stop
        public static bool checkBox_RecordFile_System;
        public static bool checkBox_RecordFile_Mic;
        public static bool checkBox_SystemAudio_Use_Vosk;
        public static bool checkBox_SystemAudio_Use_MS;
        public static bool checkBox_Mic_Use_Vosk;
        public static bool checkBox_Mic_Use_MS;
        public static void RecordSystemAudio()
        {
            Console.WriteLine("RecordSystemAudio");
            int i = 0;
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
                capture.RecordingStopped += (s, e) => { Console.WriteLine("Capture Recording Stopped"); };

                capture.StartRecording();
                Thread.Sleep(sleepTime);
                capture.StopRecording();

                var soundByteArray = byteBuffer.ToArray();

                // Save file
                string fileOutputName = outputSystemRecordFileName + i.ToString() + ".wav";
                if (checkBox_RecordFile_System == true)
                {
                    var writer = new WaveFileWriter(fileOutputName, capture.WaveFormat);
                    writer.Write(soundByteArray, 0, soundByteArray.Length);
                    writer.Flush();
                    writer.Close();
                }
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
                    //Console.WriteLine("API: " + response.Content);
                    var jsonResult = JObject.Parse(response.Content);
                    var result = jsonResult["candidates"][0]["content"]["parts"][0]["text"];
                    text_LabelMSTranscriptSystemAudio += result + " | ";
                }
                if (threadSystemAudioRecordControl == 2)
                {
                    capture.Dispose();
                    return;
                }
                i++;
            }
        }
        public static void RecordMicIn()
        {
            Console.WriteLine("RecordMicIn");
            int i = 0;
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
                    string fileOutputName = outputMicRecordFileName + i.ToString() + ".wav";
                    if (checkBox_RecordFile_Mic == true)
                    {
                        var waveFile = new WaveFileWriter(fileOutputName, waveFormat);
                        waveFile.Write(soundByteArray, 0, soundByteArray.Length);
                        waveFile.Flush();
                        waveFile.Close();
                    }
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
                        //Console.WriteLine("API: " + response.Content);
                        var jsonResult = JObject.Parse(response.Content);
                        var result = jsonResult["candidates"][0]["content"]["parts"][0]["text"];
                        text_LabelMSTranscriptMicIn += result + " | ";
                    }
                    if (threadMicRecordControl == 2) return;
                    i++;
                }
            }
        }
    }
}
