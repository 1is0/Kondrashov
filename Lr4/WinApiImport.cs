using System;
using System.Text;
using System.Runtime.InteropServices;

namespace UnsafeCode
{
    class WinApiImport
    {
        static void Main()
        {
            SystemInfo sysI=new SystemInfo();
            Console.WriteLine("Information about system's memory: \n");
            sysI.ShowMemory();
            Console.WriteLine("\nInformation about CPU and monitors: \n");
            sysI.ShowCPU();
            Console.WriteLine();

            Console.WriteLine("Example of DllImport: \n");
            MyDllImport.DllTreatment();

            Console.ReadKey();
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public class MemoryStatusEX
    {
       
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;

        public MemoryStatusEX()
        {
            this.dwLength = (uint)Marshal.SizeOf(typeof(MemoryStatusEX));
        }
    }



        public class ProcessInfo
        {
            public short ProcessorArchitecture;
            public uint PageSize;
            public IntPtr MinimumApplicationAddress;
            public IntPtr MaximumApplicationAddress;
            public IntPtr ActiveProcessorMask;
            public uint NumberOfProcessors;
            public uint ProcessorType;
            public uint AllocationGranularity;
            public ushort ProcessorLevel;
            public ushort ProcessorRevision;
        }

        class SystemInfo
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool GlobalMemoryStatusEx( MemoryStatusEX buffer);

            [DllImport("kernel32.dll", SetLastError = false)]
            public static extern void GetSystemInfo( ProcessInfo Info);

            [DllImport("user32.dll")]
            static extern int GetSystemMetrics(int smIndex);

        public void ShowMemory()
            {
                MemoryStatusEX memStatus = new MemoryStatusEX();
                GlobalMemoryStatusEx(memStatus);

                StringBuilder MemoryInfo = new StringBuilder();
                MemoryInfo.Append("Memory Length: "
                    + memStatus.dwLength.ToString() + "\n");
                MemoryInfo.Append("Memory Load: "
                    + memStatus.dwMemoryLoad.ToString() + "%" + "\n");
                MemoryInfo.Append("Total Physical: "
                    + (memStatus.ullTotalPhys / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");
                MemoryInfo.Append("Avail Physical: "
                    + (memStatus.ullAvailPhys / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");
                MemoryInfo.Append("Total Page File: "
                    + (memStatus.ullTotalPageFile / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");
                MemoryInfo.Append("Avail Page File: "
                    + (memStatus.ullAvailPageFile / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");
                MemoryInfo.Append("Total Virtual: "
                    + (memStatus.ullTotalVirtual / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");
                MemoryInfo.Append("Avail Virtual: "
                    + (memStatus.ullAvailVirtual / Math.Pow(2, 30)).ToString() + " " + "GB" + "\n");

                Console.WriteLine(MemoryInfo);

            }

            public void ShowCPU()
            {
                ProcessInfo info = new ProcessInfo();
                GetSystemInfo(info);

                int smIndex=80;
                int m = GetSystemMetrics(smIndex);

                string strCPU ;

                if (info.ProcessorArchitecture==0)
                {
                    strCPU = "x86";                            
                }
                else
                {
                    if(info.ProcessorArchitecture==9)
                    {
                        strCPU = "x64";
                    }
                        else
                        {
                            if(info.ProcessorArchitecture==-1)
                            {
                                strCPU = "@Arm";
                            }
                                else
                                {
                                    if(info.ProcessorArchitecture==6)
                                    {
                                        strCPU = "Itanium";
                                    }
                                    else
                                    {
                                        strCPU = "Others";
                                    }
                                }
                        }                     
                }

            Console.WriteLine("Processor type: "+strCPU);
            Console.WriteLine("Count of processor: "+(info.NumberOfProcessors+1).ToString());
            Console.WriteLine("Count of monitors: "+m.ToString());
            }
        }
    
}