using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Day02
{
    public class Test1
    {//class里面放入这段代码
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        static string path = @"E:\大富翁_发布\版本2\room\RoomServer.exe";
        public static void TestExeProgram()
        {
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();//
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                foreach (var proc in myProcesses)
                {
                    if (proc.MainWindowTitle == path)
                    {
                        Console.WriteLine("已经运行");
                        return;
                    }
                 }
            }


            using (Process pCmd = new Process())
            {
                //设置要启动的应用程序
                pCmd.StartInfo.FileName = path;
                //是否使用操作系统shell启动
                pCmd.StartInfo.UseShellExecute = true;


                //不显示程序窗口
                //pCmd.StartInfo.CreateNoWindow = false;
                //启动程序
                bool res = pCmd.Start();
                Console.WriteLine(pCmd.Id);
            }


        }

        public static void Test11()
        {

            // 调用
            string filepath = @"E:\大富翁_发布\版本2\login\RichLoginServer.exe";

        }

        public static string TestExeProgramInOther()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("E:\\大富翁_发布\\版本2\\login\\RichLoginServer.exe");
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.StandardInput.WriteLine("netstat -an");
            process.StandardInput.WriteLine("exit");
            string netMessage = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
            return netMessage;
        }


        public static void StartPress()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"E:\大富翁_发布\版本2\login\RichLoginServer.exe";
            info.Arguments = "";
            //指定程序运行状态，最大化、最小化等
            info.WindowStyle = ProcessWindowStyle.Maximized;
            Process pro = Process.Start(info);
            pro.WaitForExit();
        }

    }
}
