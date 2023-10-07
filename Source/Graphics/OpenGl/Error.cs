namespace Vitimiti.MediaLibraries.OpenGl;

public static class Error
{
    public static unsafe ErrorCode Code =>
        (ErrorCode)((delegate* unmanaged<uint>)Gl.GetInstance().GetExportPointer("glGetError"))();
}