// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using System.Runtime.InteropServices;

namespace JatinSanghvi.TextFormatter;

public static class TextFormatter
{
    private static bool IsFormattingEnabled;

    /// <summary>
    /// Activates text formatting. The method should be called before the printing formatted text.
    /// </summary>
    /// <param name="enableLogging">Log error messages to console.</param>
    /// <returns>True if initialization is successful; false otherwise.</returns>
    public static bool Activate(bool enableLogging = false)
    {
        IsFormattingEnabled =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            && !Console.IsOutputRedirected
            && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NO_COLOR")) // https://no-color.org/
            && PlatformWindows.SetConsoleOutputVirtualTerminalProcessing(enableLogging);

        return IsFormattingEnabled;
    }

    // ANSI SGR Escape Codes:
    // https://en.wikipedia.org/wiki/ANSI_escape_code#SGR_(Select_Graphic_Rendition)_parameters
    // https://learn.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences#text-formatting

#pragma warning disable format
    public static string Black         (this object text) => Color(text, ConsoleColor.Black);
    public static string Red           (this object text) => Color(text, ConsoleColor.DarkRed);
    public static string Green         (this object text) => Color(text, ConsoleColor.DarkGreen);
    public static string Yellow        (this object text) => Color(text, ConsoleColor.DarkYellow);
    public static string Blue          (this object text) => Color(text, ConsoleColor.DarkBlue);
    public static string Magenta       (this object text) => Color(text, ConsoleColor.DarkMagenta);
    public static string Cyan          (this object text) => Color(text, ConsoleColor.DarkCyan);
    public static string White         (this object text) => Color(text, ConsoleColor.Gray);
    public static string Gray          (this object text) => Color(text, ConsoleColor.DarkGray);
    public static string BrightBlack   (this object text) => Color(text, ConsoleColor.DarkGray);
    public static string BrightRed     (this object text) => Color(text, ConsoleColor.Red);
    public static string BrightGreen   (this object text) => Color(text, ConsoleColor.Green);
    public static string BrightYellow  (this object text) => Color(text, ConsoleColor.Yellow);
    public static string BrightBlue    (this object text) => Color(text, ConsoleColor.Blue);
    public static string BrightMagenta (this object text) => Color(text, ConsoleColor.Magenta);
    public static string BrightCyan    (this object text) => Color(text, ConsoleColor.Cyan);
    public static string BrightWhite   (this object text) => Color(text, ConsoleColor.White);
#pragma warning restore format

