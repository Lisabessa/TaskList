using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApplication
{
    [Serializable]
    class OneTask : IComparable<OneTask>
    {
        public string Task_name;
        public DateTime Deadline;
        public int Priority;

        public OneTask(string Task_name, DateTime Deadline, int Priority)
         {
            this.Task_name = Task_name;
            this.Deadline = Deadline;
            this.Priority = Priority;
        }


        public int CompareTo(OneTask other)
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

        public string WriteLine()
        {
            string report = "";

            if (this.Priority == 3)
            {
                report += "!!! ";
            }
            else if (this.Priority == 2)
            {
                report += "!! ";
            }
            else
            {
                report += "! ";
            }

            report += this.Task_name + " before " + this.Deadline.ToString() + "\n";

            return report;
        }
    }

    
}
