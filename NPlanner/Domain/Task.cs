using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NPlanner.Domain
{
    [DataContract]
    class Task
    {
        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
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
