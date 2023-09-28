namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class TextBoxWidgetSettings
    : QuadrilateralWidgetSettings, ITextBoxWidgetSettings, IEquatable<TextBoxWidgetSettings>
{
    public string TextContent { get; init; }

    public ConsoleColor BackgroundColor { get; set; }

    public TextBoxWidgetSettings(
        int xCoordinate,
        int yCoordinate,
        decimal height,
        decimal width,
        string textContent,
        ConsoleColor backgroundColor)
        : base(xCoordinate, yCoordinate, height, width)
    {
        TextContent = textContent;
        BackgroundColor = backgroundColor;
    }

    public bool Equals(TextBoxWidgetSettings? other)
    {
        var isEqualTo = base.Equals(other) && TextContent == other.TextContent;

        return isEqualTo;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(XCoordinate, YCoordinate, Height, Width, TextContent);
    }
}