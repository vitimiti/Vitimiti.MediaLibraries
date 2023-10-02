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

    [DllImport(LibraryName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetErrorCallback(IntPtr callback);
}