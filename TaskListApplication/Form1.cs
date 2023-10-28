using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TaskListApplication
{
    public partial class Form1 : Form
    {
        TaskList tasklist = new TaskList();
        StreamWriter sw;
        BinaryFormatter bf = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();

            if(File.Exists("Task_list") == true)
            {
                using(Stream output1 = File.OpenRead("Task_list"))
                {
                    tasklist = (TaskList)bf.Deserialize(output1);
                    RefreshList();
                }
            }
            
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
                    for(int j = 2; j < string_list.Count - 3; j++)
                    {
                        name += " " + string_list[j];
                    }
                    DateTime deadline = DateTime.Parse(string_list[string_list.Count - 2]);
                    tasklist.DoneTask(name, deadline, priority);
                }
                RefreshList();
            }
            else
            {
                MessageBox.Show("No task selected");
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            foreach(OneTask task in tasklist.task_list)
            {
                string info = task.CheckName(textBox2.Text);
                if(info != "")
                {
                    listView2.Items.Add(info);
                }
            }
            
        }

        private void comboBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            int priority = 3 - comboBox1.SelectedIndex;

            foreach (OneTask task in tasklist.task_list)
            {
                string info = task.CheckPriority(priority);
                if (info != "")
                {
                    listView2.Items.Add(info);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            foreach (OneTask task in tasklist.task_list)
            {
                string info = task.CheckDeadline(dateTimePicker2.Value);
                if (info != "")
                {
                    listView2.Items.Add(info);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Stream output1 = File.Create("Task_list"))
            {
                bf.Serialize(output1, tasklist);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if(fbd.SelectedPath != "")
            {
                sw = new StreamWriter(fbd.SelectedPath + "\\TaskList.txt", true);
                string line = tasklist.Show();
                sw.WriteLine(line);
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tasklist = new TaskList();
            RefreshList();
        }
    }
}
