using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for RecordPage.xaml
    /// </summary>
    public partial class RecordPage : UserControl
    {
        private bool isHintPanelShowed;

        public RecordPage()
        {
            InitializeComponent();
            isHintPanelShowed = false;
        }

        private void btnHint_Click(object sender, RoutedEventArgs e)
        {
            Button? btnObj = sender as Button;

            if (isHintPanelShowed)
            {
                spHint.Visibility = Visibility.Hidden;
                btnObj.Content = "Show Hint";
                isHintPanelShowed = false;
            }
            else 
            {
                spHint.Visibility = Visibility.Visible;
                btnObj.Content = "Hide Hint";
                isHintPanelShowed = true;
            }

            
        }
    }
}