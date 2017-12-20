using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 腾讯课堂作业4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static bool processEnd = false;
        private static object frontLock = new object();
        private static string[] frontNumArray = new string[]  {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33","34","35"
        };

        private static object behindLock = new object();
        private static string[] behindNumArray = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };



        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                this.btnStart.Enabled = false;
                this.btnEnd.Enabled = true;
                this.btnStart.Text = "开始ing";
                processEnd = false;

                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();
                foreach (Control control in this.groupBox2.Controls)
                {
                    if (control is Label)
                    {
                        Label label = (Label)control;
                        taskList.Add(taskFactory.StartNew(() =>
                        {
                            try
                            {
                                while (processEnd == false)
                                {
                                    Thread.Sleep(500);
                                    if (label.Name.Contains("front"))
                                    {
                                        int index = new Random().Next(0, 35);
                                        string nowNum = frontNumArray[index];
                                        lock (frontLock)
                                        {
                                            if (!GetUserNum(this.groupBox2).Contains(nowNum))
                                            {
                                                this.Invoke(new Action(() => { label.Text = nowNum; }));
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }));
                    }
                }
                foreach (Control control in this.groupBox3.Controls)
                {
                    if (control is Label)
                    {
                        Label label = (Label)control;
                        taskList.Add(taskFactory.StartNew(() =>
                        {
                            while (processEnd == false)
                            {
                                Thread.Sleep(500);
                                if (label.Name.Contains("behind"))
                                {
                                    int index = new Random().Next(0, 12);
                                    string nowNum = behindNumArray[index];
                                    lock (behindLock)
                                    {
                                        if (!GetUserNum(this.groupBox3).Contains(nowNum))
                                        {
                                            this.Invoke(new Action(() => { label.Text = nowNum; }));
                                        }
                                    }
                                }
                            }
                        }));
                    }
                }

                taskFactory.ContinueWhenAll(taskList.ToArray(), t =>
                {
                    stopwatch.Stop();
                    Console.WriteLine("耗时{0}ms", stopwatch.ElapsedMilliseconds);
                    ShowResult();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("程序发生异常：" + ex.Message);
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnEnd.Enabled = false;
            this.btnStart.Text = "Start";
            processEnd = true;
        }

        private void ShowResult()
        {
            MessageBox.Show(string.Format("本期大乐透结果为--前区：{0} {1} {2} {3} {4}  后区：{5} {6}"
               , this.frontLbl1.Text
               , this.frontLbl2.Text
               , this.frontLbl3.Text
               , this.frontLbl4.Text
               , this.frontLbl5.Text
               , this.behindLbl1.Text
               , this.behindLbl2.Text));
        }

        private List<string> GetUserNum(GroupBox groupBox)
        {
            List<string> userList = new List<string>();
            foreach (Control item in groupBox.Controls)
            {
                if (item is Label)
                {
                    userList.Add(((Label)item).Text);
                }
            }
            return userList;
        }
    }
}
