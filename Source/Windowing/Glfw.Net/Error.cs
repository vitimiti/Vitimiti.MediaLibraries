using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public static class Error
{
    public delegate void Function(ErrorCode errorCode, string? description);

    public static (ErrorCode ErrorCode, string? Description) Get()
    {
        ErrorCode errorCode = NativeGlfw.GetError(out IntPtr description);
        return (errorCode, Marshal.PtrToStringAnsi(description));
    }

    public static Function? SetCallback(Function? callback)
    {
        IntPtr result;
        if (callback is null)
        {
            result = NativeGlfw.SetErrorCallback(IntPtr.Zero);
        }
        else
        {
            result = NativeGlfw.SetErrorCallback(
                Marshal.GetFunctionPointerForDelegate((NativeGlfw.ErrorFunctionDelegate)NativeErrorCallback));

            void NativeErrorCallback(int code, IntPtr description)
            {
                callback.Invoke((ErrorCode)code, Marshal.PtrToStringAnsi(description));
            }
        }

        if (result == IntPtr.Zero)
        {
            return null;
        }

        NativeGlfw.ErrorFunctionDelegate nativeCallback =
            Marshal.GetDelegateForFunctionPointer<NativeGlfw.ErrorFunctionDelegate>(result);

        return (code, description) => nativeCallback.Invoke((int)code, Marshal.StringToHGlobalAnsi(description));
    }
}