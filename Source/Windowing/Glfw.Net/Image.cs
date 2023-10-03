using System.Drawing;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Image : SafeHandleZeroOrMinusOneIsInvalid
{
    internal Image(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
        NativeGlfw.Image nativeImage =
            (NativeGlfw.Image)(Marshal.PtrToStructure(newHandle, typeof(NativeGlfw.Image)) ?? new NativeGlfw.Image());

        Size = new Size(nativeImage.Width, nativeImage.Height);
        int count = Size.Width * Size.Height;
        byte[] pixels = new byte[count];
        Marshal.Copy(nativeImage.Pixels, pixels, 0, count);
        Pixels = new Memory<byte>(pixels);
    }

    public Size Size { get; }
    public Memory<byte> Pixels { get; }

    protected override bool ReleaseHandle()
    {
        return true;
    }
}