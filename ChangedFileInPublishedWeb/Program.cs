using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path = @"E:\work\bitauto\爱易车\src\iBitauto.root\iBitauto2.0-develop\m.qichetong.com";
            string batpath = System.Environment.CurrentDirectory + @"\Bat\buildweb.xml";
            string publish = @"E:\发布\m.yiche.com";
            string updatepath = @"E:\myproject\msbuild\copy";
            string batbuild = System.Environment.CurrentDirectory + @"\Bat\build.bat";
            log4net.Config.XmlConfigurator.Configure();
            BatHelper.InitBat(path, publish, batpath);
            if (args.Length != 0)
            {
                foreach(var arg in args){
                    Console.WriteLine(arg);
                }
            }
            //var InstallDir = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\VisualStudio\\10.0\\Setup\\VS",
            //    "EnvironmentDirectory", null);
            //Console.WriteLine("vs path:" + InstallDir.ToString());

            //Console.ReadKey();
            //Console.WriteLine("start call bat:" + batbuild);
            //BatHelper.callBat(batbuild);
            //Console.WriteLine("end call bat");
            //string str = Convert.ToString(@"Index.aspx".GetHashCode(), 16);
            //TeamFoundationHelper helper = new TeamFoundationHelper(path);
            //var historylist = helper.GetHistorys(387736);



            //FileHelper.UpdatePublishFiles(publish, updatepath, historylist);
        }

    }
}
