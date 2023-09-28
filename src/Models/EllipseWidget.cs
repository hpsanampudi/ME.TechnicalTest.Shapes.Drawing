namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class EllipseWidget : WidgetBase<EllipseWidgetSettings>
{
    public override WidgetTypes Name => WidgetTypes.Ellipse;

    public EllipseWidget()
        : base()
    {
    }

    public override void Draw(EllipseWidgetSettings widgetSettings)
    {
        ArgumentNullException.ThrowIfNull(nameof(widgetSettings));

        Settings = widgetSettings;

        var area = Settings.AxisA > default(decimal) &&
            Settings.AxisB > default(decimal) &&
            Settings.AxisA != Settings.AxisB ?
            ((decimal)Math.PI * Settings.AxisA * Settings.AxisB) : default(decimal?);

        Size = area;

        var isValid = area is not null;

        if (!isValid)
        {
            var errorMessage = $"{this}{Environment.NewLine}" +
                $"Error: A '{Name}' should not have both {nameof(Settings.AxisA)} and " +
                $"{nameof(Settings.AxisB)} same and " +
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
            $"{nameof(IEllipseWidgetSettings.AxisA)}={Settings?.AxisA} " +
            $"{nameof(IEllipseWidgetSettings.AxisB)}={Settings?.AxisB} ");

        return strBuilder.ToString();
    }
}
