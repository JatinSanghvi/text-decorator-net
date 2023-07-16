// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using JatinSanghvi.TextDecorator;

_ = TextDecorator.Activate();

Console.WriteLine("Once in a green forest, a curious fox explored.".BrightRed());
Console.WriteLine("Lost and afraid, he sought a way back.".Green());
Console.WriteLine();

Console.WriteLine("Encountered friendly creatures who helped.".Color(ConsoleColor.DarkGray));
Console.WriteLine();

Console.WriteLine("Time passed; fox learned about the forest.".BgBlue());
Console.WriteLine("Adventures and challenges became life.".BgBrightWhite().Black());
Console.WriteLine();

Console.WriteLine("An owl, wise and old, became his guide.".Color("HotPink"));
Console.WriteLine("Seasons changed, and fox grew wiser.".Color("#3b82f6"));
Console.WriteLine("Home now felt distant; forest was home.".BgColor("#2c6").Color("#031"));
Console.WriteLine();

Console.WriteLine("With the owl's wisdom, he thrived.".Italic());
Console.WriteLine("The fox embraced nature's harmony.".Underline());
Console.WriteLine();

// String interpolation.
Console.WriteLine("In the {0}, he found {1}.", "green forest".BgGreen(), "belonging".BgBlue());

// String variables.
string action = "danced".Inverse();
Console.WriteLine($"His heart {action} and {action}.".Cyan());

// Composite decoration method.
static string highlight(string text)
{
    return text.Bold().Italic().Underline().Blink();
}

Console.WriteLine($"Forever, the {highlight("curious")} fox {highlight("thrived")}.".Yellow());
Console.WriteLine();
