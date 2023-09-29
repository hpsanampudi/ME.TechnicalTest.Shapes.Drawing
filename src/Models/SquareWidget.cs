namespace ME.TechnicalTest.Shapes.Drawing.Models;
internal class SquareWidget : WidgetBase<QuadrilateralWidgetSettings>
{
    public override WidgetTypes Name => WidgetTypes.Square;

    public SquareWidget(QuadrilateralWidgetSettings widgetSettings)
        : base(widgetSettings)
    {
    }

    public override void Draw()
    {
        var area = Settings.Height > default(decimal) &&
            Settings.Width > default(decimal) &&
            Settings.Height == Settings.Width ?
            Settings.Height * Settings.Width : default(decimal?);

        Size = area;

        var isValid = area is not null;

        if (!isValid)
        {
            var errorMessage = $"{this}{Environment.NewLine}" +
                $"Error: A '{Name}' should have both {nameof(Settings.Height)} and " +
                $"{nameof(Settings.Width)} same and " +
                $"also its value should not be less than (or) equal to zero!";

            Utility.WriteToConsole(errorMessage, ConsoleColor.Red);

            return;
        }

        Utility.WriteToConsole($"{this}", ConsoleColor.Green);
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();

        strBuilder.Append(
            $"{Name} " +
            $"(X:{Settings?.XCoordinate},Y:{Settings?.YCoordinate}) " +
            $"{nameof(Size)}={Size:N2} " +
            $"{nameof(IQuadrilateralWidgetSettings.Height)}={Settings?.Height} " +
            $"{nameof(IQuadrilateralWidgetSettings.Width)}={Settings?.Width} ");

        return strBuilder.ToString();
    }
}
