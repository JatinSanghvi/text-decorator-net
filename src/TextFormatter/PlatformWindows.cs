// -------------------------------------------------
// Copyright (c) Jatin Sanghvi. All rights reserved.
// -------------------------------------------------

using System.ComponentModel;
using System.Runtime.InteropServices;

internal static class PlatformWindows
{
    private const uint ENABLE_PROCESSED_OUTPUT = 0x0004;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    private static readonly IntPtr INVALID_HANDLE_VALUE = new(-1); // WinBase.h

    public static bool SetConsoleOutputVirtualTerminalProcessing(bool enableLogging)
    {
        IntPtr handle = GetStdHandle(-11 /* STD_OUTPUT_HANDLE */);

        if (handle == INVALID_HANDLE_VALUE)
        {
            LogException(enableLogging, "Failed to retrieve the output console handle.");
            return false;
        }

        if (!GetConsoleMode(handle, out uint mode))
        {
            LogException(enableLogging, "Failed to retrieve the current console mode.");
            return false;
        }

        if (!SetConsoleMode(handle, mode | ENABLE_PROCESSED_OUTPUT | ENABLE_VIRTUAL_TERMINAL_PROCESSING))
        {
            LogException(enableLogging, "Failed to set the console mode.");
            return false;
        }

        return true;
    }

    private static void LogException(bool enableLogging, string messagePrefix)
    {
        if (enableLogging)
        {
            int errorCode = Marshal.GetLastWin32Error();
            var exception = new Win32Exception(errorCode);
            Console.WriteLine($"{messagePrefix} Exception: [{exception.Message}].");
        }
    }

    // Console Functions: https://learn.microsoft.com/en-us/windows/console/console-functions

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint dwMode);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
}
