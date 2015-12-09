using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamFoundationDemo
{
    public class TeamFoundationHelper
    {
        public TeamFoundationHelper(string path)
        {
            SourceControl=Open(path);
        }
        public VersionControlServer SourceControl { get; set; }
        private  VersionControlServer Open(string path)
        {
            var info = Workstation.Current.GetLocalWorkspaceInfo(path);
            var uri = info.ServerUri;
            var tfsCollection = new TfsTeamProjectCollection(uri);
            return tfsCollection.GetService<VersionControlServer>();
        }
        public void writeHistory( string scope, int version)
        {
            writeHistory(SourceControl, scope, version);
        }

        public static void writeHistory(VersionControlServer sourcecontrol, string scope, int version)
        {
            //string scope = "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            List<string> fileUrls = new List<string>();
            var itemSpec = new ItemSpec(scope, RecursionType.Full);
            QueryHistoryParameters ps = new QueryHistoryParameters(itemSpec);
            
            ps.VersionStart = VersionSpec.ParseSingleSpec("C" + version.ToString(), null);
            //ps.VersionEnd = VersionSpec.ParseSingleSpec("C336714", null);
            ps.IncludeChanges = true;
            var historys = sourcecontrol.QueryHistory(ps);
            if (historys != null)
            {
                Console.WriteLine("history:" + historys.Count());
                foreach (var history in historys)
                {
                    var h = history;
                    Console.WriteLine("======================================");
                    Console.WriteLine(h.Comment);
                    Change[] changes = null;
                    if (h.Changes.Count() > 0)
                    {
                        //Console.WriteLine("chagnes >0");
                        changes = h.Changes;
                    }
                    else
                    {
                        changes = sourcecontrol.GetChangesForChangeset(h.ChangesetId, true, 10, null);
                    }
                    if (changes != null)
                    {
                        Console.WriteLine("changes:" + changes.Count());
                        foreach (var change in changes)
                        {
                            Console.WriteLine("type:" + change.ChangeType.ToString());
                            Console.WriteLine(change.Item.ServerItem);
                            if (!fileUrls.Contains(change.Item.ServerItem))
                            {
                                fileUrls.Add(change.Item.ServerItem);
                            }
                        }
                    }
                    Console.WriteLine("======================================");
                }
                Console.WriteLine("End history");



            }
            string writepath = @"E:\myproject\msbuild\file";
            WriteToFile(writepath, fileUrls);
        }
        private static void WriteToFile(string path,List<string> files)
        {
            string file="/files.txt";
            var stream= System.IO.File.Create(path + file);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stream))
            {
                foreach (var f in files)
                {
                    writer.WriteLine(f);
                }
            }
            
        }
    }
}
