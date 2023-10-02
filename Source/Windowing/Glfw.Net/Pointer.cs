using Microsoft.Win32.SafeHandles;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Pointer : SafeHandleZeroOrMinusOneIsInvalid
{
    internal Pointer(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
    }

    internal IntPtr GetInternalHandle()
    {
        return handle;
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }
}