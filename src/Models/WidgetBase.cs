namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal abstract class WidgetBase<TSettings> : IWidget, IWidgetRender<TSettings>
    where TSettings : IWidgetSettings
{
    public abstract WidgetTypes Name { get; }

    public decimal? Size { get; protected set; }

    public TSettings? Settings { get; protected set; }

    protected WidgetBase()
    {
    }

    public abstract void Draw(TSettings widgetSettings);

    void IWidget.DrawShape(IWidgetSettings widgetSettings) => Draw((TSettings)widgetSettings);
}
