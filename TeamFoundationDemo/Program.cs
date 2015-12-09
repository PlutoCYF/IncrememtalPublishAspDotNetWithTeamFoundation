using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.IO;
namespace TeamFoundationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\work\bitauto\爱易车\src\iBitauto.root\iBitauto2.0-Coupon\i.qichetong.com";
            SourceControl = Open(path);
            string scope = WorkSpace.GetServerItemForLocalItem(path);// "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            Console.WriteLine(SourceControl.AuthorizedUser);
            //var queryresult = QueryLabel(null, scope);
            //if (queryresult != null)
            //{
            //    Console.WriteLine(queryresult.Comment);
            //}
            //TestQuery();
            //TestSpec();
            //testHistory();
            //Console.WriteLine("localItem:");
            //Console.WriteLine(WorkSpace.GetLocalItemForServerItem(scope));
            //Console.WriteLine(WorkSpace.GetServerItemForLocalItem(path));
            
          
             
            //Test();
            TeamFoundationHelper.writeHistory(SourceControl, scope, 333388);
            Console.Read();

        }
        public static VersionControlServer SourceControl { get; set; }
        public static TfsTeamProjectCollection TfsCollection { get; set; }
        public static Workspace WorkSpace { get; set; }
        public static VersionControlServer Open(string path)
        {
            var info = Workstation.Current.GetLocalWorkspaceInfo(path);

            var uri = info.ServerUri;

            Console.WriteLine(uri.ToString());

            var tfsCollection = new TfsTeamProjectCollection(uri);
            TfsCollection = tfsCollection;
            WorkSpace = info.GetWorkspace(tfsCollection);
            return tfsCollection.GetService<VersionControlServer>();
        }
        public static void CreateLabel(string scope, string label)
        {
            var itemSpec = new ItemSpec(scope, RecursionType.Full);
            var labelItemSpec = new LabelItemSpec(itemSpec, VersionSpec.Latest, false);
            var vslabel = new VersionControlLabel(SourceControl, label, SourceControl.AuthorizedUser, scope, label);
            var results = SourceControl.CreateLabel(vslabel, new[] { labelItemSpec }, LabelChildOption.Replace);
            if (results != null)
            {
                Console.WriteLine(results.FirstOrDefault().Label);
            }
        }
        public static VersionControlLabel QueryLabel(string label, string scope)
        {
            return SourceControl.QueryLabels(label, null, null, true, scope, VersionSpec.Latest).FirstOrDefault();
        }
        public static void getWorkItem()
        {

            WorkItemStore workItemStore = TfsCollection.GetService<WorkItemStore>();
            WorkItem workItem = workItemStore.GetWorkItem(1);
            string oldAssignedTo = (string)workItem.Fields["Assigned to"].Value;
            Console.WriteLine(oldAssignedTo);
        }


        public static IEnumerable<Changeset> Changes(string scope, string label1, string label2)
        {
            var vsLabel1 = QueryLabel(scope, label1);
            var vsLabel2 = QueryLabel(scope, label2);
            var vsLabelSpec1 = new LabelVersionSpec(vsLabel1.Name, vsLabel1.Scope);
            var vsLabelSpec2 = new LabelVersionSpec(vsLabel2.Name, vsLabel2.Scope);
            return SourceControl.QueryHistory(vsLabelSpec1.Scope,
                VersionSpec.Latest,
                0,
                RecursionType.Full,
                null,
                vsLabelSpec1,
                vsLabelSpec2,
                int.MaxValue,
                true,
                false)
                .Cast<Changeset>();
        }
        public static Item GetSpecVersion(string scope, string label, Item item)
        {
            var vslabel = QueryLabel(scope, label);
            return SourceControl.GetItem(item.ServerItem, new LabelVersionSpec(vslabel.Name, vslabel.Scope));
        }

        private static void TestCreate()
        {
            string labelComment = "Example label";
            string scope = "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            CreateLabel(scope, labelComment);
        }
        private static void TestQuery()
        {
            string labelComment = "Example label";
            string scope = "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            var result = QueryLabel(labelComment, scope);
            Console.WriteLine(result.Comment);
        }
        private static void TestSpec()
        {
            string labelComment = "Example label";
            string scope = "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            var itemSpec = new ItemSpec(scope, RecursionType.Full);

            var historys = SourceControl.QueryHistory(itemSpec);
            if (historys != null)
            {
                Console.WriteLine("history:" + historys.Count());
                var h = historys.ToList()[1];
                Console.WriteLine(h.Comment);

                var changes = SourceControl.GetChangesForChangeset(h.ChangesetId, true, 10, null);
                if (changes != null)
                {
                    Console.WriteLine("changes:" + changes.Count());
                    foreach (var change in changes)
                    {
                        Console.WriteLine(change.Item.ServerItem);
                    }
                }
                //foreach (var h in historys)
                //{
                //    if (h.Changes.Count() > 0)
                //    {


                //    }
                //}
                Console.WriteLine("End history");


            }
        }
        private static void testHistory()
        {
            string scope = "$/A2互动产品研发/爱易车/src/iBitauto.root/iBitauto2.0-Coupon";
            var itemSpec = new ItemSpec(scope, RecursionType.Full);
            QueryHistoryParameters ps = new QueryHistoryParameters(itemSpec);
            ps.VersionStart = VersionSpec.ParseSingleSpec("C336714", null);
            //ps.VersionEnd = VersionSpec.ParseSingleSpec("C336714", null);
            ps.IncludeChanges = true;
            var historys = SourceControl.QueryHistory(ps);
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
                        changes = SourceControl.GetChangesForChangeset(h.ChangesetId, true, 10, null);
                    }
                    if (changes != null)
                    {
                        Console.WriteLine("changes:" + changes.Count());
                        foreach (var change in changes)
                        {
                            Console.WriteLine("type:" + change.ChangeType.ToString());
                            Console.WriteLine(change.Item.ServerItem);
                        }
                    }
                    Console.WriteLine("======================================");
                }
                Console.WriteLine("End history");



            }
        }
        private static void Test()
        {
        


        }
    }
}
