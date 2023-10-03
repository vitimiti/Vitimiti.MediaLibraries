using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public class Pointer : SafeHandleZeroOrMinusOneIsInvalid
{
    private Memory<byte> _data;

    public Pointer(Memory<byte> data) : base(false)
    {
        _data = data;
        UpdateHandle();
    }

    internal Pointer(IntPtr newHandle) : base(false)
    {
        handle = newHandle;
        if (handle == IntPtr.Zero)
        {
            _data = new Memory<byte>();
        }
        else
        {
            IntPtr ptr = Marshal.ReadIntPtr(handle);
            int length = Marshal.SizeOf(handle) / Marshal.SizeOf(ptr);
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                bytes[i] = Marshal.ReadByte(ptr);
                ptr += Marshal.SizeOf(ptr);
            }

            _data = new Memory<byte>(bytes);
        }
    }

    public Memory<byte> Data
    {
        get => _data;
        set
        {
            _data = value;
            UpdateHandle();
        }
    }

    internal IntPtr GetInternalHandle()
    {
        return handle;
    }

    protected override bool ReleaseHandle()
    {
        return true;
    }

    private void UpdateHandle()
    {
        if (_data.Length == 0)
        {
            handle = IntPtr.Zero;
        }
        else
        {
            byte[] dataArray = _data.ToArray();
            IntPtr dataPtr = Marshal.AllocHGlobal(Marshal.SizeOf(dataArray[0]) * _data.Length);
            Marshal.Copy(dataArray, 0, dataPtr, _data.Length);
            handle = dataPtr;
        }
    }
}