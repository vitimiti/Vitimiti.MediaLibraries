using System.Drawing;
using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Monitor
{
    public delegate void FunctionDelegate(Monitor monitor, Event @event);

    private readonly IntPtr _handle;

    internal Monitor(IntPtr handle)
    {
        _handle = handle;
    }

    public static Monitor? Primary
    {
        get
        {
            IntPtr monitor = NativeGlfw.GetPrimaryMonitor();
            return monitor == IntPtr.Zero ? null : new Monitor(monitor);
        }
    }

    public Point Position
    {
        get
        {
            NativeGlfw.GetMonitorPos(_handle, out int xPos, out int yPos);
            return new Point(xPos, yPos);
        }
    }

    public Rectangle WorkArea
    {
        get
        {
            NativeGlfw.GetMonitorWorkArea(_handle, out int xPos, out int yPos, out int width, out int height);
            return new Rectangle(xPos, yPos, width, height);
        }
    }

    public Size PhysicalSize
    {
        get
        {
            NativeGlfw.GetMonitorPhysicalSize(_handle, out int width, out int height);
            return new Size(width, height);
        }
    }

    public PointF ContentScale
    {
        get
        {
            NativeGlfw.GetMonitorContentScale(_handle, out float xScale, out float yScale);
            return new PointF(xScale, yScale);
        }
    }

    public string? Name => Marshal.PtrToStringAnsi(NativeGlfw.GetMonitorName(_handle));

    public Pointer? UserPointer
    {
        get
        {
            IntPtr pointer = NativeGlfw.glfwGetMonitorUserPointer(_handle);
            return pointer == IntPtr.Zero ? null : new Pointer(pointer);
        }
        set => NativeGlfw.SetMonitorUserPointer(_handle, value is null ? IntPtr.Zero : value.GetInternalHandle());
    }

    public static FunctionDelegate? SetCallback(FunctionDelegate? callback)
    {
        IntPtr result;
        if (callback is null)
        {
            result = NativeGlfw.SetMonitorCallback(IntPtr.Zero);
        }
        else
        {
            void InternalCallback(IntPtr monitor, Event @event)
            {
                callback.Invoke(new Monitor(monitor), @event);
            }

            result = NativeGlfw.SetMonitorCallback(
                Marshal.GetFunctionPointerForDelegate((NativeGlfw.MonitorFunctionDelegate)InternalCallback));
        }

        if (result == IntPtr.Zero)
        {
            return null;
        }

        NativeGlfw.MonitorFunctionDelegate nativeCallback =
            Marshal.GetDelegateForFunctionPointer<NativeGlfw.MonitorFunctionDelegate>(result);

        return (monitor, @event) => nativeCallback.Invoke(monitor._handle, @event);
    }

    public VideoMode?[]? GetVideoModes()
    {
        IntPtr nativeVideoModes = NativeGlfw.GetVideoModes(_handle, out int count);
        if (nativeVideoModes == IntPtr.Zero)
        {
            return null;
        }

        VideoMode?[] videoModes = new VideoMode?[count];
        IntPtr[] videoModesPtrArray = new IntPtr[count];
        for (int i = 0; i < count; i++)
        {
            videoModesPtrArray[i] = Marshal.AllocHGlobal(Marshal.SizeOf(nativeVideoModes) / count);
        }

        Marshal.Copy(nativeVideoModes, videoModesPtrArray, 0, count);
        for (int i = 0; i < count; i++)
        {
            videoModes[i] = videoModesPtrArray[i] == IntPtr.Zero ? null : new VideoMode(videoModesPtrArray[i]);
        }

        return videoModes;
    }

    public VideoMode? GetVideoMode()
    {
        IntPtr videoMode = NativeGlfw.GetVideoMode(_handle);
        return videoMode == IntPtr.Zero ? null : new VideoMode(videoMode);
    }
}