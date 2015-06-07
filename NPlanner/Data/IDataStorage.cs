using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPlanner.Domain;

namespace NPlanner.Data
{
    interface IDataStorage
    {
        List<Story> GetStories();
        void PersistStory(Story story);
        void RemoveStory(Story story);
        int Size { get; }
    }
}
