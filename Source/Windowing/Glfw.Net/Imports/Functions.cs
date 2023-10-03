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
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool Init();

    [DllImport(LibraryName, EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Terminate();

    [DllImport(LibraryName, EntryPoint = "glfwInitHint", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitHint(int hint, int value);

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
    public static extern void WindowHint(int hint, int value);

    [DllImport(LibraryName, EntryPoint = "glfwWindowHintString", CallingConvention = CallingConvention.Cdecl)]
    public static extern void WindowHintString(int hint, IntPtr value);

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

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowIcon", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowIcon(IntPtr window, int count,
        [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 1)]
        Image[] images);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowPos", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetWindowPos(IntPtr window, out int xPos, out int yPos);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowPos", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowPos(IntPtr window, int xPos, int yPos);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetWindowSize(IntPtr window, out int width, out int height);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowSizeLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowSizeLimits(IntPtr window, int minimumWidth, int minimumHeight, int maximumWidth,
        int maximumHeight);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowAspectRatio", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowAspectRatio(IntPtr window, int numerator, int denominator);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowSize(IntPtr window, int width, int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetFramebufferSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetFramebufferSize(IntPtr window, out int width, out int height);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowFrameSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right,
        out int bottom);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowContentScale", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetWindowContentScale(IntPtr window, out float xScale, out float yScale);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetWindowOpacity(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowOpacity(IntPtr window, float opacity);

    [DllImport(LibraryName, EntryPoint = "glfwIconifyWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void IconifyWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwRestoreWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RestoreWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwMaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void MaximizeWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwShowWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShowWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwHideWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void HideWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwFocusWindow", CallingConvention = CallingConvention.Cdecl)]
    public static extern void FocusWindow(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwRequestWindowAttention", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RequestWindowAttention(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowMonitor", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetWindowMonitor(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowMonitor", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowMonitor(IntPtr window, IntPtr monitor, int xPos, int yPos, int width, int height,
        int refreshRate);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowAttrib", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetWindowAttribute(IntPtr window, WindowAttribute attribute);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowAttrib", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowAttribute(IntPtr window, WindowAttribute attribute, int value);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

    [DllImport(LibraryName, EntryPoint = "glfwGetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetWindowUserPointer(IntPtr window);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowPosCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetWindowPosCallback(IntPtr window, IntPtr callback);

    [DllImport(LibraryName, EntryPoint = "glfwSetWindowSizeCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetWindowSizeCallback(IntPtr window, IntPtr callback);
}