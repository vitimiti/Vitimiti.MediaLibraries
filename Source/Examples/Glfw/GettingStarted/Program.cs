using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net;

_ = Error.SetCallback(ErrorCallback);

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