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
        List<OneTask> task_list;
        public TaskList()
        {
            task_list = new List<OneTask>();
        }

        public void AddToList(OneTask new_task)
        {
            this.task_list.Add(new_task);
            this.task_list.Sort();
        }

        public string WriteLine(OneTask task)
        {
            string report = "";

            if (task.Priority == 3)
            {
                report += "!!! ";
            }
            else if (task.Priority == 2)
            {
                report += "!! ";
            }
            else
            {
                report += "! ";
            }

            report += task.Task_name + " before " + task.Deadline.ToString() + "\n";

            return report;
        }

        public string Show()
        {
            string report = "";

            foreach(OneTask task in task_list)
            {
                report += WriteLine(task);
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
                    report += WriteLine(task);
                }
            }

            return report;
             
        }

        public string SearchName(string task_name)
        {
            string report = "";

            foreach (OneTask task in task_list)
            {
                if (task.Task_name == task_name)
                {
                    report += WriteLine(task);
                }
            }

            return report;
        }

        public string SearchPriority(int priority)
        {
            string report = "";

            foreach (OneTask task in task_list)
            {
                if (task.Priority == priority)
                {
                    report += WriteLine(task);
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
