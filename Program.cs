using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



class UpdaterProgram
{

    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);
    static void Main(string[] args)
    {
        Process[] procs = Process.GetProcessesByName("revit");
        foreach (Process process in procs)
        {
            process.WaitForExit();
        }
        var fileName = "FerrumAddinDev.dll";
        string downloadDir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        var localPath = Path.Combine(downloadDir, fileName);

        var tempPath = Path.Combine(downloadDir, "new" + fileName);
        if (File.Exists(tempPath))
        {
            MessageBox((IntPtr)0, "Обновление начато", "Железно", 0);
            File.Delete(localPath);
            File.Move(tempPath, localPath);
            Console.WriteLine($"{fileName} был обновлен.");
            MessageBox((IntPtr)0, "Обновление завершено", "Железно", 0);
        }
    }

}
