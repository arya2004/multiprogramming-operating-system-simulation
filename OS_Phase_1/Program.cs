

using OS_Phase_1.SchedulinigAlgo;

namespace OS_Phase_1
{



    internal class Program
    {   
        
        static void Main(string[] args)
        {

         



            FCFS f = new FCFS();
            f.Algorithm();
            Console.WriteLine("\n");
            SJF sJF = new SJF();
            sJF.Algorithm();
            
            //Console.WriteLine("dotnet meown\n end");
        }
    }
}

