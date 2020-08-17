using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CommandDotNet;
using Console = Colorful.Console;

[Command(Description = "Finds duplicated files recursively.")]
public class FindDup
{
    [DefaultMethod]
    public void Find(string value = null)
    {
        var errors = new List<(string, Exception)>();
        value = value ?? Directory.GetCurrentDirectory();
        foreach(var info in DirectoryEx.EnumerateFileInfo(value, (path, error)=> errors.Add((path, error))))
        {
            Console.WriteLine(info.FullName, Color.White);
        }
    }
}