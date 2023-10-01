namespace Glfw.Net;

public readonly struct Version : IEquatable<Version>, IComparable<Version>, IComparable
{
    public byte Major { get; }
    public byte Minor { get; }
    public byte Revision { get; }

    public Version()
    {
        Major = 3;
        Minor = 3;
        Revision = 8;
    }

    public override string ToString()
    {
        return $"{Major}.{Minor}.{Revision}";
    }

    public bool Equals(Version other)
    {
        return Major == other.Major && Minor == other.Minor && Revision == other.Revision;
    }

    public override bool Equals(object? obj)
    {
        return obj is Version other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Major, Minor, Revision);
    }

    public static bool operator ==(Version left, Version right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Version left, Version right)
    {
        return !left.Equals(right);
    }

    public int CompareTo(Version other)
    {
        int majorComparison = Major.CompareTo(other.Major);
        if (majorComparison != 0)
        {
            return majorComparison;
        }

        int minorComparison = Minor.CompareTo(other.Minor);
        return minorComparison != 0 ? minorComparison : Revision.CompareTo(other.Revision);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        return obj is Version other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Version)}");
    }

    public static bool operator <(Version left, Version right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >(Version left, Version right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(Version left, Version right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(Version left, Version right)
    {
        return left.CompareTo(right) >= 0;
    }
}