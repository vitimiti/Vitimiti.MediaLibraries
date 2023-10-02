using Microsoft.Win32.SafeHandles;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class VideoMode : SafeHandleZeroOrMinusOneIsInvalid
{
    internal VideoMode(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }
}