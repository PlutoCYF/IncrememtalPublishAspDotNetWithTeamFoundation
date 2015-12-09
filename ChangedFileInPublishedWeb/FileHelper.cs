using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    class FileHelper
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("FileInfo");
        public static string[] GetPublishFiles(string publishPath)
        {
            var files = System.IO.Directory.GetFiles(publishPath, "*.*", System.IO.SearchOption.AllDirectories);
            var filelist = new List<string>();
            filelist.AddRange(files);
            Logs("publishfiles.txt", filelist);

            return files;
        }

        public static void UpdatePublishFiles(string publishPath, string updatePath, List<string> updateFiles)
        {
            var publishedFiles = GetPublishFiles(publishPath);
            List<string> updatePublishFilesList = new List<string>(updateFiles.Count);
            List<UpdateFiles> updatefileinfolist = new List<UpdateFiles>();
            System.Collections.Generic.Dictionary<string, string> publishDic = new Dictionary<string, string>(publishedFiles.Length);
            System.Collections.Generic.Dictionary<string, string> publishBinDic = new Dictionary<string, string>(publishedFiles.Length);
            foreach (var file in publishedFiles)
            {
                publishDic.Add(file.Replace(publishPath, "").Replace("\\", "/").ToLower(), file);
                if (file.Contains("bin"))
                {
                    publishBinDic.Add(file.Replace(publishPath, "").Replace("\\", "/").ToLower(), file);
                }
            }
            foreach (var file in updateFiles)
            {
                UpdateFiles updateFile = new UpdateFiles();
                string[] extensions = ".aspx;.ashx;.master;.js".Split(';');
                string extension = System.IO.Path.GetExtension(file).ToLower();
                if (extension == ".cs")
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
                    string ex = System.IO.Path.GetExtension(file);
                    string dllname = GetFileNameFromAspx(file, publishPath, ex);

                    //foreach (var key in publishBinDic.Keys)
                    //{
                    //    if (key.Contains(fileNameWithoutExtension))
                    //    {
                    //        updateFile.OldPath = publishBinDic[key];
                    //        updateFile.NewPath = publishBinDic[key].Replace(publishPath, updatePath);
                    //        updatePublishFilesList.Add(updateFile.NewPath);
                    //        updatefileinfolist.Add(updateFile);
                    //        break;
                    //    }

                    //}
                    if (publishBinDic.ContainsKey(dllname))
                    {
                        updateFile.OldPath = publishBinDic[dllname];
                        updateFile.NewPath = publishBinDic[dllname].Replace(publishPath, updatePath);
                        updatePublishFilesList.Add(updateFile.NewPath);
                        updatefileinfolist.Add(updateFile);
                    }
                }
                else if (extensions.Contains(extension))
                {
                    string name = file.ToLower();
                    if (publishDic.ContainsKey(name))
                    {
                        updateFile.OldPath = publishDic[name];
                        updateFile.NewPath = publishDic[name].Replace(publishPath, updatePath);
                        updatePublishFilesList.Add(updateFile.NewPath);
                        updatefileinfolist.Add(updateFile);
                    }
                }
                else
                {

                }

            }

            Logs("updatefiles.txt", updatePublishFilesList);

            CreateDirectors(updatePublishFilesList);
            CopyFiles(updatefileinfolist);

        }

        private static string GetFileNameFromAspx(string path, string publispath, string ex)
        {
            string result = "";
            string fullpath = publispath + @"\" + path.Replace(ex, "");

            System.IO.StreamReader reader = new System.IO.StreamReader(fullpath);
            string firstline = "";
            while (firstline.Length == 0)
            {
                firstline = reader.ReadLine();
            }

            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("inherits=\"(.*),(.*)\"(.*)%>");
            if (re.IsMatch(firstline))
            {
                result = @"/bin/" + re.Match(firstline).Groups[2].Value.Trim() + ".dll";
            }
            return result.ToLower();
        }
        private static void CreateDirectors(List<string> data)
        {
            foreach (var file in data)
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file));

            }
        }
        private static void CopyFiles(List<UpdateFiles> files)
        {
            foreach (var file in files)
            {
                System.IO.File.Copy(file.OldPath, file.NewPath, true);
            }
        }
        private static void Logs(string filename, List<string> data)
        {
            foreach (var f in data)
            {
                //writer.WriteLine(f);
                log.Info(f);
            }

        }
        private class UpdateFiles
        {
            public string OldPath { get; set; }
            public string NewPath { get; set; }
        }
    }
}
