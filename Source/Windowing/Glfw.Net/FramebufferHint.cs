namespace Vitimiti.MediaLibraries.Glfw.Net;

public enum FramebufferHint
{
    DontCare = -1,
    RedBits = 0x00021001,
    GreenBits = 0x00021002,
    BlueBits = 0x00021003,
    AlphaBits = 0x00021004,
    DepthBits = 0x00021005,
    StencilBits = 0x00021006,
    AccumRedBits = 0x00021007,
    AccumGreenBits = 0x00021008,
    AccumBlueBits = 0x00021009,
    AccumAlphaBits = 0x0002100A,
    AuxBuffers = 0x0002100B,
    Stereo = 0x0002100C,
    Samples = 0x0002100D,
    SrgbCapable = 0x0002100E,
    RefreshRate = 0x0002100F,
    DoubleBuffer
}