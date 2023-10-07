namespace Vitimiti.MediaLibraries.OpenGl;

public enum ErrorCode : uint
{
    None = 0x0000,
    InvalidEnum = 0x0500,
    InvalidValue = 0x0501,
    InvalidOperation = 0x0502,
    StackOverflow = 0x0503,
    StackUnderflow = 0x0504,
    OutOfMemory = 0x0505,
    InvalidFramebufferOperation = 0x0506,
    ContextLost = 0x0507,
    TableTooLarge = 0x8031
}