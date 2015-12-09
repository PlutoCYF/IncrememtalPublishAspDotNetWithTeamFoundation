using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IncrememtalPublish
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new Form1());
            }
            else
            {
                ParamFromCMD(args);
            }
        }
        private static  string physicalPath = "", updatePath = "", publishPath = "";
        private static int version = 0;
        private static bool build = false;
        private static void ParamFromCMD(string[] args)
        {
            foreach (var arg in args)
            {
                GetParams(arg);
            }
            if (build)
            {
                if (physicalPath != "" && updatePath != "" && publishPath != "" && version > 0)
                {
                    ChangedFileInPublishedWeb.StartUp.Start(physicalPath, updatePath, publishPath, version);
                }
            }
            else
            {
                if (physicalPath != "" && updatePath != "" && publishPath != "" && version > 0)
                {
                    ChangedFileInPublishedWeb.StartUp.StartWithoutPublish(physicalPath, updatePath, publishPath, version);
                }
            }
        }
        private static void GetParams(string arg)
        {
            string[] ps=arg.Split('=');
            switch (ps[0])
            {
                case ("-p"):
                    physicalPath = ps[1];
                    break;
                case ("-u"):
                    updatePath = ps[1];
                    break;
                case ("-pub"):
                    publishPath = ps[1];
                    break;
                case ("-v"):
                    int.TryParse(ps[1], out version);
                    break;
                case("-b"):
                    build = true;
                    break;
                default:
                    break;
            }
        }
    }
}
