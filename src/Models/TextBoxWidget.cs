namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class TextBoxWidget : WidgetBase<TextBoxWidgetSettings>
{
    public override WidgetTypes Name => WidgetTypes.TextBox;

    public TextBoxWidget(TextBoxWidgetSettings widgetSettings)
        : base(widgetSettings)
    {
    }

    public override void Draw()
    {
        var area = Settings.Height > default(decimal) &&
            Settings.Width > default(decimal) &&
            Settings.Height != Settings.Width ?
            Settings.Height * Settings.Width : default(decimal?);

        Size = area;

        var isValid = area is not null;

        if (!isValid)
        {
            var errorMessage = $"{this}{Environment.NewLine}" +
                $"Error: A '{Name}' should not have both {nameof(Settings.Height)} and " +
                $"{nameof(Settings.Width)} same and " +
                $"also its value should not be less than (or) equal to zero!";

            Utility.WriteToConsole(errorMessage, ConsoleColor.Red);

            return;
        }

        Settings.BackgroundColor = string.IsNullOrWhiteSpace(Settings.TextContent) ?
            ConsoleColor.Red : Settings.BackgroundColor;

        Utility.WriteToConsole($"{this}", backgroundColor: Settings.BackgroundColor);
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();

        strBuilder.Append(
            $"{Name} " +
            $"(X:{Settings?.XCoordinate},Y:{Settings?.YCoordinate}) " +
            $"{nameof(Size)}={Size:N2} " +
            $"{nameof(IQuadrilateralWidgetSettings.Height)}={Settings?.Height} " +
            $"{nameof(IQuadrilateralWidgetSettings.Width)}={Settings?.Width} " +
             $"{nameof(ITextBoxWidgetSettings.TextContent)}={Settings?.TextContent} " +
             $"{nameof(ITextBoxWidgetSettings.BackgroundColor)}={Settings?.BackgroundColor} ");

        return strBuilder.ToString();
    }
}