    /// <returns>Text with foreground color.</returns>
    public static string Color(this object text, ConsoleColor color)
    {
        string sgrCode = color switch
        {
#pragma warning disable format
            ConsoleColor.Black       => "30", // Foreground Black
            ConsoleColor.DarkRed     => "31", // Foreground Red
            ConsoleColor.DarkGreen   => "32", // Foreground Green
            ConsoleColor.DarkYellow  => "33", // Foreground Yellow
            ConsoleColor.DarkBlue    => "34", // Foreground Blue
            ConsoleColor.DarkMagenta => "35", // Foreground Magenta
            ConsoleColor.DarkCyan    => "36", // Foreground Cyan
            ConsoleColor.Gray        => "37", // Foreground White
            ConsoleColor.DarkGray    => "90", // Bright Foreground Black
            ConsoleColor.Red         => "91", // Bright Foreground Red
            ConsoleColor.Green       => "92", // Bright Foreground Green
            ConsoleColor.Yellow      => "93", // Bright Foreground Yellow
            ConsoleColor.Blue        => "94", // Bright Foreground Blue
            ConsoleColor.Magenta     => "95", // Bright Foreground Magenta
            ConsoleColor.Cyan        => "96", // Bright Foreground Cyan
            ConsoleColor.White       => "97", // Bright Foreground White
#pragma warning restore format
            _ => throw new NotImplementedException(),
        };

        return text.WithAnsiCode(sgrCode, "39");
    }

#pragma warning disable format
    public static string BgBlack         (this object text) => BgColor(text, ConsoleColor.Black);
    public static string BgRed           (this object text) => BgColor(text, ConsoleColor.DarkRed);
    public static string BgGreen         (this object text) => BgColor(text, ConsoleColor.DarkGreen);
    public static string BgYellow        (this object text) => BgColor(text, ConsoleColor.DarkYellow);
    public static string BgBlue          (this object text) => BgColor(text, ConsoleColor.DarkBlue);
    public static string BgMagenta       (this object text) => BgColor(text, ConsoleColor.DarkMagenta);
    public static string BgCyan          (this object text) => BgColor(text, ConsoleColor.DarkCyan);
    public static string BgWhite         (this object text) => BgColor(text, ConsoleColor.Gray);
    public static string BgGray          (this object text) => BgColor(text, ConsoleColor.DarkGray);
    public static string BgBrightBlack   (this object text) => BgColor(text, ConsoleColor.DarkGray);
    public static string BgBrightRed     (this object text) => BgColor(text, ConsoleColor.Red);
    public static string BgBrightGreen   (this object text) => BgColor(text, ConsoleColor.Green);
    public static string BgBrightYellow  (this object text) => BgColor(text, ConsoleColor.Yellow);
    public static string BgBrightBlue    (this object text) => BgColor(text, ConsoleColor.Blue);
    public static string BgBrightMagenta (this object text) => BgColor(text, ConsoleColor.Magenta);
    public static string BgBrightCyan    (this object text) => BgColor(text, ConsoleColor.Cyan);
    public static string BgBrightWhite   (this object text) => BgColor(text, ConsoleColor.White);
#pragma warning restore format

    /// <returns>Text with background color.</returns>
    public static string BgColor(this object text, ConsoleColor color)
    {
        string sgrCode = color switch
        {
#pragma warning disable format
            ConsoleColor.Black       => "40", // Background Black
            ConsoleColor.DarkRed     => "41", // Background Red
            ConsoleColor.DarkGreen   => "42", // Background Green
            ConsoleColor.DarkYellow  => "43", // Background Yellow
            ConsoleColor.DarkBlue    => "44", // Background Blue
            ConsoleColor.DarkMagenta => "45", // Background Magenta
            ConsoleColor.DarkCyan    => "46", // Background Cyan
            ConsoleColor.Gray        => "47", // Background White
            ConsoleColor.DarkGray    => "100", // Bright Background Black
            ConsoleColor.Red         => "101", // Bright Background Red
            ConsoleColor.Green       => "102", // Bright Background Green
            ConsoleColor.Yellow      => "103", // Bright Background Yellow
            ConsoleColor.Blue        => "104", // Bright Background Blue
            ConsoleColor.Magenta     => "105", // Bright Background Magenta
            ConsoleColor.Cyan        => "106", // Bright Background Cyan
            ConsoleColor.White       => "107", // Bright Background White
#pragma warning restore format
            _ => throw new NotImplementedException(),
        };

        return text.WithAnsiCode(sgrCode, "49");
    }

#pragma warning disable format
    public static string Bold          (this object text) => text.WithAnsiCode("1", "22");
    public static string Dim           (this object text) => text.WithAnsiCode("2", "22");
    public static string Italic        (this object text) => text.WithAnsiCode("3", "23");
    public static string Underline     (this object text) => text.WithAnsiCode("4", "24");
    public static string Blink         (this object text) => text.WithAnsiCode("5", "25");
    public static string Inverse       (this object text) => text.WithAnsiCode("7", "27");
    public static string Hidden        (this object text) => text.WithAnsiCode("8", "28");
    public static string Strikethrough (this object text) => text.WithAnsiCode("9", "29");
#pragma warning restore format

    private static string WithAnsiCode(this object text, string beginCode, string endCode)
    {
        return IsFormattingEnabled
            ? "\x1b[" + beginCode + "m" + text.ToString() + "\x1b[" + endCode + "m"
            : text.ToString();
    }
}
