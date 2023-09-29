namespace ME.TechnicalTest.Shapes.Drawing.Interfaces;

internal interface ICanvas
{
    void AddWidgets(IEnumerable<IWidget> widgetItems);

    void AddWidget(IWidget widgetItem);

    void RemoveWidget(IWidget widgetItem);

    bool IsExists(IWidget widgetItem);

    void DrawAllWidgets();

    void Clear();

    bool HasWidgets { get; }
}