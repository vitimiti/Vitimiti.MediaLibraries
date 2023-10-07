using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.OpenGl;

public sealed partial class Gl
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void ActiveShaderProgramDelegate(uint pipeline, uint program);
}