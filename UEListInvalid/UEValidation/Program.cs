using System;
using System.IO;
using System.Text.RegularExpressions;

class UEValidator
{
    static void Main()
    {
        // Print application name in a stylish format
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("===== UEListInvalid =====");
        Console.ResetColor(); // Reset color to default

        // Print creator information
        Console.WriteLine("Created by: ioan_123");

        // Enter File Path
        Console.WriteLine("\nEnter directory path containing Unreal Engine log files:");
        string directoryPath = Console.ReadLine().Trim();

        // Check if directory path contains necessary subdirectory
        string expectedSubdirectory = "UnrealEditorFortnite\\Saved\\Logs";
        if (!directoryPath.Contains(expectedSubdirectory))
        {
            Console.WriteLine($"\nDirectory path does not contain '{expectedSubdirectory}'. Exiting.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            return;
        }

        // Combine directory path with log file name
        string logFilePath = Path.Combine(directoryPath, "UnrealEditorFortnite.log");

        // Check if log file exists
        if (!File.Exists(logFilePath))
        {
            Console.WriteLine($"\nLog file '{logFilePath}' does not exist. Exiting.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            return;
        }

        // Create directory for outputs
        string currentDirectory = Directory.GetCurrentDirectory();
        string outputFolderName = "Outputs";
        string outputFolderPath = Path.Combine(currentDirectory, outputFolderName);

        try
        {
            // Create Outputs directory if it doesn't exist
            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
            }

            // Define output file path
            string outputFilePath = Path.Combine(outputFolderPath, "InvalidList.log");

            // Open log file and output file for reading and writing respectively
            using (StreamReader reader = new StreamReader(logFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Check LogValkyrieValidation and /Game/
                    if (line.Contains("LogValkyrieValidation:") && line.Contains("/Game/"))
                    {
                        string pattern = @"\/Game\/[^\]]+";
                        Match match = Regex.Match(line, pattern);
                        if (match.Success)
                        {
                            string extractedPath = match.Value;

                            // Remove last character if it's ')'
                            if (extractedPath.EndsWith(")"))
                            {
                                extractedPath = extractedPath.Substring(0, extractedPath.Length - 1);
                            }

                            // Write extracted path to output file
                            writer.WriteLine(extractedPath);
                        }
                    }
                }
            }

            Console.WriteLine($"\nFiltered log file created: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError processing log file: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
