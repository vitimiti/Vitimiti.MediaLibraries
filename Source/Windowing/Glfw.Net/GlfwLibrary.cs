using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public sealed class GlfwLibrary : IDisposable
{
    private GlfwLibrary()
    {
    }

    public static GlfwLibrary? Initialize
    {
        get
        {
            bool valid = (Constants)NativeGlfw.Init() == Constants.True;
            return valid ? new GlfwLibrary() : null;
        }
    }

    public void Dispose()
    {
        NativeGlfw.Terminate();
    }
}