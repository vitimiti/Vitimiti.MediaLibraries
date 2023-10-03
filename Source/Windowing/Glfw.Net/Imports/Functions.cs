using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.Glfw.Net.Imports;

internal static partial class NativeGlfw
{
    private const string LibraryName =
#if Windows
            "glfw3.dll"
#elif OSX
            "libglfw.3.dylib"
#elif Linux
            "libglfw.so.3.3"
#else
        #error Platform not supported
#endif
        ;

    [DllImport(LibraryName, EntryPoint = "glfwInit", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Init();

    [DllImport(LibraryName, EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Terminate();

    [DllImport(LibraryName, EntryPoint = "glfwGetError", CallingConvention = CallingConvention.Cdecl)]
    public static extern ErrorCode GetError(out IntPtr description);

    [DllImport(LibraryName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetErrorCallback(IntPtr callback);

    [DllImport(LibraryName, EntryPoint = "glfwInitHint", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitHint(int hint, int value);

    [DllImport(LibraryName, EntryPoint = "glfwGetVersion", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetVersion(out int major, out int minor, out int revision);

    [DllImport(LibraryName, EntryPoint = "glfwGetVersionString", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetVersionString();

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitors", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetMonitors(out int count);

    [DllImport(LibraryName, EntryPoint = "glfwGetPrimaryMonitor", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetPrimaryMonitor();

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorPos", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorPosition(IntPtr monitor, out int xPos, out int yPos);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorWorkarea", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorWorkArea(IntPtr monitor, out int xPos, out int yPos, out int width,
        out int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorPhysicalSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorPhysicalSize(IntPtr monitor, out int width, out int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorContentScale", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorContentScale(IntPtr monitor, out float xScale, out float yScale);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorName", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetMonitorName(IntPtr monitor);
}