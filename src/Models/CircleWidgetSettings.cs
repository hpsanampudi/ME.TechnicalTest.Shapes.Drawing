namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal record CircleWidgetSettings(int XCoordinate, int YCoordinate, decimal Radius)
    : ICircleWidgetSettings;