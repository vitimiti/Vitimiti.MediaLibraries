using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net;

using GlfwVersion = Vitimiti.MediaLibraries.Glfw.Net.Version;

_ = Error.SetCallback(ErrorCallback);

GlfwVersion glfwVersion = new();
Console.WriteLine($"Using GLFW {glfwVersion}");
if (glfwVersion != GlfwVersion.Expected)
{
    Console.WriteLine($"WARNING: Expected GLFW {GlfwVersion.Expected} but GLFW {glfwVersion} found");
}

using GlfwLibrary? glfwLibrary = GlfwLibrary.Initialize;
if (glfwLibrary is null)
{
    (ErrorCode code, string? description) = Error.Get();
    throw new ExternalException(description, (int)code);
}

return;

void ErrorCallback(ErrorCode code, string? description)
{
    Console.WriteLine($"[{code}] {description}");
}