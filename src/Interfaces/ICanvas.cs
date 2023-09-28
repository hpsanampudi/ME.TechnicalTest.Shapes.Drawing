namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface ICanvas
{
    void AddWidgets(IDictionary<WidgetTypes, List<IWidgetSettings>> widgetItems);

    void AddWidget(WidgetTypes widgetType, params IWidgetSettings[] widgetSettings);

    void DrawAllWidgets();

    void Clear();

    bool HasWidgets { get; }
}