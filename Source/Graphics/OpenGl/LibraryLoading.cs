using System.Reflection;
using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl;

internal static class Gl
{
    private static readonly IntPtr LibraryHandle = NativeLibrary.Load(GetLibraryName(), Assembly.GetCallingAssembly(),
        DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.ApplicationDirectory |
        DllImportSearchPath.UseDllDirectoryForDependencies);

    static Gl()
    {
        AppDomain.CurrentDomain.DomainUnload += (_, _) => NativeLibrary.Free(LibraryHandle);
        AppDomain.CurrentDomain.ProcessExit += (_, _) => NativeLibrary.Free(LibraryHandle);
    }

    private static string GetLibraryName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "opengl32.dll";
        }

        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "libGL.dylib" : "libGL.so";
    }

    public static IntPtr GetExportPointer(string entryPoint)
    {
        return NativeLibrary.GetExport(LibraryHandle, entryPoint);
    }
}