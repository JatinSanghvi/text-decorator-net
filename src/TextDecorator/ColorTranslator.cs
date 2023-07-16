// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using System.ComponentModel;
using System.Drawing;

namespace JatinSanghvi.TextDecorator;

// Class ColorTranslator is not available for library targetting .NET Standard 2.0, hence copying the implementation
// from https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Advanced/ColorTranslator.cs.

internal static class ColorTranslator
{
    public static Color FromHtml(string htmlColor)
    {
        if (string.IsNullOrEmpty(htmlColor))
        {
            return Color.Empty;
        }

        if (htmlColor[0] == '#')
        {
            if (htmlColor.Length == 7) // #RRGGBB
            {
                return Color.FromArgb(
                    Convert.ToInt32(htmlColor.Substring(1, 2), 16),
                    Convert.ToInt32(htmlColor.Substring(3, 2), 16),
                    Convert.ToInt32(htmlColor.Substring(5, 2), 16));
            }

            if (htmlColor.Length == 4) // #RGB
            {
                return Color.FromArgb(
                    Convert.ToInt32($"{htmlColor[1]}{htmlColor[1]}", 16),
                    Convert.ToInt32($"{htmlColor[2]}{htmlColor[2]}", 16),
                    Convert.ToInt32($"{htmlColor[3]}{htmlColor[3]}", 16));
            }
        }

        // Special case: HTML requires LightGrey but .NET uses LightGray.
        if (String.Equals(htmlColor, "LightGrey", StringComparison.OrdinalIgnoreCase))
        {
            return Color.LightGray;
        }

        // Resort to type converter which will handle named colors.
        return (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(htmlColor);
    }
}
