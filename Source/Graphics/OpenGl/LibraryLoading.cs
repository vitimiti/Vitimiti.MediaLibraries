using System.Reflection;
using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl;

internal sealed class Gl : IDisposable
{
    private static readonly Gl? Instance = null;

    private readonly IntPtr _libraryHandle = NativeLibrary.Load(GetLibraryName(), Assembly.GetCallingAssembly(),
        DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.ApplicationDirectory |
        DllImportSearchPath.UseDllDirectoryForDependencies);

    private Gl()
    {
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    private void ReleaseUnmanagedResources()
    {
        NativeLibrary.Free(_libraryHandle);
    }

    ~Gl()
    {
        ReleaseUnmanagedResources();
    }

    public static Gl GetInstance()
    {
        return Instance ?? new Gl();
    }

    private static string GetLibraryName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "opengl32.dll";
        }

        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "libGL.dylib" : "libGL.so";
    }

    public IntPtr GetExportPointer(string entryPoint)
    {
        return NativeLibrary.GetExport(_libraryHandle, entryPoint);
    }
}