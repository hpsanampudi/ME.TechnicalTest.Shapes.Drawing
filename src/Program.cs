namespace ME.TechnicalTest.Shapes.Drawing;

internal static class Program
{
    static void Main(string[] args)
    {
        var configuredWidgetsList = GetAllConfiguredWidgets();

        if (!configuredWidgetsList.Any())
        {
            return;
        }


        Console.WriteLine(string.Empty.PadRight(50, '-'));

        var canvas = new Canvas();

        canvas.AddWidgets(configuredWidgetsList);

        Console.WriteLine("Drawing configured widget shapes on canvas...");

        Console.WriteLine(string.Empty.PadRight(50, '-'));

        canvas.DrawAllWidgets();

        Console.WriteLine("Press enter to exit!");

        canvas.Clear();

        Console.ReadLine();
    }

    private static List<IWidget> GetAllConfiguredWidgets()
    {
        var drawWidgetShapesOnCanvasMessage = "To draw widget shapes on canvas press 'D|d' and enter key";

        var exitMessage = "To exit press 'E|e' and enter key";

        var addWidgetToCanvasMessage = "To add any of following widget to canvas press " +
            "corresponding number related to shape and enter key as " +
            "1:Square;2:Rectangle;3:Circle;4:Ellipse;5:TextBox";

        Console.WriteLine($"{addWidgetToCanvasMessage} (or) {drawWidgetShapesOnCanvasMessage} " +
            $"(or) {exitMessage}");

        var configuredWidgetsList = new List<IWidget>();

        string? enteredValue;

        while ((enteredValue = Console.ReadLine()) != "D")
        {
            if (enteredValue!.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }

            if (enteredValue!.Equals("E", StringComparison.InvariantCultureIgnoreCase))
            {
                configuredWidgetsList.Clear();
                break;
            }

            var isValid = int.TryParse(enteredValue, out var widgetTypeValue);

            if (!isValid)
            {
                Console.WriteLine(
                    $"{addWidgetToCanvasMessage} (or) {drawWidgetShapesOnCanvasMessage}");

                continue;
            }

            var widgetType = (WidgetTypes)widgetTypeValue;

            switch (widgetType)
            {
                case WidgetTypes.Square:
                    {
                        Console.WriteLine($"Configuring widget shape for '{widgetType}'...");

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.XCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var x);

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.YCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var y);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Height)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var height);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Width)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var width);

                        configuredWidgetsList.Add(new SquareWidget(
                            new QuadrilateralWidgetSettings(x, y, height, width)));
                    }
                    break;

                case WidgetTypes.Rectangle:
                    {
                        Console.WriteLine($"Configuring widget shape for '{widgetType}'...");

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.XCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var x);

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.YCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var y);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Height)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var height);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Width)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var width);

                        configuredWidgetsList.Add(new RectangleWidget(
                            new QuadrilateralWidgetSettings(x, y, height, width)));
                    }
                    break;

                case WidgetTypes.Circle:
                    {
                        Console.WriteLine($"Configuring widget shape for '{widgetType}'...");

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.XCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var x);

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.YCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var y);

                        Console.WriteLine($"Enter {nameof(ICircleWidgetSettings.Radius)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var radius);

                        configuredWidgetsList.Add(new CircleWidget(
                            new CircleWidgetSettings(x, y, radius)));
                    }
                    break;

                case WidgetTypes.Ellipse:
                    {
                        Console.WriteLine($"Configuring widget shape for '{widgetType}'...");

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.XCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var x);

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.YCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var y);

                        Console.WriteLine($"Enter {nameof(IEllipseWidgetSettings.AxisA)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var a);

                        Console.WriteLine($"Enter {nameof(IEllipseWidgetSettings.AxisB)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var b);

                        configuredWidgetsList.Add(new EllipseWidget(
                            new EllipseWidgetSettings(x, y, a, b)));
                    }
                    break;

                case WidgetTypes.TextBox:
                    {
                        Console.WriteLine($"Configuring widget shape for '{widgetType}'...");

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.XCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var x);

                        Console.WriteLine($"Enter {nameof(IWidgetSettings.YCoordinate)}:");
                        _ = int.TryParse(Console.ReadLine(), out var y);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Height)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var height);

                        Console.WriteLine($"Enter {nameof(IQuadrilateralWidgetSettings.Width)}:");
                        _ = decimal.TryParse(Console.ReadLine(), out var width);

                        Console.WriteLine($"Enter {nameof(ITextBoxWidgetSettings.TextContent)}:");
                        var text = Console.ReadLine()!;

                        Console.WriteLine($"Enter {nameof(ITextBoxWidgetSettings.BackgroundColor)}:");
                        var bkgColor = string.IsNullOrWhiteSpace(Console.ReadLine()!) ?
                            ConsoleColor.Green : ConsoleColor.Yellow;

                        configuredWidgetsList.Add(new TextBoxWidget(
                            new TextBoxWidgetSettings(x, y, height, width, text, bkgColor)));
                    }
                    break;

                default:
                    throw new NotImplementedException(nameof(widgetType));
            }

            Console.WriteLine(string.Empty.PadRight(25, '*'));

            Console.WriteLine(
                $"{drawWidgetShapesOnCanvasMessage} (or) {addWidgetToCanvasMessage}");
        }

        return configuredWidgetsList;
    }
}