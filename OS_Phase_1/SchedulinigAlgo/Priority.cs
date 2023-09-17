using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.SchedulinigAlgo
{
    /*
    > accept process from user
    > accept AT and BT
    > sort ascending according to AT
    > execute process on cpu based on AT
    > find out CT of each process

    >CT:
    i = 0 -> start time = 0
    i != 0 -> start time = CTC (-1)

    >Find TAT, WT, RT

    >Display CAN chart
    >STOP
     */


    public class Priority
    {

        public void Algorithm()
        {
            Console.WriteLine("SJF ALgorithm in c#");
            Console.WriteLine("enter the nunmber of processes");
            int a = Convert.ToInt32(Console.ReadLine());

            Process[] q = new Process[a];
            //q[0] = new Process(0, 1, 4);
            //q[1] = new Process(1, 1, 2);
            //q[2] = new Process(2, 2, 8);

            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Enter Process {0} Pid", i);
                int priority = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Process {0} Arrival Time", i);
                int AT = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Process {0} Burst Time", i);
                int BT = Convert.ToInt32(Console.ReadLine());
                q[i] = new Process(priority, AT, BT);
            }

            Process[] sorted = q.OrderBy(i => i.AT).ThenBy(j => j.PId).ToArray();
            //assumed sorted



            // time = sorted[0].AT + sorted[0].CT;
            sorted[0].CT = sorted[0].AT + sorted[0].BT;


            for (int i = 1; i < sorted.Length; i++)
            {

                if (sorted[i].AT < sorted[i - 1].CT)
                {
                    sorted[i].CT = sorted[i - 1].CT + sorted[i].BT;
                }
                else
                {
                    sorted[i].CT = sorted[i].AT + sorted[i].BT;
                }


            }

            for (int i = 0; i < sorted.Length; i++)
            {
                // sorted[i].CalculateCT();
                sorted[i].CalculateTAT();
                sorted[i].CalculateWT();
                sorted[i].CalculateRT();
            }


            Console.WriteLine("Pid\tAT\tBT\tCT\tTAT\tWT\tRT");
            for (int i = 0; i < sorted.Length; i++)
            {


                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", sorted[i].PId, sorted[i].AT, sorted[i].BT, sorted[i].CT, sorted[i].TAT, sorted[i].WT, sorted[i].RT);
            }

            Console.WriteLine("Gantt Chart");

            if (sorted[0].AT != 0)
            {
                Console.Write("|IDLE|");
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write(" {0} |", sorted[i].PId);
                }
                Console.WriteLine("");

                Console.Write("0    {0}", sorted[0].AT);


                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write("   {0}", sorted[i].CT);
                }
            }
            else
            {
                Console.Write("|");
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write(" {0} |", sorted[i].PId);
                }
                Console.WriteLine("");

                Console.Write("{0}", sorted[0].AT);


                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write("   {0}", sorted[i].CT);
                }

            }




        }



    }
}
