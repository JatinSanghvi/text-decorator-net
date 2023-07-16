// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using JatinSanghvi.TextDecorator;

_ = TextDecorator.Activate();

WriteHeading("Foreground Colors");

#pragma warning disable format
Console.Write("    ");
Console.Write("Black"         .Black().BgWhite() + ", ");
Console.Write("Red"           .Red()             + ", ");
Console.Write("Green"         .Green()           + ", ");
Console.Write("Yellow"        .Yellow()          + ", ");
Console.Write("Blue"          .Blue()            + ", ");
Console.Write("Magenta"       .Magenta()         + ", ");
Console.Write("Cyan"          .Cyan()            + ", ");
Console.Write("White"         .White()           + ", ");
Console.Write("Gray"          .Gray()            + ", ");
Console.WriteLine();

Console.Write("    ");
Console.Write("Bright Black"  .BrightBlack()     + ", ");
Console.Write("Bright Red"    .BrightRed()       + ", ");
Console.Write("Bright Green"  .BrightGreen()     + ", ");
Console.Write("Bright Yellow" .BrightYellow()    + ", ");
Console.WriteLine();

Console.Write("    ");
Console.Write("Bright Blue"   .BrightBlue()      + ", ");
Console.Write("Bright Magenta".BrightMagenta()   + ", ");
Console.Write("Bright Cyan"   .BrightCyan()      + ", "); 
Console.Write("Bright White"  .BrightWhite()           );
Console.WriteLine();
#pragma warning restore format

WriteHeading("Background Colors");

#pragma warning disable format
Console.Write("    ");
Console.Write("Black"         .BgBlack()                 + ", ");
Console.Write("Red"           .Black().BgRed()           + ", ");
Console.Write("Green"         .Black().BgGreen()         + ", ");
Console.Write("Yellow"        .Black().BgYellow()        + ", ");
Console.Write("Blue"          .Black().BgBlue()          + ", ");
Console.Write("Magenta"       .Black().BgMagenta()       + ", ");
Console.Write("Cyan"          .Black().BgCyan()          + ", ");
Console.Write("White"         .Black().BgWhite()         + ", ");
Console.Write("Gray"          .Black().BgGray()          + ", ");
Console.WriteLine();

Console.Write("    ");
Console.Write("Bright Black"  .Black().BgBrightBlack()   + ", ");
Console.Write("Bright Red"    .Black().BgBrightRed()     + ", ");
Console.Write("Bright Green"  .Black().BgBrightGreen()   + ", ");
Console.Write("Bright Yellow" .Black().BgBrightYellow()  + ", ");
Console.WriteLine();

Console.Write("    ");
Console.Write("Bright Blue"   .Black().BgBrightBlue()    + ", ");
Console.Write("Bright Magenta".Black().BgBrightMagenta() + ", ");
Console.Write("Bright Cyan"   .Black().BgBrightCyan()    + ", ");
Console.Write("Bright White"  .Black().BgBrightWhite()         );
Console.WriteLine();
#pragma warning restore format

WriteHeading("HTML Color Names and Custom RGB Colors");

#pragma warning disable format
Console.Write("    ");
Console.Write("HotPink"  .Color("HotPink")   + ", ");
Console.Write("Orange"   .Color("Orange")    + ", ");
Console.Write("Gold"     .Color("Gold")      + ", ");
Console.Write("LimeGreen".Color("LimeGreen") + ", ");
Console.Write("Turquoise".Color("Turquoise") + ", ");
Console.Write("Orchid"   .Color("Orchid")          );
Console.WriteLine();

Console.Write("    ");
Console.Write("#06b6d4".BgColor("#06b6d4").Color("#083344") + ", ");
Console.Write("#3b82f6".BgColor("#3b82f6").Color("#172554") + ", ");
Console.Write("#8b5cf6".BgColor("#8b5cf6").Color("#2e1065") + ", ");
Console.Write("#d946ef".BgColor("#d946ef").Color("#4a044e") + ", ");

Console.Write("#e46".BgColor("#e46").Color("#502") + ", ");
Console.Write("#f71".BgColor("#f71").Color("#410") + ", ");
Console.Write("#ec0".BgColor("#ec0").Color("#420") + ", ");
Console.Write("#2c6".BgColor("#2c6").Color("#031")       );
Console.WriteLine();
#pragma warning restore format

WriteHeading("Text Styles");

#pragma warning disable format
Console.Write("    ");
Console.Write("Bold"           .Bold()            + ", ");
Console.Write("Dim"            .Dim()             + ", ");
Console.Write("Italic"         .Italic()          + ", ");
Console.Write("Underline"      .Underline()       + ", ");
Console.Write("Blink"          .Blink()           + ", ");
Console.WriteLine();

Console.Write("    ");
Console.Write("Inverse"        .Inverse()         + ", ");
Console.Write("Hidden"         .Hidden()          + ", ");
Console.Write("Strikethrough"  .Strikethrough()   + ", ");
Console.Write("DoubleUnderLine".DoubleUnderline() + ", ");
Console.Write("Overline"       .Overline()              );
Console.WriteLine();
#pragma warning restore format

WriteHeading("Color and Style Combinations");

Console.WriteLine("    " + "This is {0} on magenta background.".BgMagenta(), "bright yellow text".BrightYellow());
Console.WriteLine("    " + "This is {0} on red foreground.".Red(), "bold, italized and underlined text".Bold().Italic().Underline());
Console.WriteLine("    " + "This is {0} on blue background.".BgBlue(), "blinking and inverted text".Blink().Inverse());
Console.WriteLine("    " + "This is {0} on green foreground.".Green(), "dimmed and striked text".Dim().Strikethrough());

static void WriteHeading(string text)
{
    Console.WriteLine();
    Console.WriteLine($"=== {text} ===".Bold().Italic());
    Console.WriteLine();
}
