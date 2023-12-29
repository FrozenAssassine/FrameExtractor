using Microsoft.UI.Xaml;
using System;

namespace FrameExtractor
{
    public partial class App : Application
    {
        public static IntPtr HWND_Handle;

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
            HWND_Handle = WinRT.Interop.WindowNative.GetWindowHandle(m_window);
        }

        private Window m_window;
    }
}
