namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class Canvas : ICanvas
{
    private readonly IDictionary<WidgetTypes, List<IWidgetSettings>> widgetShapesToDrawList;

    public Canvas()
    {
        widgetShapesToDrawList = new Dictionary<WidgetTypes, List<IWidgetSettings>>();
    }

    public void AddWidgets(IDictionary<WidgetTypes, List<IWidgetSettings>> widgetItems)
    {
        if (!widgetItems.Any())
        {
            return;
        }

        foreach (var kvp in widgetItems)
        {
            AddWidget(kvp.Key, kvp.Value.ToArray());
        }
    }

    public void AddWidget(WidgetTypes widgetType, params IWidgetSettings[] widgetSettings)
    {
        if (widgetShapesToDrawList.ContainsKey(widgetType))
        {
            widgetShapesToDrawList[widgetType].AddRange(widgetSettings);

            return;
        }

        widgetShapesToDrawList.Add(widgetType, widgetSettings.ToList());
    }

    public void DrawAllWidgets()
    {
        foreach (var kvp in widgetShapesToDrawList)
        {
            var widgetType = kvp.Key;

            IWidget renderer = widgetType switch
            {
                WidgetTypes.Square => new SquareWidget(),
                WidgetTypes.Rectangle => new RectangleWidget(),
                WidgetTypes.Circle => new CircleWidget(),
                WidgetTypes.Ellipse => new EllipseWidget(),
                WidgetTypes.TextBox => new TextBoxWidget(),
                _ => throw new NotImplementedException(
                    $"The widget type '{widgetType}' not handled programatically!")
            };

            foreach (var settings in kvp.Value)
            {
                renderer.DrawShape(settings);
            }
        }
    }

    public void Clear() => widgetShapesToDrawList.Clear();

    public bool HasWidgets => widgetShapesToDrawList.Any();
}
