

using OS_Phase_1.Disk_Scheduling;
using OS_Phase_1.SchedulinigAlgo;

namespace OS_Phase_1
{



    internal class Program
    {   
        
        static void Main(string[] args)
        {


            //Priority priority = new Priority();
            //priority.Algorithm();


            //RoundRobin roundRobin = new RoundRobin();
            //roundRobin.Algorithm();

            ////SRTF sRTF = new SRTF();
            ////sRTF.Algorithm();

            //Console.WriteLine("\n");
            // process id's
            //Process_SRTF[] proc = { new Process_SRTF(1, 3, 1),
            //                new Process_SRTF(2, 4, 2),
            //                new Process_SRTF(3, 2, 1),
            //                new Process_SRTF(4, 4, 4)};

            //SRTF.findavgTime(proc, proc.Length);
            int[] proc = new int[9]
            {
                55,185,396,455,512,27,220,315,86
            };
            OS_Phase_1.Disk_Scheduling.FCFS cSCAN = new OS_Phase_1.Disk_Scheduling.FCFS(100, proc, 600);
            cSCAN.Algorithm();


            Console.WriteLine("\ndotnet meown\n end");
        }
    }
}

