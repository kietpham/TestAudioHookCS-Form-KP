using System;
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
        // Import a function from the native DLL for demonstration (optional)
        [DllImport("DemoLibrary.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetData();

        public MeetingSummaryPage()
        {
            InitializeComponent();
            SummaryButton.Click += SummaryButton_Click;
        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Simulate generating a summary by calling GetData from the DLL
                IntPtr ptr = GetData();
                string summary = Marshal.PtrToStringAnsi(ptr) ?? string.Empty;
                NotesBox.Text = summary;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating summary: {ex.Message}", "DLL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}