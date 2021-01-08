using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using RestoreWindow.Structs;

namespace RestoreWindow.Helpers
{
    public static class RestoreHelper
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMAXIMIZED = 3;
        private const string _path = "placement.json";

        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        public static void SetPlacement(IntPtr windowHandle)
        {
            if (!File.Exists(_path))
            {
                return;
            }

            var json = File.ReadAllText(_path);
            var placement = JsonSerializer.Deserialize<WINDOWPLACEMENT>(json);

            try
            {
                placement.Length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                placement.Flags = 0;
                placement.ShowCmd = placement.ShowCmd == SW_SHOWMAXIMIZED ? SW_SHOWMAXIMIZED : SW_SHOWNORMAL;
                SetWindowPlacement(windowHandle, ref placement);
            }
            catch
            {
                // Handle exception
            }
        }

        public static void SarializePlacement(IntPtr windowHandle)
        {
            GetWindowPlacement(windowHandle, out WINDOWPLACEMENT placement);

            var json = JsonSerializer.Serialize(placement);
            File.WriteAllText(_path, json);
        }
    }
}
