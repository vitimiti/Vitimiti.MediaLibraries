using System.Reflection;
using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl;

public sealed partial class Gl : IDisposable
{
    private readonly IntPtr _libraryHandle = NativeLibrary.Load(GetLibraryName(), Assembly.GetCallingAssembly(),
        DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.ApplicationDirectory |
        DllImportSearchPath.UseDllDirectoryForDependencies);

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

    private static string GetLibraryName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "opengl32.dll";
        }

        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "libGL.dylib" : "libGL.so";
    }

    private IntPtr GetFunctionPointerDelegate(string functionName)
    {
        return NativeLibrary.GetExport(_libraryHandle, $"gl{functionName}");
    }
}