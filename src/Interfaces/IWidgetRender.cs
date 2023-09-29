namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface IWidgetRender<out TSettings>
    where TSettings : IWidgetSettings
{
    TSettings Settings { get; }

    void Draw();
}
