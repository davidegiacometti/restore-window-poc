using System;
using System.Runtime.InteropServices;

namespace RestoreWindow.Structs
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X { get; set; }
        public int Y { get; set; }

        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
