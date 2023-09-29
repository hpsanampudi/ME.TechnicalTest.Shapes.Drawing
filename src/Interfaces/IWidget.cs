namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface IWidget
{
    WidgetTypes Name { get; }

    decimal? Size { get; }
}
