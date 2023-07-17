// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using System.Drawing;
using System.Runtime.InteropServices;

namespace JatinSanghvi.TextDecorator;

public static class TextDecorator
{
    private static bool IsEnabled;

    /// <summary>
    /// Activates text decoration. The method should be called before the printing decorated text.
    /// </summary>
    /// <param name="enableErrorLogging">Log error messages to console.</param>
    /// <returns>True if initialization is successful; false otherwise.</returns>
    public static bool Activate(bool enableErrorLogging = false)
    {
        IsEnabled = !Console.IsOutputRedirected
            && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NO_COLOR")) // https://no-color.org/
            && (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                || PlatformWindows.SetConsoleOutputVirtualTerminalProcessing(enableErrorLogging));

        return IsEnabled;
    }

    // ANSI SGR Escape Codes:
    // https://en.wikipedia.org/wiki/ANSI_escape_code#SGR_(Select_Graphic_Rendition)_parameters
    // https://learn.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences#text-formatting

#pragma warning disable format
    public static string Black         (this string text) => text.Color(ConsoleColor.Black);
    public static string Red           (this string text) => text.Color(ConsoleColor.DarkRed);
    public static string Green         (this string text) => text.Color(ConsoleColor.DarkGreen);
    public static string Yellow        (this string text) => text.Color(ConsoleColor.DarkYellow);
    public static string Blue          (this string text) => text.Color(ConsoleColor.DarkBlue);
    public static string Magenta       (this string text) => text.Color(ConsoleColor.DarkMagenta);
    public static string Cyan          (this string text) => text.Color(ConsoleColor.DarkCyan);
    public static string White         (this string text) => text.Color(ConsoleColor.Gray);
    public static string Gray          (this string text) => text.Color(ConsoleColor.DarkGray);
    public static string BrightBlack   (this string text) => text.Color(ConsoleColor.DarkGray);
    public static string BrightRed     (this string text) => text.Color(ConsoleColor.Red);
    public static string BrightGreen   (this string text) => text.Color(ConsoleColor.Green);
    public static string BrightYellow  (this string text) => text.Color(ConsoleColor.Yellow);
    public static string BrightBlue    (this string text) => text.Color(ConsoleColor.Blue);
    public static string BrightMagenta (this string text) => text.Color(ConsoleColor.Magenta);
    public static string BrightCyan    (this string text) => text.Color(ConsoleColor.Cyan);
    public static string BrightWhite   (this string text) => text.Color(ConsoleColor.White);
#pragma warning restore format

    /// <summary>Applies one of the <see cref="System.ConsoleColor" /> colors to the text foreground.</summary>
    public static string Color(this string text, ConsoleColor color)
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

    /// <summary>Applies input HTML color name or hex triplet (#RRGGBB or #RGB) to the text foreground.</summary>
    public static string Color(this string text, string htmlColor) => text.Color(ColorTranslator.FromHtml(htmlColor));

    /// <summary>Applies one of the <see cref="System.Drawing.Color" /> colors to the text foreground.</summary>
    public static string Color(this string text, Color color)
    {
        string sgrCode = $"38;2;{color.R};{color.G};{color.B}";
        return text.WithAnsiCode(sgrCode, "39");
    }

#pragma warning disable format
    public static string BgBlack         (this string text) => text.BgColor(ConsoleColor.Black);
    public static string BgRed           (this string text) => text.BgColor(ConsoleColor.DarkRed);
    public static string BgGreen         (this string text) => text.BgColor(ConsoleColor.DarkGreen);
    public static string BgYellow        (this string text) => text.BgColor(ConsoleColor.DarkYellow);
    public static string BgBlue          (this string text) => text.BgColor(ConsoleColor.DarkBlue);
    public static string BgMagenta       (this string text) => text.BgColor(ConsoleColor.DarkMagenta);
    public static string BgCyan          (this string text) => text.BgColor(ConsoleColor.DarkCyan);
    public static string BgWhite         (this string text) => text.BgColor(ConsoleColor.Gray);
    public static string BgGray          (this string text) => text.BgColor(ConsoleColor.DarkGray);
    public static string BgBrightBlack   (this string text) => text.BgColor(ConsoleColor.DarkGray);
    public static string BgBrightRed     (this string text) => text.BgColor(ConsoleColor.Red);
    public static string BgBrightGreen   (this string text) => text.BgColor(ConsoleColor.Green);
    public static string BgBrightYellow  (this string text) => text.BgColor(ConsoleColor.Yellow);
    public static string BgBrightBlue    (this string text) => text.BgColor(ConsoleColor.Blue);
    public static string BgBrightMagenta (this string text) => text.BgColor(ConsoleColor.Magenta);
    public static string BgBrightCyan    (this string text) => text.BgColor(ConsoleColor.Cyan);
    public static string BgBrightWhite   (this string text) => text.BgColor(ConsoleColor.White);
#pragma warning restore format

    /// <summary>Applies one of the <see cref="System.ConsoleColor" /> colors to the text background.</summary>
    public static string BgColor(this string text, ConsoleColor color)
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

    /// <summary>Applies input HTML color name or hex triplet (#RRGGBB or #RGB) to the text background.</summary>
    public static string BgColor(this string text, string htmlColor) => text.BgColor(ColorTranslator.FromHtml(htmlColor));

    /// <summary>Applies one of the <see cref="System.Drawing.Color" /> colors to the text background.</summary>
    public static string BgColor(this string text, Color color)
    {
        string sgrCode = $"48;2;{color.R};{color.G};{color.B}";
        return text.WithAnsiCode(sgrCode, "49");
    }

#pragma warning disable format
    public static string Bold            (this string text) => text.WithAnsiCode( "1", "22");
    public static string Dim             (this string text) => text.WithAnsiCode( "2", "22");
    public static string Italic          (this string text) => text.WithAnsiCode( "3", "23");
    public static string Underline       (this string text) => text.WithAnsiCode( "4", "24");
    public static string Blink           (this string text) => text.WithAnsiCode( "5", "25");
    public static string Inverse         (this string text) => text.WithAnsiCode( "7", "27");
    public static string Hidden          (this string text) => text.WithAnsiCode( "8", "28");
    public static string Strikethrough   (this string text) => text.WithAnsiCode( "9", "29");
    public static string DoubleUnderline (this string text) => text.WithAnsiCode("21", "24");
    public static string Overline        (this string text) => text.WithAnsiCode("53", "55");
#pragma warning restore format

    private static string WithAnsiCode(this string text, string beginCode, string endCode)
    {
        return IsEnabled
            ? "\x1b[" + beginCode + "m" + text + "\x1b[" + endCode + "m"
            : text;
    }
}
