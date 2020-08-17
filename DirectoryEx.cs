
using System;
using System.Collections.Generic;
using System.IO;

public static class DirectoryEx 
{
    public static IEnumerable<FileInfo> EnumerateFileInfo(
        string dirName, Action<string, Exception> errorHandler)
    {
        if (string.IsNullOrWhiteSpace(dirName)) yield break;
        IEnumerable<string> pathNames = null;
        try
        {
            pathNames = Directory.EnumerateFileSystemEntries(dirName);
        }
         catch(Exception exception)
        {
            errorHandler(dirName, exception);
            yield break;
        }
        foreach(var pathName in pathNames)
        {
            var attrs = File.GetAttributes(pathName);
            var isDir = (attrs & FileAttributes.Directory) == FileAttributes.Directory;
            if (isDir)
            {
                foreach(var inner in EnumerateFileInfo(pathName, errorHandler))
                {
                    yield return inner;
                }
            }
            else
            {
                yield return new FileInfo(pathName);
            }
        }
    }
}