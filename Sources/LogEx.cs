using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PolvakServer.Sources
{
    public static class LogEx
    {
        // с закрытием приложения файл освободится
        private static readonly StreamWriter Writer = File.CreateText("ErrorLogReport.txt");

        public static void WriteLineintoLog(string text)
        {
          Writer.WriteLine("{0} {1}", DateTime.Now, text);
        }
    }
}
