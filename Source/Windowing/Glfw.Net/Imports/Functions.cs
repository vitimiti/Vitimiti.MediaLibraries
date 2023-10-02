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
    public static extern void Init();

    [DllImport(LibraryName, EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Terminate();

    [DllImport(LibraryName, EntryPoint = "glfwInitHint", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitHint(InitHint hint, int value);

    [DllImport(LibraryName, EntryPoint = "glfwGetVersion", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetVersion(out int major, out int minor, out int revision);

    [DllImport(LibraryName, EntryPoint = "glfwGetVersionString", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetVersionString();

    [DllImport(LibraryName, EntryPoint = "glfwGetError", CallingConvention = CallingConvention.Cdecl)]
    public static extern Error GetError(out IntPtr description);

    [DllImport(LibraryName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetErrorCallback(IntPtr callback);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitors", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetMonitors(out int count);

    [DllImport(LibraryName, EntryPoint = "glfwGetPrimaryMonitor", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetPrimaryMonitor();

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorPos", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorPos(IntPtr monitor, out int xPos, out int yPos);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorWorkarea", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorWorkArea(IntPtr monitor, out int xPos, out int yPos, out int width,
        out int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorPhysicalSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorPhysicalSize(IntPtr monitor, out int width, out int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorContentScale", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMonitorContentScale(IntPtr monitor, out float xScale, out float yScale);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorName", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetMonitorName(IntPtr monitor);

    [DllImport(LibraryName, EntryPoint = "glfwSetMonitorUserPointer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMonitorUserPointer(IntPtr monitor, IntPtr pointer);

    [DllImport(LibraryName, EntryPoint = "glfwGetMonitorUserPointer", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr glfwGetMonitorUserPointer(IntPtr monitor);

    [DllImport(LibraryName, EntryPoint = "glfwSetMonitorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetMonitorCallback(IntPtr callback);

    [DllImport(LibraryName, EntryPoint = "glfwGetVideoModes", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetVideoModes(IntPtr monitor, out int count);

    [DllImport(LibraryName, EntryPoint = "glfwGetVideoMode", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetVideoMode(IntPtr monitor);

    [DllImport(LibraryName, EntryPoint = "glfwSetGamma", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetGamma(IntPtr monitor, float gamma);

    [DllImport(LibraryName, EntryPoint = "glfwGetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetGammaRamp(IntPtr monitor);

    [DllImport(LibraryName, EntryPoint = "glfwSetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetGammaRamp(IntPtr monitor, IntPtr ramp);

    [DllImport(LibraryName, EntryPoint = "glfwDefaultWindowHints", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DefaultWindowHints();

    [DllImport(LibraryName, EntryPoint = "glfwWindowHint", CallingConvention = CallingConvention.Cdecl)]
    public static extern void WindowHint(WindowHint hint, int value);

    [DllImport(LibraryName, EntryPoint = "glfwWindowHintString", CallingConvention = CallingConvention.Cdecl)]
    public static extern void WindowHintString(WindowHint hint, IntPtr value);

    [DllImport(LibraryName, EntryPoint = "glfwCreateWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr CreateWindow(int width, int height, IntPtr title, IntPtr monitor, IntPtr share);

    [DllImport(LibraryName, EntryPoint = "glfwDestroyWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DestroyWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool WindowShouldClose(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowShouldClose(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool value);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowTitle(IntPtr window, IntPtr title);
}