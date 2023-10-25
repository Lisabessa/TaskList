using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApplication
{
    [Serializable]
    class Task : IComparable<Task>
    {
        public string Task_name;
        public DateTime Deadline;
        public int Priority;

        public Business(string Task_name, DateTime Deadline, int Priority)
        {
            this.Task_name = Task_name;
            this.Deadline = Deadline;
            this.Priority = Priority;

        }

        public int CompareTo(Task other)
        {
            if (this.Deadline > other.Deadline)
            {
                return 1;
            }
            else if (this.Deadline < other.Deadline)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
