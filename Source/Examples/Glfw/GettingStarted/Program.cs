using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net;

using GlfwVersion = Vitimiti.MediaLibraries.Glfw.Net.Version;
using Monitor = Vitimiti.MediaLibraries.Glfw.Net.Monitor;

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
    ExceptionFunction();
    return;
}

Monitor?[]? monitors = Monitor.Array;
if (monitors is null)
{
    ExceptionFunction();
    return;
}

Console.WriteLine($"Found {monitors.Length} monitor(s)");
Monitor? monitor = Monitor.Primary;
if (monitor is null)
{
    ExceptionFunction();
    return;
}

for (int i = 0; i < monitors.Length; i++)
{
    if (monitors[i] == monitor)
    {
        Console.WriteLine($"Monitor #{i + 1} is the primary monitory");
    }
}

Console.WriteLine($"Primary monitor: {monitor}");

return;

void ErrorCallback(ErrorCode code, string? description)
{
    Console.WriteLine($"[{code}] {description}");
}

void ExceptionFunction()
{
    (ErrorCode code, string? description) = Error.Get();
    throw new ExternalException(description, (int)code);
}