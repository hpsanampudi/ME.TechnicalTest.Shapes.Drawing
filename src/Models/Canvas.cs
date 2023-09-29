namespace ME.TechnicalTest.Shapes.Drawing.Models;

internal class Canvas : ICanvas
{
    private readonly IList<IWidget> widgetShapesToDrawList;

    public Canvas()
    {
        widgetShapesToDrawList = new List<IWidget>();
    }

    public void AddWidgets(IEnumerable<IWidget> widgetItems)
    {
        ArgumentNullException.ThrowIfNull(nameof(widgetItems));

        if (!widgetItems.Any())
        {
            return;
        }

        foreach (var item in widgetItems)
        {
            AddWidget(item);
        }
    }

    public void AddWidget(IWidget widgetItem)
    {
        ArgumentNullException.ThrowIfNull(nameof(widgetItem));

        if (IsExists(widgetItem))
        {
            return;
        }

        widgetShapesToDrawList.Add(widgetItem);
    }

    public void RemoveWidget(IWidget widgetItem)
    {
        ArgumentNullException.ThrowIfNull(nameof(widgetItem));

        if (!IsExists(widgetItem))
        {
            return;
        }

        widgetShapesToDrawList.Remove(widgetItem);
    }

    public bool IsExists(IWidget widgetItem)
    {
        ArgumentNullException.ThrowIfNull(nameof(widgetItem));

        var widgetItemSettings = ((IWidgetRender<IWidgetSettings>)widgetItem).Settings;

        var isExists = widgetShapesToDrawList
            .OfType<IWidgetRender<IWidgetSettings>>()
            .Any(w => w.Settings.Equals(widgetItemSettings));

        return isExists;
    }

    public void DrawAllWidgets()
    {
        foreach (var item in widgetShapesToDrawList)
        {
            var renderer = (IWidgetRender<IWidgetSettings>)item;

            renderer.Draw();
        }
    }

    public void Clear() => widgetShapesToDrawList.Clear();

    public bool HasWidgets => widgetShapesToDrawList.Any();
}
