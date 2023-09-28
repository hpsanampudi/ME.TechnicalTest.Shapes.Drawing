namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface ITextBoxWidgetSettings : IQuadrilateralWidgetSettings
{
    string TextContent { get; }

    ConsoleColor BackgroundColor { get; }
}
