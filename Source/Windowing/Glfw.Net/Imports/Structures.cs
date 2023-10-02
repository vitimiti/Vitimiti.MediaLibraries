using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.Glfw.Net.Imports;

internal static partial class NativeGlfw
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        public int Width;
        public int Height;
        public int RedBits;
        public int GreenBits;
        public int BlueBits;
        public int RefreshRate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GammaRamp
    {
        public IntPtr Red;
        public IntPtr Green;
        public IntPtr Blue;
        public uint Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Image
    {
        public int Width;
        public int Height;
        public IntPtr Pixels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadState
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 15)]
        public byte[] Buttons;

        [MarshalAs(UnmanagedType.LPArray, SizeConst = 6)]
        public float[] Axes;
    }
}