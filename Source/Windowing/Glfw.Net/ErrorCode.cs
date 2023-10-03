namespace Vitimiti.MediaLibraries.Glfw.Net;

public enum ErrorCode
{
    None = 0x000000,
    NotInitialized = 0x010001,
    NoCurrentContext = 0x010002,
    InvalidEnum = 0x010003,
    InvalidValue = 0x010004,
    OutOfMemory = 0x010005,
    ApiUnavailable = 0x010006,
    VersionUnavailable = 0x010007,
    PlatformError = 0x010008,
    FormatUnavailable = 0x010009,
    NoWindowContext = 0x01000A
}