using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public static class Glfw
{
    public delegate void ErrorFunctionDelegate(Error errorCode, string? description);

    public static void Init()
    {
        NativeGlfw.Init();
    }

    public static void Terminate()
    {
        NativeGlfw.Terminate();
    }

    public static void InitHint(InitHint hint, int value)
    {
        NativeGlfw.InitHint(hint, value);
    }

    public static (Error Error, string? Description) GetError()
    {
        Error error = NativeGlfw.GetError(out IntPtr description);
        return (error, Marshal.PtrToStringAnsi(description));
    }

    public static ErrorFunctionDelegate? SetErrorCallback(ErrorFunctionDelegate? callback)
    {
        IntPtr result;
        if (callback is null)
        {
            result = NativeGlfw.SetErrorCallback(IntPtr.Zero);
        }
        else
        {
            void InternalCallback(Error code, IntPtr description)
            {
                callback.Invoke(code, Marshal.PtrToStringAnsi(description));
            }

            result = NativeGlfw.SetErrorCallback(
                Marshal.GetFunctionPointerForDelegate((NativeGlfw.ErrorFunctionDelegate)InternalCallback));
        }

        if (result == IntPtr.Zero)
        {
            return null;
        }

        NativeGlfw.ErrorFunctionDelegate nativeCallback =
            Marshal.GetDelegateForFunctionPointer<NativeGlfw.ErrorFunctionDelegate>(result);

        return (code, description) => nativeCallback.Invoke(code, Marshal.StringToHGlobalAnsi(description));
    }

    public static Monitor?[]? GetMonitors()
    {
        IntPtr nativeMonitors = NativeGlfw.GetMonitors(out int count);
        if (nativeMonitors == IntPtr.Zero)
        {
            return null;
        }

        Monitor?[] monitors = new Monitor?[count];
        IntPtr[] monitorsPtrArray = new IntPtr[count];
        for (int i = 0; i < count; i++)
        {
            monitorsPtrArray[i] = Marshal.AllocHGlobal(Marshal.SizeOf(nativeMonitors) / count);
        }

        Marshal.Copy(nativeMonitors, monitorsPtrArray, 0, count);
        for (int i = 0; i < count; i++)
        {
            monitors[i] = monitorsPtrArray[i] == IntPtr.Zero ? null : new Monitor(monitorsPtrArray[i]);
        }

        return monitors;
    }
}