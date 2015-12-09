using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    class BatHelper
    {
        public static void callBat(string batPath)
        {
            Process p = new Process();
            FileInfo file = new FileInfo(batPath);
            p.StartInfo.WorkingDirectory = file.Directory.FullName;
            p.StartInfo.FileName = batPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.ErrorDialog = true;
            
            p.Start();
            
            //p.StandardInput.WriteLine(batPath);
            
            //p.StandardInput.WriteLine("exit");
            p.WaitForExit(int.MaxValue);
            p.Close();
        }
        public static void InitBat(string physicalPath, string targetPath,string batpath)
        {
            var buildstream = System.IO.File.Open(batpath, System.IO.FileMode.Open);
             var doc = System.Xml.Linq.XDocument.Load(buildstream);
             var aspnode= doc.Elements().FirstOrDefault().Elements().FirstOrDefault().Elements().FirstOrDefault();
             aspnode.Attribute("PhysicalPath").Value = physicalPath;
             aspnode.Attribute("TargetPath").Value = targetPath;
             buildstream.Close();
             doc.Save(batpath);
            
             
        }
    }
}
