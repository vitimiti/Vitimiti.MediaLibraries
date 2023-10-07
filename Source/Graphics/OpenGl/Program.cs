namespace Vitimiti.MediaLibraries.OpenGl;

public sealed class Program : IEquatable<Program>
{
    public uint Id { get; internal init; }

    public bool Equals(Program? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
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

        return obj.GetType() == GetType() && Equals((Program)obj);
    }

    public override int GetHashCode()
    {
        return (int)Id;
    }

    public static bool operator ==(Program? left, Program? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Program? left, Program? right)
    {
        return !Equals(left, right);
    }
}