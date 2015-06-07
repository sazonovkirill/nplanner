using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlanner.Domain
{
    class Task
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsCompleted { get; set; }
        public Story Story { get; set; }

        public Task()
        {
            CreationDate = DateTime.Now;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return "Task(" + Title + ")";
        }

    }
}
