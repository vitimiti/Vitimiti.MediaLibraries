using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public static class Glfw
{
    public delegate void ErrorFunctionDelegate(Error errorCode, string? description);

    public static ErrorFunctionDelegate? SetErrorCallback(ErrorFunctionDelegate? callback)
    {
        IntPtr result;
        if (callback == null)
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
}