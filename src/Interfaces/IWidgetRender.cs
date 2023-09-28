namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface IWidgetRender<TSettings>
    where TSettings : IWidgetSettings
{
    TSettings? Settings { get; }

    void Draw(TSettings widgetSettings);
}
