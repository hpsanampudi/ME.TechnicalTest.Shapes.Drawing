namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal record EllipseWidgetSettings(int XCoordinate, int YCoordinate, decimal AxisA, decimal AxisB)
    : IEllipseWidgetSettings;
