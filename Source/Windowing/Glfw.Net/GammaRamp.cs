using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class GammaRamp : SafeHandleZeroOrMinusOneIsInvalid
{
    internal GammaRamp(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
        NativeGlfw.GammaRamp nativeGammaRamp =
            (NativeGlfw.GammaRamp)(Marshal.PtrToStructure(newHandle, typeof(NativeGlfw.GammaRamp)) ??
                                   new NativeGlfw.GammaRamp());

        Red = new ushort[nativeGammaRamp.Size];
        Green = new ushort[nativeGammaRamp.Size];
        Blue = new ushort[nativeGammaRamp.Size];

        int[] signedRed = new int[nativeGammaRamp.Size];
        Marshal.Copy(nativeGammaRamp.Red, signedRed, 0, (int)nativeGammaRamp.Size);
        for (int i = 0; i < (int)nativeGammaRamp.Size; i++)
        {
            Red[i] = (ushort)signedRed[i];
        }

        int[] signedGreen = new int[nativeGammaRamp.Size];
        Marshal.Copy(nativeGammaRamp.Green, signedGreen, 0, (int)nativeGammaRamp.Size);
        for (int i = 0; i < (int)nativeGammaRamp.Size; i++)
        {
            Green[i] = (ushort)signedGreen[i];
        }

        int[] signedBlue = new int[nativeGammaRamp.Size];
        Marshal.Copy(nativeGammaRamp.Blue, signedBlue, 0, (int)nativeGammaRamp.Size);
        for (int i = 0; i < (int)nativeGammaRamp.Size; i++)
        {
            Blue[i] = (ushort)signedBlue[i];
        }
    }

    public ushort[] Red { get; }
    public ushort[] Green { get; }
    public ushort[] Blue { get; }

    internal IntPtr GetInternalHandle()
    {
        return handle;
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }
}