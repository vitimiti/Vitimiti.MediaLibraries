namespace Vitimiti.MediaLibraries.OpenGl;

public sealed partial class Gl
{
    public unsafe void ActiveShaderProgram(Pipeline pipeline, Program program)
    {
        ((delegate*unmanaged<uint, uint, void>)GetFunctionPointerDelegate(nameof(ActiveShaderProgram)))(pipeline.Id,
            pipeline.Id);
    }
}