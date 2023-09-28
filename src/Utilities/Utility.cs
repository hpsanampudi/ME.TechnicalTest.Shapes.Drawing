namespace ME.TechnicalTest.Shapes.Drawing.Utilities;

internal static class Utility
{
    public static void WriteToConsole(
        string message,
        ConsoleColor textFontColor = default,
        ConsoleColor backgroundColor = default)
    {
        Console.ForegroundColor = backgroundColor == default && textFontColor == default ?
            ConsoleColor.White : textFontColor;

        Console.BackgroundColor = backgroundColor;

        Console.WriteLine(message);

        Console.ResetColor();

        Console.WriteLine(string.Empty.PadRight(50, '-'));
    }

    public static bool Implements<TInterface>(this Type type) where TInterface : class
    {
        var interfaceType = typeof(TInterface);

        if (!interfaceType.IsInterface)
        {
            throw (new InvalidOperationException(
                "The given type does not implements provided interface."));
        }

        return interfaceType.IsAssignableFrom(type);
    }
}
