namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Pointer
{
    private readonly IntPtr _handle;

    internal Pointer(IntPtr handle)
    {
        _handle = handle;
    }

    internal IntPtr GetInternalHandle()
    {
        return _handle;
    }
}