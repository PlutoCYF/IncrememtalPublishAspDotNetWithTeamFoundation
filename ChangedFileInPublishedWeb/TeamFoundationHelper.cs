using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    public class TeamFoundationHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("TFSInfo");
        public VersionControlServer SourceControl { get; private set; }
        public TfsTeamProjectCollection TfsCollection { get; private set; }
        public Workspace WorkSpace { get; private set; }
        public string Path { get; set; }
        public string Scope { get; set; }

        public TeamFoundationHelper(string path)
        {
            SourceControl = Open(path);
            Path = path;
            Scope = WorkSpace.GetServerItemForLocalItem(path);
        }

        private VersionControlServer Open(string path)
        {
            var info = Workstation.Current.GetLocalWorkspaceInfo(path);
            var uri = info.ServerUri;
            var tfsCollection = new TfsTeamProjectCollection(uri);
            TfsCollection = tfsCollection;
            WorkSpace = info.GetWorkspace(tfsCollection);
            return tfsCollection.GetService<VersionControlServer>();
        }
        public List<string> GetHistorys(int version)
        {
            return GetHistorys(this.SourceControl, this.Scope, version,"");
        }
        public List<string> GetHistorys(int version, string author)
        {
            return GetHistorys(this.SourceControl, this.Scope, version, author);
        }
        private List<string> GetHistorys(VersionControlServer sourcecontrol, string scope, int version,string author)
        {

            List<string> fileUrls = new List<string>();
            var itemSpec = new ItemSpec(scope, RecursionType.Full);
            QueryHistoryParameters ps = new QueryHistoryParameters(itemSpec);

            ps.VersionStart = VersionSpec.ParseSingleSpec("C" + version.ToString(), null);
            
            ps.Author = author;// @"TECH\chenyf";
            ps.IncludeChanges = true;
            var historys = sourcecontrol.QueryHistory(ps);
            if (historys != null)
            {

                foreach (var history in historys)
                {
                    var h = history;

                    Change[] changes = null;
                    if (h.Changes.Count() > 0)
                    {

                        changes = h.Changes;
                    }
                    else
                    {
                        changes = sourcecontrol.GetChangesForChangeset(h.ChangesetId, true, 10, null);
                    }
                    if (changes != null)
                    {
                        foreach (var change in changes)
                        {
                            if (!fileUrls.Contains(change.Item.ServerItem))
                            {
                                fileUrls.Add(change.Item.ServerItem);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < fileUrls.Count; i++)
            {
                string file = fileUrls[i];
                fileUrls[i] = file.Replace(Scope, "").ToLower();
            }

            logs(fileUrls);
            return fileUrls;
        }
        private void logs(List<string> files)
        {
            foreach (var f in files)
            {
                log.Info(f);
            }


        }
    }
}
