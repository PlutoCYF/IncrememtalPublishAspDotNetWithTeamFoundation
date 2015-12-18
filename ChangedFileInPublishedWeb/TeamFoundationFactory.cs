using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    internal class TeamFoundationFactory
    {
        public static IVersion GetVersion(string physicalPath)
        {
            IVersion helper = new TeamFoundationHelper(physicalPath);
            return helper;
        }
    }
}
