using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using RestoreWindow.Helpers;

namespace RestoreWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var handle = new WindowInteropHelper(this).Handle;
            RestoreHelper.SetPlacement(handle);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            var handle = new WindowInteropHelper(this).Handle;
            RestoreHelper.SarializePlacement(handle);
        }
    }
}
