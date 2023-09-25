

using OS_Phase_1.SchedulinigAlgo;

namespace OS_Phase_1
{



    internal class Program
    {   
        
        static void Main(string[] args)
        {


            //Priority priority = new Priority();
            //priority.Algorithm();


            RoundRobin roundRobin = new RoundRobin();
            roundRobin.Algorithm();

            //SRTF sRTF = new SRTF();
            //sRTF.Algorithm();

            Console.WriteLine("\n");
            

           
            
            Console.WriteLine("dotnet meown\n end");
        }
    }
}

