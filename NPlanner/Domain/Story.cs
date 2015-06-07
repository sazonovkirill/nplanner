﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlanner.Domain
{
    class Story
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsCompleted { get; set; }
        public List<Task> Tasks { get; private set; }

        public Story()
        {
            CreationDate = DateTime.Now;
            IsCompleted = false;
            Tasks = new List<Task>();
        }
    }
}
