using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for MeetingSummaryPage.xaml
    /// </summary>
    public partial class MeetingSummaryPage : UserControl
    {
        private string textSummarySystemAudio;
        private string textSummaryMicIn;
        public MeetingSummaryPage()
        {
            InitializeComponent();
        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
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
            var textSystemAudio = RecordingHelper.text_LabelMSTranscriptSystemAudio.Replace(" | ", string.Empty);
            requestSystemAudio.AddBody("text", textSystemAudio);
            RestResponse responseSystemAudio = client.Execute(requestSystemAudio);
            Trace.WriteLine("API result: " + responseSystemAudio.Content);
            try
            {
                var jsonResult = JObject.Parse(responseSystemAudio.Content);
                textSummarySystemAudio = jsonResult["candidates"][0]["content"]["parts"][0]["text"].ToString();
                Trace.WriteLine("API parsed result: " + textSummarySystemAudio);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception: " + ex.ToString());
            }

            var requestMicIn = new RestRequest(summaryPath, Method.Post);
            requestMicIn.AlwaysMultipartFormData = true;
            var textMicIn = RecordingHelper.text_LabelMSTranscriptSystemAudio.Replace(" | ", string.Empty);
            requestMicIn.AddBody("text", textMicIn);
            RestResponse responseMicIn = client.Execute(requestMicIn);
            Trace.WriteLine("API result: " + responseMicIn.Content);
            try
            {
                var jsonResult = JObject.Parse(responseMicIn.Content);
                textSummaryMicIn = jsonResult["candidates"][0]["content"]["parts"][0]["text"].ToString();
                Trace.WriteLine("API parsed result: " + textSummaryMicIn);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception: " + ex.ToString());
            }
            // Handle textSummarySystemAudio and textSummaryMicIn
        }
    }
}