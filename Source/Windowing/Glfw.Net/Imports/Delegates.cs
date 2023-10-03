using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.Glfw.Net.Imports;

internal static partial class NativeGlfw
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorFunctionDelegate(int errorCode, IntPtr description);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MonitorFunctionDelegate(IntPtr monitor, int @event);
}