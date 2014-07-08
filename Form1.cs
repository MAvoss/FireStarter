using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FireStarter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
         //   var process = Process.Start("CMD.exe", "/c adb connect " + textBox1.Text);
         //   label1.Text = process.StandardOutput.ReadToEnd();
          //  process.WaitForExit();



            var proc = new Process {
    StartInfo = new ProcessStartInfo {
        FileName = "adb.exe",
        Arguments = "connect " + textBox1.Text,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
    }
};


proc.Start();
while (!proc.StandardOutput.EndOfStream) {
    label1.Text = proc.StandardOutput.ReadLine();
    // do something with line
}



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = "start-server",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };


            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                label1.Text = proc.StandardOutput.ReadLine();
                // do something with line
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = "kill-server",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true

                }
            };


            proc.Start();
            label1.Text = "Server Stopped";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Select your APK..";
            openFileDialog1.FileName = "Choose File..";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = " .APK|*.apk";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

               string path  = "\"" + openFileDialog1.FileName+ "\"";


               
                
                
                
                
                
                var process = Process.Start("CMD.exe", "/c adb install " + path);
               process.WaitForExit();
               MessageBox.Show(".APK is Installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = "reboot",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };


            proc.Start();
        }

      

    

    }
}
