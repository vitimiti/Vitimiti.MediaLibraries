using System.Drawing;
using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net;

try
{
    Glfw.SetErrorCallback(ErrorCallback);
    if (!Glfw.Init())
    {
        (Error code, string? description) = Glfw.GetError();
        throw new ExternalException(description, (int)code);
    }

    Window.SetHint((int)ContextClientApiHint.VersionMajor, 2);
    Window.SetHint((int)ContextClientApiHint.VersionMinor, 0);

    using Window? window = Glfw.CreateWindow(new Size(640, 480), "Getting Started (GLFW)", null, null);
    if (window is null)
    {
        (Error code, string? description) = Glfw.GetError();
        throw new ExternalException(description, (int)code);
    }

    while (!window.ShouldClose)
    {
        // Add processing here
    }
}
finally
{
    Glfw.Terminate();
}

return;

void ErrorCallback(Error code, string? description)
{
    Console.WriteLine($"[{code}] {description}");
}