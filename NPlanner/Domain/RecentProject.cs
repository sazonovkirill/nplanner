using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlanner.Domain
{
    class RecentProject
    {
        public string FilePath { get; private set; }
        public DateTime LastAccessDate { get; set; }

        public RecentProject(string filePath)
        {
            FilePath = filePath;
        }
    }
}
