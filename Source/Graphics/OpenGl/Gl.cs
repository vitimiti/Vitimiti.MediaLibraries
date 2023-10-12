using System.Reflection;
using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl;

internal static class Gl
{
    private static readonly IntPtr Handle = NativeLibrary.Load(GetLibraryName(), Assembly.GetExecutingAssembly(),
        DllImportSearchPath.UseDllDirectoryForDependencies);

    static Gl()
    {
        AppDomain.CurrentDomain.ProcessExit += (_, _) => NativeLibrary.Free(Handle);
    }

    private static string GetLibraryName()
    {
        return Environment.OSVersion.Platform switch
        {
            PlatformID.Win32NT => LibraryNames.WindowsAssemblyName,
            PlatformID.MacOSX => LibraryNames.OsxAssemblyName,
            PlatformID.Unix => LibraryNames.LinuxAssemblyName,
            PlatformID.Other => LibraryNames.LinuxAssemblyName,
            _ => throw new PlatformNotSupportedException()
        };
    }

    private struct LibraryNames
    {
        public const string WindowsAssemblyName = "opengl32.dll";
        public const string OsxAssemblyName = "libGL.dylib";
        public const string LinuxAssemblyName = "libGL.so";
    }
}