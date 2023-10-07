using System.Runtime.InteropServices;
using System.Text;

namespace Vitimiti.MediaLibraries.OpenGl;

public class Debug
{
    public delegate void Callback(Source source, Type type, Severity severity, uint id, string? message,
        object? userParam);

    public enum Severity
    {
        DontCare = 0x1100,
        High = 0x9146,
        Medium = 0x9147,
        Low = 0x9148,
        Notification = 0x826B
    }

    public enum Source
    {
        DontCare = 0x1100,
        Api = 0x8246,
        WindowSystem = 0x8247,
        ShaderCompiler = 0x8248,
        ThirdParty = 0x8249,
        Application = 0x824A,
        Other = 0x824B
    }

    public enum Type
    {
        DontCare = 0x1100,
        Error = 0x824C,
        DeprecatedBehavior = 0x824D,
        UndefinedBehavior = 0x824E,
        Portability = 0x824F,
        Performance = 0x8250,
        Other = 0x8251,
        Marker = 0x8268,
        PushGroup = 0x8269,
        PopGroup = 0x826A
    }

    public static void SetMessageCallback(Callback callback, object? userParam)
    {
        unsafe
        {
            IntPtr delegatePtr = Marshal.GetFunctionPointerForDelegate(
                (uint source, uint type, uint id, uint severity, int size, byte* msg, void* param) =>
                {
                    byte[] bytes;
                    if (size < 0)
                    {
                        int count = 0;
                        int pos = 1;
                        while (msg[pos] != '\0')
                        {
                            count++;
                            pos += sizeof(byte);
                        }

                        bytes = new byte[count];
                    }
                    else
                    {
                        bytes = new byte[size];
                    }

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = msg[i + 1];
                    }

                    callback.Invoke((Source)source, (Type)type, (Severity)severity, id,
                        Encoding.Default.GetString(bytes),
                        GCHandle.FromIntPtr((IntPtr)param).Target);
                });

            ((delegate* unmanaged<delegate* unmanaged<uint, uint, uint, uint, int, byte*, void*, void>, void*, void>)Gl
                .GetInstance().GetExportPointer("glDebugMessageCallback"))(
                (delegate* unmanaged<uint, uint, uint, uint, int, byte*, void*, void>)delegatePtr,
                (void*)(IntPtr)GCHandle.Alloc(userParam));
        }
    }

    public static void SetMessageEnabled(Source source, Type type, Severity severity, uint[] ids, bool enabled)
    {
        unsafe
        {
            fixed (uint* idsPtr = ids)
            {
                ((delegate* unmanaged<uint, uint, uint, int, uint*, byte, void>)Gl.GetInstance()
                    .GetExportPointer("glDebugMessageControl"))((uint)source, (uint)type, (uint)severity, ids.Length,
                    idsPtr, (byte)(enabled ? 1 : 0));
            }
        }
    }

    public static void InsertMessage(Source source, Type type, Severity severity, uint id, string? message)
    {
        unsafe
        {
            byte[]? bytes = message is null ? null : Encoding.Default.GetBytes(message);
            fixed (byte* msgPtr = bytes)
            {
                ((delegate* unmanaged<uint, uint, uint, uint, int, byte*, void>)Gl.GetInstance()
                    .GetExportPointer("glDebugMessageInsert"))((uint)source, (uint)type, id, (uint)severity,
                    bytes?.Length ?? 0, msgPtr);
            }
        }
    }

    private static void InitializeGroupData((uint Count, int BufferSize) sizeData,
        ref (Source[]? Sources, Type[]? Types, Severity[]? Severities, uint[]? Ids, int[]? Lengths) groupData)
    {
        if (groupData.Sources is not null)
        {
            groupData.Sources = new Source[sizeData.Count];
        }

        if (groupData.Types is not null)
        {
            groupData.Types = new Type[sizeData.Count];
        }

        if (groupData.Severities is not null)
        {
            groupData.Severities = new Severity[sizeData.Count];
        }

        if (groupData.Ids is not null)
        {
            groupData.Ids = new uint[sizeData.Count];
        }

        if (groupData.Lengths is not null)
        {
            groupData.Lengths = new int[sizeData.Count];
        }
    }

    private static void InitializeConvertedGroupData((uint Count, int BufferSize) sizeData,
        (Source[]? Sources, Type[]? Types, Severity[]? Severities) groupData,
        ref (uint[]? Sources, uint[]? Types, uint[]? Severities) convertedGroupData)
    {
        if (groupData.Sources is not null)
        {
            convertedGroupData.Sources = new uint[sizeData.Count];
            for (int i = 0; i < groupData.Sources.Length; i++)
            {
                convertedGroupData.Sources[i] = (uint)groupData.Sources[i];
            }
        }

        if (groupData.Types is not null)
        {
            convertedGroupData.Types = new uint[sizeData.Count];
            for (int i = 0; i < groupData.Types.Length; i++)
            {
                convertedGroupData.Types[i] = (uint)groupData.Types[i];
            }
        }

        if (groupData.Severities is null)
        {
            return;
        }

        convertedGroupData.Severities = new uint[sizeData.Count];
        for (int i = 0; i < groupData.Severities.Length; i++)
        {
            convertedGroupData.Severities[i] = (uint)groupData.Severities[i];
        }
    }

    public static uint GetMessageLog((uint Count, int BufferSize) sizeData,
        ref (Source[]? Sources, Type[]? Types, Severity[]? Severities, uint[]? Ids, int[]? Lengths) groupData,
        ref string? messageLog)
    {
        InitializeGroupData(sizeData, ref groupData);
        unsafe
        {
            (uint[]? Sources, uint[]? Types, uint[]? Severities) convertedData = (null, null, null);
            (Source[]? Sources, Type[]? Types, Severity[]? Severities) minimalGroupData =
                (groupData.Sources, groupData.Types, groupData.Severities);

            InitializeConvertedGroupData(sizeData, minimalGroupData, ref convertedData);
            byte[]? messageLogBytes = messageLog is null ? null : Encoding.Default.GetBytes(messageLog);

            fixed (uint* sourcesPtr = convertedData.Sources)
            fixed (uint* typesPtr = convertedData.Types)
            fixed (uint* severitiesPtr = convertedData.Severities)
            fixed (uint* idsPtr = groupData.Ids)
            fixed (int* lengthsPtr = groupData.Lengths)
            fixed (byte* messagePtr = messageLogBytes)
            {
                return ((delegate* unmanaged<uint, int, uint*, uint*, uint*, uint*, int*, byte*, uint>)Gl.GetInstance()
                    .GetExportPointer("glGetDebugMessageLog"))(sizeData.Count, sizeData.BufferSize, sourcesPtr,
                    typesPtr, idsPtr, severitiesPtr, lengthsPtr, messagePtr);
            }
        }
    }

    public static void PopGroup()
    {
        unsafe
        {
            ((delegate* unmanaged<void>)Gl.GetInstance().GetExportPointer("glPopDebugGroup"))();
        }
    }

    public static void PushGroup(Source source, uint id, string? message)
    {
        byte[]? bytes = message is null ? null : Encoding.Default.GetBytes(message);
        unsafe
        {
            fixed (byte* messagePtr = bytes)
            {
                ((delegate* unmanaged<uint, uint, int, byte*, void>)Gl.GetInstance()
                    .GetExportPointer("glPushDebugGroup"))((uint)source, id, bytes?.Length ?? 0, messagePtr);
            }
        }
    }
}