using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SideBar_Nav.Pages;

namespace SideBar_Nav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize with the Record page
            ccPageContent.Content = new RecordPage();

            // Attach navigation button handlers
            btnRecord.Click += (s, e) => { ccPageContent.Content = new RecordPage(); };
            btnMeetingSummary.Click += (s, e) => { ccPageContent.Content = new MeetingSummaryPage(); };
            btnSettings.Click += (s, e) => { ccPageContent.Content = new SettingsPage(); };
        }
    }
}
  