using System.Reflection;
using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl.Library;

internal static partial class Gl
{
    private static readonly string LibraryName = InitLibraryName();

    private static readonly IntPtr LibraryHandle = NativeLibrary.Load(LibraryName, Assembly.GetCallingAssembly(),
        DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.ApplicationDirectory |
        DllImportSearchPath.UseDllDirectoryForDependencies);

    static Gl()
    {
        AppDomain.CurrentDomain.DomainUnload += (_, _) => NativeLibrary.Free(LibraryHandle);
        AppDomain.CurrentDomain.ProcessExit += (_, _) => NativeLibrary.Free(LibraryHandle);
    }

    private static string InitLibraryName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "opengl32.dll";
        }

        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "libGL.dylib" : "libGL.so";
    }

    private static TDelegate GetFunctionPointerDelegate<TDelegate>(EntryPoint entryPoint) where TDelegate : Delegate
    {
        return Marshal.GetDelegateForFunctionPointer<TDelegate>(NativeLibrary.GetExport(LibraryHandle,
            EntryPointNames[(int)entryPoint]));
    }
}