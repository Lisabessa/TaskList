using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskListApplication
{
    public partial class Form1 : Form
    {
        TaskList tasklist;
        public Form1()
        {
            InitializeComponent();
            tasklist = new TaskList();
            RefreshList();
        }

        public void RefreshList()
        {
            listView1.Items.Clear();
            foreach(OneTask task in tasklist.task_list)
            {
                listView1.Items.Add(task.WriteLine());
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int priority = 0;
            if (radioButton1.Checked)
            {
                priority = 3;
            }
            else if (radioButton2.Checked)
            {
                priority = 2;
            }
            else if (radioButton3.Checked)
            {
                priority = 1;
            }

            if(priority != 0 && textBox1.Text != "")
            {
                OneTask new_task = new OneTask(textBox1.Text, dateTimePicker1.Value, priority);
                tasklist.AddToList(new_task);
            }
            else
            {
                MessageBox.Show("Task info is not full!");
            }

            RefreshList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if(listView1.CheckedItems.Count != 0)
            {
                for(int i=0; i< listView1.CheckedItems.Count; i++)
                {
                    string task_string = listView1.CheckedItems[i].Text;
                    List<string> string_list = task_string.Split(' ').ToList();
                    int priority = string_list[0].Length;
                    string name = string_list[1];
                    DateTime deadline = DateTime.Parse(string_list[3]);
                    tasklist.DoneTask(name, deadline, priority);
                }
                RefreshList();
            }
            else
            {
                MessageBox.Show("No task selected");
            }
        }
    }
}
