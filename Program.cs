using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Program
{
    public static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
        public static void Main()
        {
            string startPath = OperatingSystem.IsWindows() ? @"C:\" : "/";

            var handle = GetStdHandle(-11); // STD_OUTPUT_HANDLE
        if (GetConsoleMode(handle, out uint mode))
        {
            SetConsoleMode(handle, mode | 0x0004); // ENABLE_VIRTUAL_TERMINAL_PROCESSING
        }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            string oska = GetWindowsFriendlyName();
            int o = 1;
            while (o == 1)  {
            Console.WriteLine($"\u001b[36;1mWELCOME, {oska} USER!\u001b[0m");
            Console.WriteLine($"SSD memory on disk: {startPath}, please wait...");
             List<string> allDirectories = new List<string>();

        try
        {
            var options = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            };

            
            allDirectories = Directory.EnumerateDirectories(startPath, "*", options).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR]: {ex.Message}");
        }


        int totalCount = allDirectories.Count;
        
        
        if (totalCount == 0)
        {
            Console.WriteLine("[ERROR]: files not found");
            return;
        }

        Console.WriteLine("\nstart now");
        Thread.Sleep(1000); 

        
        Random random = new Random();

        
        while (allDirectories.Count > 0)
        {
            
            int randomIndex = random.Next(allDirectories.Count);

            
            string randomDirPath = allDirectories[randomIndex];

            
            int[] rngColors = {1 , 1, 1, 1, 1, 1, 2, 2, 3};
            int numColor = rngColors[random.Next(0, rngColors.Length)];
            if (numColor == 1)
            {
                 Console.WriteLine(randomDirPath);
            } else if (numColor == 2)
            {
                Console.WriteLine($"\u001b[33m{randomDirPath}\u001b[0m");
            } else if (numColor == 3)
                    {
                        Console.WriteLine($"\u001b[32m{randomDirPath}\u001b[0m");
                    }

           

            
            allDirectories.RemoveAt(randomIndex);

            
            int[] myNumbers = { 10, 10, 10, 50, 100, 250};

            

            
            int randomI = myNumbers[random.Next(0, myNumbers.Length)];

           
            

            Thread.Sleep(randomI);
        }

        

            }
            }
        }
        public static string GetWindowsFriendlyName()
        {
            Version osVersion = Environment.OSVersion.Version;

        int major = osVersion.Major;
        int minor = osVersion.Minor;
        int build = osVersion.Build;

        
        if (major == 10)
        {
            
            return build >= 22000 ? "WINDOWS 11" : "WINDOWS 10";
        }
        if (major == 6)
        {
            switch (minor)
            {
                case 3: return "WINDOWS 8.1";
                case 2: return "WINDOWS 8";
                case 1: return "WINDOWS 7";
                case 0: return "WINDOWS Vista";
            }
        }
        if (major == 5)
        {
            if (minor == 1 || minor == 2) return "WINDOWS XP";
        }

        return $"\u001b[31m[lowERROR]: this version Windows not support! (version: {major}.{minor}, Build: {build})\u001b[0m";
        }
    }
}