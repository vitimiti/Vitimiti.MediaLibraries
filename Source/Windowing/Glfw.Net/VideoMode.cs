namespace Vitimiti.MediaLibraries.Glfw.Net;

public class VideoMode
{
    private readonly IntPtr _handle;

    internal VideoMode(IntPtr handle)
    {
        _handle = handle;
    }
}