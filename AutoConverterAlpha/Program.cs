using System;
using System.IO;
using System.Security.Permissions;
using System.Diagnostics;
using System.Threading;
using Xabe.FFmpeg;
using System;
using System.Threading.Tasks;

public class Watcher
{
    public static void Main()
    {
        Boolean running = true;

        while (running)
        {
            running = Run();
        }
    }

    private static Boolean Run()
    {
        string[] args = Environment.GetCommandLineArgs();

        // Create a new FileSystemWatcher and set its properties.
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
           //watcher.Path = "C:\\Users\\Tk\\Desktop\\AutoConverter\\Files";
           watcher.Path = "Z:\\4-Lab-Translate";
        

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch movie files.
            watcher.Filter = "*.part";

            // Add event handlers.
            watcher.Created += OnChanged;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Support Studios Converter. 'q' drücken zum Abbrechen.");
            Console.WriteLine("Warte...");
            while (Console.Read() != 'q') ;
        }
        return false;
    }


    private static void OnRenamed(object source, RenamedEventArgs e) =>
        VideoConvert(e.FullPath);

    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e) =>
         // Specify what is done when a file is changed, created, or deleted.
         //Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
         VideoConvert(e.FullPath);

    private static void VideoConvert(String input)
    {
       
        Console.WriteLine("Neues .part File hinzugefügt!");

        Console.WriteLine("Pfad: " + input);

        Console.WriteLine("Puffer für Übertragungszeit läuft...");

        for (int i = 0; i < 60; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine((60-i)+" Sekunde(n) verbleibend.");
        }

        Console.WriteLine("Starte Converting Script...");

        ProcessStartInfo start = new ProcessStartInfo();
         //start.FileName = "C:\\Users\\Tk\\AppData\\Local\\Programs\\Python\\Python38-32\\python.exe";
        start.FileName = " C:\\Users\\Administrator\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";

        //start.Arguments = string.Format("{0} {1}","C:\\Users\\Tk\\Desktop\\AutoConverter\\changeFileFormat.py", input);
        start.Arguments = string.Format("{0} {1}", "C:\\Users\\Administrator\\Desktop\\AutoConverter1.0\\Scripts\\ChangeFileFormat.py", input);
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
        }

    }
}
