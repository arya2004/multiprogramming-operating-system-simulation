namespace Lab.Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] proc = new int[9]
          {
                55,185,396,455,512,27,220,315,86
          };
            Disk_Scheduling.FCFS cSCAN = new Disk_Scheduling.FCFS(100, proc, 600);
            cSCAN.Algorithm();


            Console.WriteLine("\ndotnet meown\n end");
        }
    }
}