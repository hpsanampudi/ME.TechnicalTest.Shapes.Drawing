namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class CircleWidget : WidgetBase<CircleWidgetSettings>
{
    public override WidgetTypes Name => WidgetTypes.Circle;

    public CircleWidget(CircleWidgetSettings widgetSettings)
        : base(widgetSettings)
    {
    }

    public override void Draw()
    {
        var area = Settings.Radius > default(decimal) ?
            ((decimal)Math.PI * Settings.Radius * Settings.Radius) : default(decimal?);

        Size = area;

        var isValid = area is not null;

        if (!isValid)
        {
            var errorMessage = $"{this}{Environment.NewLine}" +
                $"Error: A '{Name}' should not have {nameof(Settings.Radius)} less than (or) equal to zero!";

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
            $"{nameof(ICircleWidgetSettings.Radius)}={Settings?.Radius} ");

        return strBuilder.ToString();
    }
}
