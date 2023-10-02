using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Window : SafeHandleZeroOrMinusOneIsInvalid
{
    internal Window(IntPtr newHandle) : base(true)
    {
        handle = newHandle;
    }

    public bool ShouldClose
    {
        get => NativeGlfw.WindowShouldClose(handle);
        set => NativeGlfw.SetWindowShouldClose(handle, value);
    }

    internal IntPtr GetInternalHandle()
    {
        return handle;
    }

    public static void DefaultHints()
    {
        NativeGlfw.DefaultWindowHints();
    }

    public static void SetHint(WindowHint hint, int value)
    {
        NativeGlfw.WindowHint(hint, value);
    }

    public static void SetHint(WindowHint hint, string? value)
    {
        NativeGlfw.WindowHintString(hint, Marshal.StringToHGlobalAnsi(value));
    }

    protected override bool ReleaseHandle()
    {
        NativeGlfw.DestroyWindow(handle);
        return true;
    }

    public void SetTitle(string? title)
    {
        NativeGlfw.SetWindowTitle(handle, Marshal.StringToHGlobalAnsi(title));
    }
}