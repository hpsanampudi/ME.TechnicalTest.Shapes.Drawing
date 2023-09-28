namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class QuadrilateralWidgetSettings :
    IQuadrilateralWidgetSettings, IEquatable<QuadrilateralWidgetSettings>
{
    public int XCoordinate { get; init; }

    public int YCoordinate { get; init; }

    public decimal Height { get; init; }

    public decimal Width { get; init; }

    public QuadrilateralWidgetSettings(int xCoordinate, int yCoordinate, decimal height, decimal width)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
        Height = height;
        Width = width;
    }

    public bool Equals(QuadrilateralWidgetSettings? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        var isEqualTo = XCoordinate == other.XCoordinate &&
            YCoordinate == other.YCoordinate &&
            Height == other.Height &&
            Width == other.Width;

        return isEqualTo;
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

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((QuadrilateralWidgetSettings)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(XCoordinate, YCoordinate, Height, Width);
    }
}
