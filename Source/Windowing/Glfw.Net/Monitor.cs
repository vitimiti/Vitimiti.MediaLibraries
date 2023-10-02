using System.Drawing;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Monitor : SafeHandleZeroOrMinusOneIsInvalid
{
    public delegate void FunctionDelegate(Monitor monitor, Event @event);

    internal Monitor(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
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
            NativeGlfw.GetMonitorPos(handle, out int xPos, out int yPos);
            return new Point(xPos, yPos);
        }
    }

    public Rectangle WorkArea
    {
        get
        {
            NativeGlfw.GetMonitorWorkArea(handle, out int xPos, out int yPos, out int width, out int height);
            return new Rectangle(xPos, yPos, width, height);
        }
    }

    public Size PhysicalSize
    {
        get
        {
            NativeGlfw.GetMonitorPhysicalSize(handle, out int width, out int height);
            return new Size(width, height);
        }
    }

    public PointF ContentScale
    {
        get
        {
            NativeGlfw.GetMonitorContentScale(handle, out float xScale, out float yScale);
            return new PointF(xScale, yScale);
        }
    }

    public string? Name => Marshal.PtrToStringAnsi(NativeGlfw.GetMonitorName(handle));

    public Pointer? UserPointer
    {
        get
        {
            IntPtr pointer = NativeGlfw.glfwGetMonitorUserPointer(handle);
            return pointer == IntPtr.Zero ? null : new Pointer(pointer);
        }
        set => NativeGlfw.SetMonitorUserPointer(handle, value is null ? IntPtr.Zero : value.GetInternalHandle());
    }

    public VideoMode?[]? VideoModes
    {
        get
        {
            IntPtr nativeVideoModes = NativeGlfw.GetVideoModes(handle, out int count);
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
    }

    public VideoMode? VideoMode
    {
        get
        {
            IntPtr videoMode = NativeGlfw.GetVideoMode(handle);
            return videoMode == IntPtr.Zero ? null : new VideoMode(videoMode);
        }
    }

    public GammaRamp? GammaRamp
    {
        get
        {
            IntPtr gammaRamp = NativeGlfw.GetGammaRamp(handle);
            return gammaRamp == IntPtr.Zero ? null : new GammaRamp(gammaRamp);
        }
        set => NativeGlfw.SetGammaRamp(handle, value?.GetInternalHandle() ?? IntPtr.Zero);
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }

    internal IntPtr GetInternalHandle()
    {
        return handle;
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

        return (monitor, @event) => nativeCallback.Invoke(monitor.handle, @event);
    }

    public void SetGammaRamp(float value)
    {
        NativeGlfw.SetGamma(handle, value);
    }
}