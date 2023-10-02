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

    [DllImport(LibraryName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetErrorCallback(IntPtr callback);
}