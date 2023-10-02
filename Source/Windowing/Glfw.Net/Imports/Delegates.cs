using System.Runtime.InteropServices;

namespace Vitimiti.MediaLibraries.Glfw.Net.Imports;

internal static partial class NativeGlfw
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CharacterFunctionDelegate(IntPtr window, uint codePoint);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CharacterModifiersFunctionDelegate(IntPtr window, uint codePoint, KeyModifiers modifiers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CursorEnterFunctionDelegate(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool entered);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CursorPositionFunctionDelegate(IntPtr window, double xPos, double yPos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DropFunctionDelegate(IntPtr window, int pathCount,
        [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 1)]
        IntPtr[] paths);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorFunctionDelegate(Error errorCode, IntPtr description);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FrameBufferSizeFunctionDelegate(IntPtr window, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void JoystickFunctionDelegate(int jId, Event @event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void KeyFunctionDelegate(IntPtr window, Key key, int scanCode, KeyAndButtonAction action,
        KeyModifiers modifiers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MonitorFunctionDelegate(IntPtr monitor, Event @event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ScrollFunctionDelegate(IntPtr window, double xOffset, double yOffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowCloseFunctionDelegate(IntPtr window);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowContentScaleFunctionDelegate(IntPtr window, float xScale, float yScale);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowFocusFunctionDelegate(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool focused);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowIconifyFunctionDelegate(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool iconified);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowMaximizedFunctionDelegate(IntPtr window, [MarshalAs(UnmanagedType.I1)] bool maximized);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowMouseButtonFunctionDelegate(IntPtr window, MouseButton button, KeyAndButtonAction action,
        KeyModifiers modifiers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowPositionFunctionDelegate(IntPtr window, int xPos, int yPos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowRefreshFunctionDelegate(IntPtr window);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowSizeFunctionDelegate(IntPtr window, int width, int height);
}