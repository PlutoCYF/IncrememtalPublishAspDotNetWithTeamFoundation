using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    public class StartUp
    {
        private static string batpath = System.Environment.CurrentDirectory + @"\Bat\buildweb.xml";
        private static string batbuild = System.Environment.CurrentDirectory + @"\Bat\build.bat";
        static StartUp()
        {
            log4net.Config.XmlConfigurator.Configure(); 
        }
        /// <summary>
        /// 编译网站，并生成增量更新包
        /// </summary>
        /// <param name="physicalPath"></param>
        /// <param name="updatePath"></param>
        /// <param name="publishPath"></param>
        /// <param name="version"></param>
        public static void Start(string physicalPath, string updatePath, string publishPath, int version)
        {
            BatHelper.InitBat(physicalPath, publishPath, batpath);
            BatHelper.callBat(batbuild);
            StartWithoutPublish(physicalPath, updatePath, publishPath, version);
        }
        /// <summary>
        /// 只生成增量更新包
        /// </summary>
        /// <param name="physicalPath"></param>
        /// <param name="updatePath"></param>
        /// <param name="publishPath"></param>
        /// <param name="version"></param>
        public static void StartWithoutPublish(string physicalPath, string updatePath, string publishPath, int version)
        {
            //TeamFoundationHelper helper = new TeamFoundationHelper(physicalPath);
            IVersion versionProduct= TeamFoundationFactory.GetVersion(physicalPath);
            var historylist = versionProduct.GetHistorys(version);
            FileHelper.UpdatePublishFiles(publishPath, updatePath, historylist);
        }
    }
}
