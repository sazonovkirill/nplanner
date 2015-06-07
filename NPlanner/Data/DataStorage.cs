using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Json;
using System.IO;

using NPlanner.Domain;

namespace NPlanner.Data
{
    class DataStorage : IDataStorage
    {
        private IDictionary<long, Story> stories = new Dictionary<long, Story>();

        private IdGenerator idGenerator = new IdGenerator();

        public List<Story> GetStories()
        {
            return new List<Story>(from story in stories.Values select CloneStory(story));
        }

        public void PersistStory(Story story)
        {
            if (story.Id == 0)
            {
                story.Id = idGenerator.GetId();
            }
            stories[story.Id] = CloneStory(story);
        }

        public void RemoveStory(Story story)
        {
            stories.Remove(story.Id);            
        }

        public int Size
        {
            get { return stories.Count; }
        }

        public string ToJson()
        {
            List<Story> stories = GetStories();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Story>));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ser.WriteObject(memoryStream, stories);
                memoryStream.Position = 0;
                using (StreamReader sr = new StreamReader(memoryStream))
                {                    
                    return sr.ReadToEnd();
                }
            }
        }

        public void FromJson(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Story>));
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter sw = new StreamWriter(memoryStream);
            sw.Write(json);
            sw.Flush();
            memoryStream.Position = 0;
            List<Story> stories = (List<Story>)ser.ReadObject(memoryStream);

            this.stories = new Dictionary<long, Story>();
            foreach (Story story in stories)
            {
                foreach (Task task in story.Tasks)
                {
                    task.Story = story;
                }
                this.stories.Add(story.Id, story);
            }
        }

        private static Story CloneStory(Story story)
        {
            Story newStory = new Story()
            {
                Id = story.Id,
                Title = story.Title,
                Description = story.Description,
                CreationDate = story.CreationDate,
                IsCompleted = story.IsCompleted
            };
            foreach (Task task in story.Tasks) 
            {
                Task newTask = CloneTask(task);
                newTask.Story = newStory;
                newStory.Tasks.Add(newTask);
            }
            return newStory;
        }

        private static Task CloneTask(Task task)
        {
            return new Task()
            {
                Index = task.Index,
                Title = task.Title,
                Description = task.Description,
                ExpirationDate = task.ExpirationDate,
                CreationDate = task.CreationDate,
                IsCompleted = task.IsCompleted
            };
        }

        class IdGenerator
        {
            private long lastId = 1;
            public long GetId()
            {
                return Interlocked.Increment(ref lastId);
            }
        }
    }
}
