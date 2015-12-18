using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangedFileInPublishedWeb
{
    public interface IVersion
    {
        List<string> GetHistorys(int version);
        List<string> GetHistorys(int version, string author);
    }
}
