using Vitimiti.MediaLibraries.Glfw.Net;

_ = Error.SetCallback(ErrorCallback);

return;

void ErrorCallback(ErrorCode code, string? description)
{
    Console.WriteLine($"[{code}] {description}");
}