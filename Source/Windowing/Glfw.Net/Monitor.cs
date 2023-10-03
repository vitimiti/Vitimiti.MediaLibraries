using System.Drawing;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public sealed class Monitor : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<Monitor>
{
    public delegate void FunctionDelegate(Monitor? monitor, ConnectionStatus status);

    internal Monitor(IntPtr monitorHandle) : base(false)
    {
        handle = monitorHandle;
    }

    public static Monitor?[]? Array
    {
        get
        {
            IntPtr monitorsHandle = NativeGlfw.GetMonitors(out int count);
            if (monitorsHandle == IntPtr.Zero)
            {
                return null;
            }

            IntPtr[] monitorHandles = new IntPtr[count];
            for (int i = 0; i < count; i++)
            {
                monitorHandles[i] = Marshal.AllocHGlobal(Marshal.SizeOf(monitorsHandle) / count);
            }

            Marshal.Copy(monitorsHandle, monitorHandles, 0, count);
            Monitor?[] monitors = new Monitor[count];
            for (int i = 0; i < count; i++)
            {
                monitors[i] = monitorHandles[i] == IntPtr.Zero ? null : new Monitor(monitorHandles[i]);
            }

            return monitors;
        }
    }

    public static Monitor? Primary
    {
        get
        {
            IntPtr monitorHandle = NativeGlfw.GetPrimaryMonitor();
            return monitorHandle == IntPtr.Zero ? null : new Monitor(monitorHandle);
        }
    }

    public Point Position
    {
        get
        {
            NativeGlfw.GetMonitorPosition(handle, out int xPos, out int yPos);
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

    public Size PhysicalSizeMillimeters
    {
        get
        {
            NativeGlfw.GetMonitorPhysicalSize(handle, out int width, out int height);
            return new Size(width, height);
        }
    }

    public (float X, float Y) ContentScale
    {
        get
        {
            NativeGlfw.GetMonitorContentScale(handle, out float xScale, out float yScale);
            return (xScale, yScale);
        }
    }

    public string? Name => Marshal.PtrToStringAnsi(NativeGlfw.GetMonitorName(handle));

    public bool Equals(Monitor? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return handle == other.handle;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || (obj is Monitor other && Equals(other));
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }

    public override int GetHashCode()
    {
        return -1;
    }

    public override string ToString()
    {
        return
            $@"{{
    Handle=0x{handle.ToString("X")},
    Position={Position},
    Work Area={WorkArea},
    Physical Size (Millimeters)={PhysicalSizeMillimeters},
    Content Scale={ContentScale},
    Name={Name}
}}";
    }

    public static bool operator ==(Monitor? left, Monitor? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Monitor? left, Monitor? right)
    {
        return !Equals(left, right);
    }
}