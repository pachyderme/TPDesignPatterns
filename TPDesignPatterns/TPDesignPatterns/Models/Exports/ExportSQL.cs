using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TPDesignPatterns.Models.Exports
{
    public class ExportSQL : IExportData
    {
        public void Export()
        {
            string filePath = Path.GetTempFileName();
            filePath = Path.ChangeExtension(filePath, ".sql");
            FileStream fileStream = File.Create(filePath);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            Historic.Historic.GetInstance().messages.ForEach(m => streamWriter.WriteLine(m.ToString()));
            streamWriter.Dispose();
            Process.Start(@"cmd.exe", @"/c "+filePath);
            Console.WriteLine($"Export sql file path : {filePath}");
        }
    }
}
