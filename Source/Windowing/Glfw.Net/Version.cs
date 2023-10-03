using System.Runtime.InteropServices;

using Vitimiti.MediaLibraries.Glfw.Net.Imports;

namespace Vitimiti.MediaLibraries.Glfw.Net;

public sealed class Version : IEquatable<Version>, IComparable<Version>, IComparable
{
    public Version()
    {
        NativeGlfw.GetVersion(out int major, out int minor, out int revision);
        Major = major;
        Minor = minor;
        Revision = revision;
    }

    public int Major { get; private init; }
    public int Minor { get; private init; }
    public int Revision { get; private init; }

    public static Version Expected => new() { Major = 3, Minor = 3, Revision = 8 };

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        return obj is Version other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Version)}");
    }

    public int CompareTo(Version? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        int majorComparison = Major.CompareTo(other.Major);
        if (majorComparison != 0)
        {
            return majorComparison;
        }

        int minorComparison = Minor.CompareTo(other.Minor);
        return minorComparison != 0 ? minorComparison : Revision.CompareTo(other.Revision);
    }

    public bool Equals(Version? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Major == other.Major && Minor == other.Minor && Revision == other.Revision;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Version)obj);
    }

    public override string ToString()
    {
        return Marshal.PtrToStringAnsi(NativeGlfw.GetVersionString()) ?? $"{Major}.{Minor}.{Revision}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Major, Minor, Revision);
    }

    public static bool operator ==(Version? left, Version? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Version? left, Version? right)
    {
        return !Equals(left, right);
    }

    public static bool operator <(Version? left, Version? right)
    {
        return Comparer<Version>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Version? left, Version? right)
    {
        return Comparer<Version>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Version? left, Version? right)
    {
        return Comparer<Version>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Version? left, Version? right)
    {
        return Comparer<Version>.Default.Compare(left, right) >= 0;
    }
}