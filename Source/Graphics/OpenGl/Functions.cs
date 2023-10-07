namespace Vitimiti.MediaLibraries.OpenGl;

public sealed partial class Gl
{
    public void ActiveShaderProgram(Pipeline pipeline, Program program)
    {
        GetFunctionPointerDelegate<ActiveShaderProgramDelegate>(nameof(ActiveShaderProgram))(pipeline.Id, program.Id);
    }
}