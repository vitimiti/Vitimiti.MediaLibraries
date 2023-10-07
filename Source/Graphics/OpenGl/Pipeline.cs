namespace Vitimiti.MediaLibraries.OpenGl;

public sealed class Pipeline : IEquatable<Pipeline>
{
    public uint Id { get; internal init; }

    public bool Equals(Pipeline? other)
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
        return ReferenceEquals(this, obj) || (obj is Pipeline other && Equals(other));
    }

    public override int GetHashCode()
    {
        return (int)Id;
    }

    public static bool operator ==(Pipeline? left, Pipeline? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Pipeline? left, Pipeline? right)
    {
        return !Equals(left, right);
    }
}