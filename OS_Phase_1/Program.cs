

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
            Process_SRTF[] proc = { new Process_SRTF(1, 3, 1),
                            new Process_SRTF(2, 4, 2),
                            new Process_SRTF(3, 2, 1),
                            new Process_SRTF(4, 4, 4)};

            SRTF.findavgTime(proc, proc.Length);


            Console.WriteLine("\ndotnet meown\n end");
        }
    }
}

