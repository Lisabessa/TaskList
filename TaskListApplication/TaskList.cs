using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApplication
{
    [Serializable]
    class TaskList
    {
        public List<OneTask> task_list { get; }

        
        public TaskList()
        {
            task_list = new List<OneTask>();
        }

        public void AddToList(OneTask new_task)
        {
            this.task_list.Add(new_task);
            this.task_list.Sort();
        }

        

        public string Show()
        {
            string report = "";

            foreach(OneTask task in task_list)
            {
                report += task.WriteLine();
            }

            return report;
        }

        public string SearchDeadline(DateTime deadline)
        {
            string report = "";

            foreach (OneTask task in task_list)
            {
                if(task.Deadline.Date == deadline.Date)
                {
                    report += task.WriteLine();
                }
            }

            return report;
             
        }

        public void DoneTask(string task_name, DateTime deadline, int priority)
        {
            for (int i = 0; i < task_list.Count; i++)
            {
                if (task_list[i].Task_name == task_name && task_list[i].Deadline.Date == deadline.Date && task_list[i].Priority == priority)
                {
                    task_list.RemoveAt(i);
                }
            }
        }

    }
}
