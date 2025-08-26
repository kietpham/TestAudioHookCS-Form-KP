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
            if(RecordingHelper.text_TranscriptAll == "") RecordingHelper.FullConversationTranscript();
            rtbxImportantNotes.AppendText(RecordingHelper.text_TranscriptAll + "\r\n");
            RecordingHelper.FullConversationSummary();
            rtbxImportantNotes.AppendText("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\r\n");
            rtbxImportantNotes.AppendText(RecordingHelper.text_SummaryAll + "\r\n");
        }
    }
}