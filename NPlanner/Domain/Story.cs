using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NPlanner.Domain
{
    [Serializable]
    [DataContract]
    class Story
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public List<Task> Tasks { get; private set; }

        public Story()
        {
            CreationDate = DateTime.Now;
            IsCompleted = false;
            Tasks = new List<Task>();
        }
    }
}
