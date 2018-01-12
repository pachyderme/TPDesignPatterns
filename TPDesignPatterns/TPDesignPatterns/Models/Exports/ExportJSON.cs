using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TPDesignPatterns.Models.Exports
{
    public class ExportJSON : ExportData
    {
        public override void Export() => ExportFile(ExportDataType.JSON);
    }
}
