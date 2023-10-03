using System.Drawing;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Window : SafeHandleZeroOrMinusOneIsInvalid
{
    public delegate void PositionFunctionDelegate(Window window, Point position);

    public delegate void SizeFunctionDelegate(Window window, Size size);

    internal Window(IntPtr newHandle) : base(true)
    {
        handle = newHandle;
    }

    public bool ShouldClose
    {
        get => NativeGlfw.WindowShouldClose(handle);
        set => NativeGlfw.SetWindowShouldClose(handle, value);
    }

    public Point Position
    {
        get
        {
            NativeGlfw.GetWindowPos(handle, out int xPos, out int yPos);
            return new Point(xPos, yPos);
        }
        set => NativeGlfw.SetWindowPos(handle, value.X, value.Y);
    }

    public Size Size
    {
        get
        {
            NativeGlfw.GetWindowSize(handle, out int width, out int height);
            return new Size(width, height);
        }
        set => NativeGlfw.SetWindowSize(handle, value.Width, value.Height);
    }

    public Size FramebufferSize
    {
        get
        {
            NativeGlfw.GetFramebufferSize(handle, out int width, out int height);
            return new Size(width, height);
        }
    }

    public (int Left, int Top, int Right, int Bottom) FrameSize
    {
        get
        {
            NativeGlfw.GetWindowFrameSize(handle, out int left, out int top, out int right, out int bottom);
            return (left, top, right, bottom);
        }
    }

    public (float XScale, float YScale) ContentScale
    {
        get
        {
            NativeGlfw.GetWindowContentScale(handle, out float xScale, out float yScale);
            return (xScale, yScale);
        }
    }

    public float Opacity
    {
        get => NativeGlfw.GetWindowOpacity(handle);
        set => NativeGlfw.SetWindowOpacity(handle, value);
    }

    public Monitor? Monitor
    {
        get
        {
            IntPtr monitor = NativeGlfw.GetWindowMonitor(handle);
            return monitor == IntPtr.Zero ? null : new Monitor(monitor);
        }
    }

    public Pointer? UserPointer
    {
        get
        {
            IntPtr pointer = NativeGlfw.GetWindowUserPointer(handle);
            return pointer == IntPtr.Zero ? null : new Pointer(pointer);
        }
        set => NativeGlfw.SetWindowUserPointer(handle, value?.GetInternalHandle() ?? IntPtr.Zero);
    }

    internal IntPtr GetInternalHandle()
    {
        return handle;
    }

    public static void DefaultHints()
    {
        NativeGlfw.DefaultWindowHints();
    }

    public static void SetHint(int hint, int value)
    {
        NativeGlfw.WindowHint(hint, value);
    }

    public static void SetHint(int hint, string? value)
    {
        NativeGlfw.WindowHintString(hint, Marshal.StringToHGlobalAnsi(value));
    }

    protected override bool ReleaseHandle()
    {
        NativeGlfw.DestroyWindow(handle);
        return true;
    }

    public void SetTitle(string? title)
    {
        NativeGlfw.SetWindowTitle(handle, Marshal.StringToHGlobalAnsi(title));
    }

    public void SetIcon(Image[] images)
    {
        NativeGlfw.Image[] nativeImages = new NativeGlfw.Image[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            nativeImages[i].Width = images[i].Size.Width;
            nativeImages[i].Height = images[i].Size.Height;

            byte[] pixelsArray = images[i].Pixels.ToArray();
            IntPtr pixelsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(pixelsArray[i]) * images[i].Pixels.Length);
            Marshal.Copy(pixelsArray, 0, pixelsPtr, images[i].Pixels.Length);
            nativeImages[i].Pixels = pixelsPtr;
        }

        NativeGlfw.SetWindowIcon(handle, images.Length, nativeImages);
    }

    public void SetSizeLimits(Size minimum, Size maximum)
    {
        NativeGlfw.SetWindowSizeLimits(handle, minimum.Width, minimum.Height, maximum.Width, maximum.Height);
    }

    public void SetAspectRatio(int numerator, int denominator)
    {
        NativeGlfw.SetWindowAspectRatio(handle, numerator, denominator);
    }

    public void Iconify()
    {
        NativeGlfw.IconifyWindow(handle);
    }

    public void Restore()
    {
        NativeGlfw.RestoreWindow(handle);
    }

    public void Maximize()
    {
        NativeGlfw.MaximizeWindow(handle);
    }

    public void Show()
    {
        NativeGlfw.ShowWindow(handle);
    }

    public void Hide()
    {
        NativeGlfw.HideWindow(handle);
    }

    public void Focus()
    {
        NativeGlfw.FocusWindow(handle);
    }

    public void RequestAttention()
    {
        NativeGlfw.RequestWindowAttention(handle);
    }

    public void SetMonitor(Monitor? monitor, Point position, Size size, int refreshRate)
    {
        NativeGlfw.SetWindowMonitor(handle, monitor?.GetInternalHandle() ?? IntPtr.Zero, position.X, position.Y,
            size.Width, size.Height, refreshRate);
    }

    public int GetAttribute(WindowAttribute attribute)
    {
        return NativeGlfw.GetWindowAttribute(handle, attribute);
    }

    public void SetAttribute(WindowAttribute attribute, int value)
    {
        NativeGlfw.SetWindowAttribute(handle, attribute, value);
    }

    public PositionFunctionDelegate? SetPositionCallback(PositionFunctionDelegate? callback)
    {
        IntPtr result;
        if (callback is null)
        {
            result = NativeGlfw.SetWindowPosCallback(handle, IntPtr.Zero);
        }
        else
        {
            void InternalCallback(IntPtr window, int xPos, int yPos)
            {
                callback.Invoke(new Window(window), new Point(xPos, yPos));
            }

            result = NativeGlfw.SetWindowPosCallback(handle,
                Marshal.GetFunctionPointerForDelegate((NativeGlfw.WindowPositionFunctionDelegate)InternalCallback));
        }

        if (result == IntPtr.Zero)
        {
            return null;
        }

        NativeGlfw.WindowPositionFunctionDelegate nativeCallback =
            Marshal.GetDelegateForFunctionPointer<NativeGlfw.WindowPositionFunctionDelegate>(result);

        return (window, position) => nativeCallback.Invoke(window.handle, position.X, position.Y);
    }

    public SizeFunctionDelegate? SetSizeCallback(SizeFunctionDelegate? callback)
    {
        IntPtr result;
        if (callback is null)
        {
            result = NativeGlfw.SetWindowPosCallback(handle, IntPtr.Zero);
        }
        else
        {
            void InternalCallback(IntPtr window, int width, int height)
            {
                callback.Invoke(new Window(window), new Size(width, height));
            }

            result = NativeGlfw.SetWindowPosCallback(handle,
                Marshal.GetFunctionPointerForDelegate((NativeGlfw.WindowSizeFunctionDelegate)InternalCallback));
        }

        if (result == IntPtr.Zero)
        {
            return null;
        }

        NativeGlfw.WindowSizeFunctionDelegate nativeCallback =
            Marshal.GetDelegateForFunctionPointer<NativeGlfw.WindowSizeFunctionDelegate>(result);

        return (window, position) => nativeCallback.Invoke(window.handle, position.Width, position.Height);
    }
}